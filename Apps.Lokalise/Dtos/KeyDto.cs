using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Dtos
{
    public class KeyDto
    {
        public int Key_id { get; set; }

        public string Created_at { get; set; }

        public string Description { get; set; }

        public KeyName Key_name { get; set; }

        public Filenames Filenames { get; set; }

        public IEnumerable<TranslationObj> Translations { get; set; }
    }

    public class Filenames
    {
        public string Ios { get; set; }
        public string Android { get; set; }
        public string Web { get; set; }
        public string Other { get; set; }
    }

    public class KeyName
    {
        public string Ios { get; set; }
        public string Android { get; set; }
        public string Web { get; set; }
        public string Other { get; set; }
    }

    public class TranslationObj
    {
        public int TranslationId { get; set; }
        public int KeyId { get; set; }
        public string LanguageIso { get; set; }
        public string Translation { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedByEmail { get; set; }
        public string ModifiedAt { get; set; }
        public int ModifiedAtTimestamp { get; set; }
        public bool IsReviewed { get; set; }
        public bool IsUnverified { get; set; }
        public int ReviewedBy { get; set; }
        public int Words { get; set; }
        public int TaskId { get; set; }
    }
}
