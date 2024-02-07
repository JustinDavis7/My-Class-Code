using System.Collections.Generic;
using MoqClassDemo.Models;
using MoqClassDemo.Services;

namespace MoqClassDemo.Logic
{
    public interface IPasswordManager
    {
        IDataStore DataStore { get; set; }
        PasswordEntry GetEntry(string siteName);
        IEnumerable<PasswordResult> Add(PasswordEntry passwordEntry);
        IEnumerable<PasswordResult> Update(PasswordEntry passwordEntry);
        void Delete(string id);
    }
}