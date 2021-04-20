using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Encodingproject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public virtual List<Order> Orders { get; set; }
    }
}
