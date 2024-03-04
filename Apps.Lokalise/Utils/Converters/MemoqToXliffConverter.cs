using System.Text;
using System.Xml.Linq;

namespace Apps.Lokalise.Utils.Converters;

public static class MemoqToXliffConverter
{
    private static readonly XNamespace ns = "urn:oasis:names:tc:xliff:document:1.2";
    private static XNamespace _mqNs = "MQXliff";

    public static XDocument ConvertMqXliffToXliff(this Stream inputStream, bool useSkeleton)
    {
        using var reader = new StreamReader(inputStream, Encoding.UTF8);
        var xliffDocument = XDocument.Load(reader);

        XNamespace defaultNs = xliffDocument.Root.GetDefaultNamespace();

        var newXliff = new XDocument(
            new XElement(ns + "xliff", new XAttribute("version", "1.2"),
                new XElement(ns + "file",
                    new XAttribute("original", xliffDocument.Root?.Element(defaultNs + "file")?.Attribute("original")?.Value ?? "unknown"),
                    new XAttribute("source-language", xliffDocument.Root?.Element(defaultNs + "file")?.Attribute("source-language")?.Value ?? "unknown"),
                    new XAttribute("target-language", xliffDocument.Root?.Element(defaultNs + "file")?.Attribute("target-language")?.Value ?? "unknown"),
                    new XAttribute("datatype", xliffDocument.Root?.Element(defaultNs + "file")?.Attribute("datatype")?.Value ?? "plaintext"),
                    CreateHeader(xliffDocument, useSkeleton),
                    CreateBody(xliffDocument, defaultNs)
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

    private static XElement CreateBody(XDocument xliffDocument, XNamespace defaultNs)
    {
        var body = new XElement(ns + "body");
        
        foreach (var transUnit in xliffDocument.Descendants(defaultNs + "trans-unit"))
        {
            var newTransUnitElement = new XElement(ns + "trans-unit",
                new XAttribute("id", transUnit.Attribute("id")?.Value ?? "unknown")
            );

            var sourceElement = ProcessTransUnitElement(transUnit.Element(defaultNs + "source"));
            if (sourceElement != null) newTransUnitElement.Add(sourceElement);

            var targetElement = ProcessTransUnitElement(transUnit.Element(defaultNs + "target"));
            if (targetElement != null) newTransUnitElement.Add(targetElement);

            body.Add(newTransUnitElement);
        }

        return body;
    }

    private static XElement? ProcessTransUnitElement(XElement? element)
    {
        if (element == null) return null;

        if (element.HasElements)
        {
            var newElement = new XElement(ns + element.Name.LocalName);
            return newElement;
        }
        
        return new XElement(ns + element.Name.LocalName, element.Value);
    }
}
