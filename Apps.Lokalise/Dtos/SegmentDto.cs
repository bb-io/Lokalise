using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Dtos
{
    public class SegmentDto
    {
        public int Segment_number { get; set; }
        public string Language_iso { get; set; }
        public string Modified_at { get; set; }
        public string Modified_by_email { get; set; }
        public string Value { get; set; }
        public bool Is_fuzzy { get; set; }
        public bool Is_reviewed { get; set; }
        public int Words { get; set; }
    }
}
