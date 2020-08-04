using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBSCLEARN.Helpers
{
    public class MessageClass
    {
        public int StatusId { get; set; }
        public string StatusMessage { get; set; }
        public string RecordResponseObject { get; set; }
        public bool IsSuccessful => StatusId == 1;
    }
}
