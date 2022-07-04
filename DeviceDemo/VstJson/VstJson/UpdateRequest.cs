using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vst
{
    public enum UpdateActions { Delete = -1, Update, Insert };
    public class TokenRequest
    {
        public string Token { get; set; }
        public object Value { get; set; }
    }
    public class UpdateRequest : TokenRequest
    {
        public UpdateActions Action { get; set; }
        public string ObjectId { get; set; }
    }
}
