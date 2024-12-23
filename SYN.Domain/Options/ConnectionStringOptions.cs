using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYN.Domain.Options
{
    public class ConnectionStringOptions
    {
        public const string SectionName = "ConnectionString";

        public string dbcs { get; set; } = null!;
    }
}
