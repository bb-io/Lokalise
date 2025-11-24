using Apps.Lokalise.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Languages;

public record ListLanguagesResponse(
    IEnumerable<LanguageDto> Languages,
    [Display("Language codes")] IEnumerable<string> LanguageCodes
);
