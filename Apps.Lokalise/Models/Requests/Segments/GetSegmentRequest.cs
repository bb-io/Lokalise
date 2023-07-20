﻿
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Segments
{
    public class GetSegmentRequest
    {
        [Display("Project ID")]
        public string ProjectId { get; set; }
        
        [Display("Key ID")]
        public long KeyId { get; set; }
        
        [Display("Language code")]
        public string LanguageCode { get; set; }

        [Display("Segment number")]
        public int SegmentNumber { get; set; }

        [Display("Disable references")]
        public bool? DisableReferences { get; set; }
    }
}
