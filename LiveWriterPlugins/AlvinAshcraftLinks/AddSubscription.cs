using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Sandworks.Google.Reader;

namespace AlvinAshcraftLinks
{
    public class AddSubscription
    {
        public static void Main2(string[] args)
        {
            // Empty line.
            Console.WriteLine("");

            // Get username.
            Console.Write(" Enter your Google username: ");
            //string username = Console.ReadLine();

            object obj = new object();

            ReaderService rdr = new ReaderService("affiliatested", "Sudha123", "Sandworks.Google.App");
            {


                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\sumant\desktop\deallinks.txt");

                int count = 0;
                Parallel.ForEach(lines.Distinct(), (line) =>
                {

                    lock (obj)
                        Console.WriteLine("Processing line: " + count++);

                    if (!line.Contains("technorati"))
                    {
                        try
                        {
                            {
                                rdr.AddSubscription(line);
                                Console.WriteLine("Subscription Added: " + line);
                            }
                        }
                        catch (Exception ex)
                        {
                            rdr = new ReaderService("affiliatested", "Sudha123", "Sandworks.Google.App");
                            Console.WriteLine("************Failed********" + " " + line);
                        }
                    }

                });

            }



            // Pause.
            Console.ReadLine();
        }

    }
}
