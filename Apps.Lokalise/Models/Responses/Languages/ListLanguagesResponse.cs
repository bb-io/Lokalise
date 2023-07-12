using Apps.Lokalise.Dtos;

namespace Apps.Lokalise.Models.Responses.Languages;

public record ListLanguagesResponse(IEnumerable<LanguageDto> Languages);