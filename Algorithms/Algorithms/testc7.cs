using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class testc7
    {
        private string _firstname;
        public string FirstName
        {
            get => _firstname;
            set => Set(ref _firstname, value);
        }
        public void testout()
        {
            string n = "42";
            if (string.TryParse(n, out var result))
            {
                Console.WriteLine($"Converting to a number was successful:{result}");
            }
        }
    }
}
