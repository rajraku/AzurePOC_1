using Newtonsoft.Json.Linq;
using System;

namespace CommonModels
{
    public class RequestLog
    {
        public string Method { get; set; }
        public JObject Body { get; set; }
        public Guid? Id { get; set; }
    }
}
