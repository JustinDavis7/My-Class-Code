using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqClassDemo.Models
{
    public class PasswordEntry
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Url { get; set; }
        public string SiteName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public override bool Equals(object? obj) 
            => obj is PasswordEntry passwordEntry && Id.Equals(passwordEntry.Id);

        public override int GetHashCode() => Id.GetHashCode();
    }
}
