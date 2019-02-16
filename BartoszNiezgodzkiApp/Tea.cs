using System;
using System.Collections.Generic;
using System.Text;

namespace BartoszNiezgodzkiApp
{
    public class Tea
    {
        public string Name { get; set; }
        public string Kind { get; set; }
        public int BrewingTemperature { get; set; }
        public int BrewingTime { get; set; }
        public string SpecialFeature { get; set; }

        public static List<Tea> WriteData (string[] data)
        {
            List<Tea> teaList = new List<Tea>();
            foreach (string line in data)
            {
                string[] splitLine = line.Split(',');
                if (splitLine[0][0] == '#' || splitLine.Length == 1) continue;
                if (splitLine.Length == 5)
                {
                    teaList.Add(new Tea() { Name = splitLine[0], Kind = splitLine[1], BrewingTemperature = int.Parse(splitLine[2]), BrewingTime = int.Parse(splitLine[3]), SpecialFeature = splitLine[4] });
                }
                else if (splitLine.Length == 4)
                {
                    teaList.Add(new Tea() { Name = splitLine[0], Kind = splitLine[1], BrewingTemperature = int.Parse(splitLine[2]), BrewingTime = int.Parse(splitLine[3]) });
                }
                else
                {
                    Console.WriteLine("Wrong record length");
                }

            }

            return teaList;
        }

        public static List<Tea> CheckTeaParameters (string[] data)
        {
            List<Tea> teaList = new List<Tea>();
            

            return teaList;
        }
    }
}
