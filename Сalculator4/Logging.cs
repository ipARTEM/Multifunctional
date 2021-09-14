using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

namespace Сalculator4
{
    public class Logging
    {
        public ConsoleSettings Console { get; set; }

        public bool  IncludeScopes { get; set; }


        public class ConsoleSettings
        {
            public LogLevelSettings LogLevel { get; set; }

            public class LogLevelSettings
            {
                [JsonConverter(typeof(JsonStringEnumConverter))]
                public LogLevel Default { get; set; }

                [JsonConverter(typeof(JsonStringEnumConverter))]
                public LogLevel System { get; set; }

                [JsonConverter(typeof(JsonStringEnumConverter))]
                public LogLevel Microsoft { get; set; }

            }
        }

    }
}