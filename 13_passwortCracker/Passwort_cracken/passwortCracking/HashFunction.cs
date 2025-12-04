using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCracker
{
    internal class HashFunction
    {
        public static ulong SimpleHash(string password, string salt)
        {
            string s = password + salt;
            if (password == null || salt == null) return 0;
            unchecked  // deactivate overflow checking
            {
                ulong hash = 539812381;
                foreach (char ch in s)
                {
                    hash = ((hash * 511729819239912877) + hash) + (ulong)ch * 197997167218291;
                }
                return hash;
            }
        }
    }
}
