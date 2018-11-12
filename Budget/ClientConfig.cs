﻿using System;
using HtmlRapier.TagHelpers;
using Newtonsoft.Json;

namespace Budget
{
    /// <summary>
    /// Client side configuration, copied onto pages returned to client, so don't include secrets.
    /// </summary>
    public class ClientConfig : ClientConfigBase
    {
        /// <summary>
        /// The url of the app's service, defaults to ~/api. You can
        /// specify an absolute url here if you want.
        /// </summary>
        [ExpandHostPath]
        public string ServiceUrl { get; set; } = "~/api";

        /// <summary>
        /// The url of the user directory.
        /// </summary>
        public string UserDirectoryUrl { get; set; }
    }
}