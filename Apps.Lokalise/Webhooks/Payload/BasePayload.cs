﻿using Apps.Lokalise.Webhooks.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Payload
{
    public class BasePayload : IModellable
    {
        public string Event { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
        public string CreatedAt { get; set; }
        public int CreatedAtTimestamp { get; set; }
        public BaseEvent Convert()
        {
            return new BaseEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
            };
        }
    }

    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class User
    {
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
