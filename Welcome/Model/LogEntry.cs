using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welcome.Model
{
    public class LogEntry
    {
        public virtual int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
