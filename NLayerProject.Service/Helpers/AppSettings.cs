﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; } = "dotnet_panel_key_value_here_secret";

        // refresh token time to live (in days), inactive tokens are
        // automatically deleted from the database after this time
        public int RefreshTokenTTL { get; set; }
    }
}