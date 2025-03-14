﻿using Apps.Lokalise.Dtos;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;


namespace Apps.Lokalise.Models.Responses.Keys
{
    public class KeyWithDate
    {

        [Display("Key ID")]
        public string KeyId { get; set; }

        [Display("Created at")]
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Tags { get; set; }
        [Display("Key name")] public KeyName KeyName { get; set; }
        [Display("Filenames")] public Filenames Filenames { get; set; }
        [Display("Base language")] public TranslationObj? SourceTranslation { get; set; }

        [Display("Translations")]
        public IEnumerable<TranslationObj>? Translations { get; set; }
        public KeyWithDate(KeyDto k) 
        {
            KeyId = k.KeyId;
            CreatedAt = DateTime.ParseExact(Regex.Match(k.CreatedAt, @"(.+? .+?) ").Groups[1].Value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            Description = k.Description;
            Tags = k.Tags;
            KeyName = k.KeyName;
            Filenames = k.Filenames;
            SourceTranslation = k.SourceTranslation;
            Translations = k.Translations;

        }
    }
}
