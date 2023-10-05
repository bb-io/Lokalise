﻿using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models;

public class ProofreadEvent : BaseEvent
{
    [Display("Translation ID")]
    public int TranslationId { get; set; }

    [Display("Translation")]
    public string TranslationValue { get; set; }

    [Display("Is proofread")]
    public bool IsProofread { get; set; }

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