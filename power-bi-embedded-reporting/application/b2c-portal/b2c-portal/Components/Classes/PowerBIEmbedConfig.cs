﻿using Microsoft.PowerBI.Api.Models;

namespace b2c_portal.Components.Classes
{
    public class PowerBIEmbedConfig
    {
        public string Id { get; set; }
        public string EmbedUrl { get; set; }
        public EmbedToken EmbedToken { get; set; }

        public int MinutesToExpiration
        {
            get
            {
                var minutesToExpiration = EmbedToken.Expiration - DateTime.UtcNow;
                return minutesToExpiration.Minutes;
            }
        }

        public bool? IsEffectiveIdentityRolesRequired { get; set; }
        public bool? IsEffectiveIdentityRequired { get; set; }
        public bool EnableRLS { get; set; }
        public string Username { get; set; }
        public string Roles { get; set; }
        public string ErrorMessage { get; internal set; }
    }
}