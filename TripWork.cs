using FileUpload.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload
{
    public class TripWork
    {
        public static List<string> Split(string lineToSplit)
        {
            //split a line using " " as a delimiter
            List<string> finishedLine = lineToSplit.Split(" ").ToList();
            return finishedLine;
        }

        public static TimeSpan GetDuration(string splitLine)
        {
            //endtime - starttime = totaltime
            List<string> result = new List<string>();
            result = Split(splitLine);
            DateTime startTime = Convert.ToDateTime(result[2]);
            DateTime endTime = Convert.ToDateTime(result[3]);
            TimeSpan totalTime = endTime - startTime;
            return totalTime;
        }

        public static double GetMiles(string splitLine)
        {
            List<string> result = new List<string>();
            result = Split(splitLine);
            double miles = Convert.ToDouble(result[4]);
            return miles;
        }

        public static double GetMPH(string splitLine)
        {
            //distance/time= mph
            TimeSpan duration = GetDuration(splitLine);
            double miles = GetMiles(splitLine);
            double milesPerHour = miles / duration.TotalHours;
            return milesPerHour;
        }

        public static string GetName(string line)
        {
            return GetName(Split(line));
        }

        public static string GetName(List<string> splitLine)
        {
            string name = splitLine[1];
            return name;
        }

        public static string GetStartTime(string line)
        {
            return GetStartTime(Split(line));
        }

        public static string GetStartTime(List<string> splitLine)
        {
            string startTime = splitLine[2];
            return startTime;
        }

        public static string GetEndTime(string line)
        {
            return GetEndTime(Split(line));
        }

        public static string GetEndTime(List<string> splitLine)
        {
            string endTime = splitLine[3];
            return endTime;
        }


        public static double Time (TimeSpan time)
        {
            return time.TotalMinutes / 60;
        }

        public static Driver MakeDriver (string line)
        {
            Driver driver = new Driver();
            driver.Name = GetName(line);
            driver.StartTime = "0:00";
            driver.EndTime = "0:00";
            driver.Mph = 0;
            driver.Miles = 0;
            return driver;
        }
        public static Driver UpdateDriver(Driver driver, string line)
        {
            int mphTest = Convert.ToInt32(GetMPH(line));

            if (mphTest > 5 && mphTest < 100)
            {
                driver.trip++;
                driver.TotalTime = driver.TotalTime + GetDuration(line);
                driver.Miles = Math.Round(driver.Miles + GetMiles(line));
                driver.Mph = Math.Round(driver.Miles / driver.TotalTime.TotalHours);

                return driver;

            }
            else return driver;

        }
        public static List <Driver> SortList (List<Driver> drivers)
        {
            List<Driver> sortedList = Program.DriverLog.OrderByDescending(o => o.Miles).ToList();
            return sortedList;
        }
    }
}
