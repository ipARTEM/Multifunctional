using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Сalculator4
{
    public  class Settings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public Logging Logging { get; set; }

        public AppSettings AppSettings { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
