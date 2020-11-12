using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace App.SharedKernel.Services
{
    [LayoutRenderer("default-template")]
    public class DefaultLoggingTemplate : LayoutRenderer
    {
        public string Config1 { get; set; }

        [RequiredParameter]
        public string Config2 { get; set; }

        [DefaultParameter]
        public bool Caps { get; set; }

        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append("My Logging Template 1!");
        }
    }
}


