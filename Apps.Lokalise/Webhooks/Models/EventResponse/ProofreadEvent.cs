﻿using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class ProofreadEvent : BaseEvent
{
    [Display("Translation ID")]
    public string TranslationId { get; set; }

    [Display("Translation")]
    public string TranslationValue { get; set; }

    [Display("Is proofread")]
    public bool IsProofread { get; set; }

    [Display("Language ID")]
    public string LanguageId { get; set; }

    [Display("Language ISO code")]
    public string Iso { get; set; }

    [Display("Language name")]
    public string LanguageName { get; set; }

    [Display("Key ID")]
    public string KeyId { get; set; }

    [Display("Key name")]
    public string KeyName { get; set; }


}