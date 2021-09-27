using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Chords
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly myAssembly = Assembly.LoadFrom(@"C:\training\Eurotraining\Assignment2\Assignment2\ChordFileGenerator\ChordFileGenerator\bin\Debug\ChordFileGenerator.dll");

            //Console.WriteLine("Information:{0}", myAssembly.FullName);
            Type[] asm = myAssembly.GetTypes();

            //Type myType = myAssembly.GetType("Mobile Library.Mobile");

            object objectInstance = Activator.CreateInstance(asm[0]);


            Console.WriteLine("Song Name: ");
            string SongName = Console.ReadLine();
            Get.SetPropetyValue(objectInstance, "SongName", SongName);

            Console.WriteLine("Artist Name: ");
            string ArtistName = Console.ReadLine();
            Get.SetPropetyValue(objectInstance, "Artist", ArtistName);

            Console.WriteLine("File Type: ");
            string FileType = Console.ReadLine();
            Get.SetPropetyValue(objectInstance, "FileType", FileType);

            string line;
            do
            {
                Console.WriteLine("Line Type- Lyrics(L),Chords&Lyrics(CL) or blank to cancel");
                line = Console.ReadLine();
                if (line == "L")
                {
                    string lyrics = Console.ReadLine();
                    Get.InvokeMethod(objectInstance, "WriteLine", new object[] { lyrics });
                }
                else if (line == "CL")
                {
                    string chords = Console.ReadLine();
                    string lyrics = Console.ReadLine();
                    Get.InvokeMethod(objectInstance, "WriteLine", new object[] { chords, lyrics });
                }
            } while (line == "L" || line == "CL");

            Get.InvokeMethod(objectInstance, "SaveFile", new object[] { "Test.txt" });

            Console.WriteLine("File saved");
            Console.Read();


        }
    }
}
