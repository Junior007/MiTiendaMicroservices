﻿using System;

namespace identity.api.Dtos
{
    public class UserForList
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActivity { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public object PhotoUrl { get; internal set; }
    }
}
