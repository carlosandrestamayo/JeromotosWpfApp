using System;
using System.Collections.Generic;
using System.Text;

namespace JeromotosWpfApp.Security
{
    public class PasswordGenerator
    {
        public static string Generate()
        {
            const string upper =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            const string lower =
                "abcdefghijklmnopqrstuvwxyz";

            const string numbers =
                "0123456789";

            const string specials =
                "@#$%&*!?";

            Random random = new Random();

            string password = upper[random.Next(upper.Length)].ToString()
                             + lower[random.Next(lower.Length)]
                             + numbers[random.Next(numbers.Length)]
                             + specials[random.Next(specials.Length)];

            string all =
                upper + lower + numbers + specials;

            while (password.Length < 10)
            {
                password +=
                    all[random.Next(all.Length)];
            }

            return new string(
                password
                .OrderBy(x => random.Next())
                .ToArray()
            );
        }
    }
}
