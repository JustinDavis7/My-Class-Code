using System.Collections.Generic;
using MoqClassDemo.Models;

namespace MoqClassDemo.Services
{
    public interface IDataStore
    {
        IList<PasswordEntry> Passwords { get; set; }
        void Add(PasswordEntry passwordEntry);
        PasswordEntry Get(string siteName);
        IEnumerable<PasswordEntry> GetAll();
        void Update(PasswordEntry updatedPasswordEntry);
        void Delete(string id);
    }
}
