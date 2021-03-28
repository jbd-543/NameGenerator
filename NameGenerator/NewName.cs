using System;
using System.Collections.Generic;
using System.IO;

namespace NameGenerator
{
    public class NewName
    {
        /* I initially set the contents of the files to arrays, but when I added files that had more or less contents
         * than the original files that I was using, I was getting logic errors where the program would generate blank
         * names because not all the arrays were the same size. So I decided to switch to lists since it's not necessary
         * to set the size.
         */

        // This method is similar to the one shown to us in one of our assignments. With a little tweaking, I was
        // able to use it to read the contents of a file and store them in a list rather than display to console
        public static List<string> processFile(string filename)
        {
            string line;
            List<string> names = new List<string>();
            TextReader reader = new StreamReader(filename);
            while (true)
            {
                line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                names.Add(line);
            }
            reader.Close();
            return names;
        }
        // This method pulls a random piece of data from the list, in this case a name in the form of a string
        public static string GetRandomName(List<string> names)
        {
            Random randomName = new Random();
            int randomNumber = randomName.Next(names.Count);
            return names[randomNumber];
        }
    }
}