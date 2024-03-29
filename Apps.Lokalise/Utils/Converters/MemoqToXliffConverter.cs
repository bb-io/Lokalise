﻿using System.Text;
using System.Xml.Linq;

namespace Apps.Lokalise.Utils.Converters;

public static class MemoqToXliffConverter
{
    private static readonly XNamespace ns = "urn:oasis:names:tc:xliff:document:1.2";
    private static XNamespace _mqNs = "MQXliff";

        public static XDocument ConvertMqXliffToXliff(this Stream inputStream, bool useSkeleton, bool ignoreChildrenInSource = true)
    {
        using var reader = new StreamReader(inputStream, Encoding.UTF8);
        var xliffDocument = XDocument.Load(reader);

        // Extract the default namespace from the .mqxliff file.
        XNamespace defaultNs = xliffDocument.Root.GetDefaultNamespace();

        var newXliff = new XDocument(
            new XElement(ns + "xliff", new XAttribute("version", "1.2"),
                new XElement(ns + "file",
                    new XAttribute("original", xliffDocument.Root?.Element(defaultNs + "file")?.Attribute("original")?.Value ?? "unknown"),
                    new XAttribute("source-language", xliffDocument.Root?.Element(defaultNs + "file")?.Attribute("source-language")?.Value ?? "unknown"),
                    new XAttribute("target-language", xliffDocument.Root?.Element(defaultNs + "file")?.Attribute("target-language")?.Value ?? "unknown"),
                    new XAttribute("datatype", xliffDocument.Root?.Element(defaultNs + "file")?.Attribute("datatype")?.Value ?? "plaintext"),
                    CreateHeader(xliffDocument, useSkeleton),
                    CreateBody(xliffDocument, defaultNs, ignoreChildrenInSource)
                )
            )
        );

        return newXliff;
    }

    private static XElement CreateHeader(XDocument xliffDocument, bool useSkeleton)
    {
        var header = new XElement(ns + "header");

        if (useSkeleton)
        {
            header.Add(new XElement(ns + "skl",
                new XElement(ns + "internal-file", new XAttribute("form", "text/xml"),
                    new XElement(ns + "xliff", new XAttribute("version", "1.2"),
                        xliffDocument.Elements()
                    )
                )
            ));
        }

        return header;
    }

    private static XElement CreateBody(XDocument xliffDocument, XNamespace defaultNs, bool ignoreChildren)
    {
        var body = new XElement(ns + "body");
        
        foreach (var transUnit in xliffDocument.Descendants(defaultNs + "trans-unit"))
        {
            var newTransUnitElement = new XElement(ns + "trans-unit",
                new XAttribute("id", transUnit.Attribute("id")?.Value ?? "unknown")
            );

            var sourceElement = ProcessTransUnitElement(transUnit.Element(defaultNs + "source"), ignoreChildren);
            if (sourceElement != null) newTransUnitElement.Add(sourceElement);

            var targetElement = ProcessTransUnitElement(transUnit.Element(defaultNs + "target"), ignoreChildren);
            if (targetElement != null) newTransUnitElement.Add(targetElement);

            body.Add(newTransUnitElement);
        }

        return body;
    }

    private static XElement ProcessTransUnitElement(XElement element, bool ignoreChildren)
    {
        // Create a new element that matches the name of the original, ensuring it's in the correct namespace
        var newElement = new XElement(ns + element.Name.LocalName);

        // Check if the element contains nested elements (e.g., <ph> tags)
        foreach (var node in element.Nodes())
        {
            if (node is XElement childElement && !ignoreChildren)
            {
                // Recursively process nested elements to support deep structures
                var processedChild = ProcessTransUnitElement(childElement, ignoreChildren);
                newElement.Add(processedChild);
            }
            else if (node is XText textNode)
            {
                newElement.Add(ProcessTextNodeValue(element.Name.LocalName, textNode.Value));
            }
        }

        return newElement;
    }
    
    private static string ProcessTextNodeValue(string elementName, string textValue)
    {
        if (elementName == "source" || elementName == "target")
        {
            return textValue.TrimStart();
        }

        return textValue;
    }
}
