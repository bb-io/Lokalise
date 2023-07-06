﻿using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Models
{
    public class ProjectImportedEvent : BaseEvent
    {
        [Display("Filename")]
        public string Filename { get; set; }

        [Display("Format")]
        public string Format { get; set; }

        [Display("Inserted")]
        public int Inserted { get; set; }

        [Display("Updated")]
        public int Updated { get; set; }

        [Display("Skipped")]
        public int Skipped { get; set; }
    }
}
