using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.Models;

namespace FileUpload
{
    public class FilesReader
    {
        public static List<Driver> ReadFile(string fileName)
        {

            //this is hardcoded for now for ease of manual testing
            //TODO replace with flexible input after manual testing completed
            //string directory = @"C:\RootKata";
            //string filename = "input.txt";


            string fullPath = fileName;

            List<Driver> drivers = new List<Driver>();
            string line;

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        if (line != "")
                        {
                            if (line.StartsWith("Driver"))
                            {
                                //checking to make sure the driver doesn't already exist
                                if(!Program.DriverLog.Exists(x => x.Name == TripWork.GetName(line)))
                                {
                                    Driver newdriver = TripWork.MakeDriver(line);
                                    Program.DriverLog.Add(newdriver);
                                }

                            }
                            else if (line.StartsWith("Trip"))
                            {
                                Driver updateDriver = Program.DriverLog.Find(x => x.Name == TripWork.GetName(line));
                                TripWork.UpdateDriver(updateDriver, line);
                                
                            }
                            else
                                throw new IOException("Unknown commands in File");
                        }
                    }
                }
            }

            catch (IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
            return drivers;
        }

    }
}
