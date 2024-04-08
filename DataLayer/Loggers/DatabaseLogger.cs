using DataLayer.Database;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Loggers
{
    public class DatabaseLogger
    {
        private readonly DatabaseContext _context;

        public DatabaseLogger(DatabaseContext context)
        {
            _context = context;
        }
    }
}
