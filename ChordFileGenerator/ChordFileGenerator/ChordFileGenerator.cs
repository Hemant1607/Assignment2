using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChordFileGenerator
{
    public class ChordFileGenerator
    {
        public string SongName { get; set; }

        public string Artist { get; set; }

        public string FileType { get; set; }

        private List<string> lines;

        public ChordFileGenerator()
        {
            lines = new List<string>();
        }

        public void WriteLine(string l)
        {
            lines.Add(l);
        }

        public void WriteLine(string c,string l)
        {
            WriteLine(c);
            WriteLine(l);
        }
        public void SaveFile(string FileName)
        {
            string contents = GenerateFileContents();
            Console.WriteLine(contents);
            File.WriteAllText(FileName, contents);
            
        }

        private string GenerateFileContents()
        {
            StringBuilder contents = new StringBuilder();

            contents.AppendLine("Song Name: " + SongName);
            contents.AppendLine("Artist: " + Artist);
            contents.AppendLine("FileType: " + FileType);

            contents.AppendLine("******************************************");

            foreach (string line in lines)
            {
                contents.AppendLine(line);

            }

            return contents.ToString();
        }

    }
}
