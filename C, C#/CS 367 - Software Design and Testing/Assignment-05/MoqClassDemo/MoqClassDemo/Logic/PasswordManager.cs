using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoqClassDemo.Models;
using MoqClassDemo.Services;

namespace MoqClassDemo.Logic
{
    public class PasswordManager : IPasswordManager
    {
        //private readonly IDataStore DataStore;
        public IDataStore DataStore { get; set; }

        public PasswordManager(IDataStore dataStore)
        {
            DataStore = dataStore;
        }

        private IEnumerable<PasswordResult> Validate(PasswordEntry passwordEntry)
        {
            var passwordResult = new List<PasswordResult>();

            var password = passwordEntry.Password;

            var passwordArray = password.ToCharArray();
            if (passwordArray.Length < 8)
                passwordResult.Add(PasswordResult.InvalidMinCharacterLimit);

            var upperCount = 0;
            var lowerCount = 0;
            var nonAlphaCount = 0;
            foreach (var ch in password)
            {
                if (char.IsUpper(ch)) upperCount += 1;
                if (char.IsLower(ch)) lowerCount += 1;
                if (!char.IsLetterOrDigit(ch)) nonAlphaCount += 1;
            }

            if (upperCount < 1)
                passwordResult.Add(PasswordResult.InvalidUppercaseAlphaLimit);

            if (lowerCount < 1)
                passwordResult.Add(PasswordResult.InvalidLowercaseAlphaLimit);

            if (nonAlphaCount < 1)
                passwordResult.Add(PasswordResult.InvalidNonAlphaNumericLimit);

            if (passwordResult.Count == 0)
                passwordResult.Add(PasswordResult.Valid);

            return passwordResult;
        }

        public IEnumerable<PasswordResult> Add(PasswordEntry passwordEntry)
        {
            var passwordResult = Validate(passwordEntry);

            if (passwordResult.Any(result => result == PasswordResult.Valid)) 
                DataStore.Add(passwordEntry);

            return passwordResult;
        }

        public IEnumerable<PasswordResult> Update(PasswordEntry passwordEntry)
        {
            var passwordResult = Validate(passwordEntry);

            if (passwordResult.Any(result => result == PasswordResult.Valid))
                DataStore.Update(passwordEntry);

            return passwordResult;
        }

        public void Delete(string id)
        {
            DataStore.Delete(id);
        }

        public PasswordEntry GetEntry(string siteName) => DataStore.Get(siteName);
    }
}
