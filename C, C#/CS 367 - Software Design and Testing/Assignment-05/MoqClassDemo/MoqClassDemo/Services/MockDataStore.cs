using System;
using System.Collections.Generic;
using System.Linq;
using MoqClassDemo.Models;

namespace MoqClassDemo.Services
{
    public class MockDataStore : IDataStore
    {
        public IList<PasswordEntry> Passwords { get; set; } = new List<PasswordEntry>();

        public void Add(PasswordEntry passwordEntry)
        {
            Passwords.Add(passwordEntry);
        }

        public PasswordEntry Get(string siteName)
        {
            //foreach (var entry in Passwords)
            //{
            //    if (entry.SiteName.Equals(siteName)) return entry;
            //}

            //return null;

            return Passwords.ToList().SingleOrDefault(password => password.SiteName.Equals(siteName));
        }

        public IEnumerable<PasswordEntry> GetAll()
        {
            return Passwords;
        }

        public void Update(PasswordEntry updatedPasswordEntry)
        {
            // 1. Find the password entry that contains the ID of id parameters
            // 2. Update the entry with the new one

            var id = updatedPasswordEntry.Id;
            foreach (var entry in Passwords)
            {
                if (entry.Id.Equals(id))
                {
                    entry.Url = updatedPasswordEntry.Url;
                    entry.SiteName = updatedPasswordEntry.SiteName;
                    entry.UserName = updatedPasswordEntry.UserName;
                    entry.Password = updatedPasswordEntry.Password;
                    break;
                }
            }
        }

        public void Delete(string id)
        {
            foreach (var entry in Passwords)
            {
                if (entry.Id.Equals(id))
                {
                    Passwords.Remove(entry);
                    break;
                }
            }
        }
    }
}
