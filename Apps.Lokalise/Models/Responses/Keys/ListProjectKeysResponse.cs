using Apps.Lokalise.Dtos;

namespace Apps.Lokalise.Models.Responses.Keys;

public record ListProjectKeysResponse(IEnumerable<KeyDto> Keys);