﻿using System;

namespace Restofit.Core.Models
{
    class RestofitResponses
    {

    }

    public class AuthenticationResult
    {
        public bool ok { get; set; }
        public string access_token { get; set; }
        public string userName { get; set; }
        public string token_type { get; set; }
        public DateTime issued { get; set; }
        public DateTime expires { get; set; }
    }

    public class UserInfo
    {
        public string Email { get; set; }

        public bool IsRegistered { get; set; }

        public string LoginProvider { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }
    }
}
