using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;

namespace testchengjiu.data
{
    public class Test
    {
        class Tests
        {
            public static void Main()
            {
                try
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader sr = new StreamReader("TestFile.txt"))
                    {
                        String line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
