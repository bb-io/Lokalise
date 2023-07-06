﻿using Apps.Lokalise.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Models
{
    public class Translation
    {
        [Display("Translation ID")]
        public int TranslationId { get; set; }

        [Display("Translation")]
        public string TranslationValue { get; set; }

        [Display("Previous translation")]
        public string PreviousTranslationValue { get; set; }

        [Display("Language ID")]
        public int LanguageId { get; set; }

        [Display("Language ISO code")]
        public string Iso { get; set; }

        [Display("Language name")]
        public string LanguageName { get; set; }

        [Display("Key ID")]
        public int KeyId { get; set; }

        [Display("Key name")]
        public string KeyName { get; set; }
    }

    public class TranslationsEvent : BaseEvent
    {
        [Display("Translations")]
        public List<Translation> Translations { get; set; }
    }
}
