using Newtonsoft.Json;
using System;

namespace DomainModels
{
    public class ToDo
    {

        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }
        [JsonProperty(PropertyName = "task")]
        public string Task { get; set; }
        [JsonProperty(PropertyName = "isCompleted")]
        public bool IsCompleted { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
