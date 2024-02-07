using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using MoqClassDemo.Models;

namespace MoqClassDemo.Services
{
    public class JsonDataStore : IDataStore
    {
        public IList<PasswordEntry> Passwords { get; set; } = new List<PasswordEntry>();
        private const string DbFilename = @"Data/JsonDatabase.txt";
        public void Add(PasswordEntry passwordEntry)
        {
            GetAll();

            Passwords?.Add(passwordEntry);

            var jsonData = JsonSerializer.Serialize(Passwords);

            File.WriteAllText(DbFilename, jsonData);
        }

        public PasswordEntry Get(string siteName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PasswordEntry> GetAll()
        {
            var fileData = File.ReadAllText(DbFilename);

            if (fileData != string.Empty) Passwords = JsonSerializer.Deserialize<List<PasswordEntry>>(fileData);

            return Passwords;
        }

        public void Update(PasswordEntry updatedPasswordEntry)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
