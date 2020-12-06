using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailLibrary
{
    public static class Crypto
    {
        public static string Encode(string input)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                char coded = c;
                result.Append(--coded);
            }
            return result.ToString();
        }

        public static string Decode(string input)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                char coded = c;
                result.Append(++coded);
            }
            return result.ToString();
        }

    }
}
