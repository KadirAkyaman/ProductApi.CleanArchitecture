using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayraExport.Infrastructure.Options
{
    public class DatabaseSettings
    {
        public const string SectionName = "DatabaseSettings";
        public string DefaultConnection { get; set; } = string.Empty;
    }
}