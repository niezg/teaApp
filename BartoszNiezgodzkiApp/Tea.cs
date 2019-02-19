using System;
using System.Collections.Generic;
using System.Linq;


namespace BartoszNiezgodzkiApp
{
    public class Tea
    {
        public string Name { get; set; }
        public string Kind { get; set; }
        public int BrewingTemperature { get; set; }
        public int BrewingTime { get; set; }
        public string SpecialFeature { get; set; }
        public static List<Tea> TeaParameters { get; private set; }

        enum Result {perfect,weak,yucky};

        public static void ReadTeaParameters (string[] data)
        {
            List<Tea> teaParameters = new List<Tea>();
            foreach (string line in data)
            {
                string[] splitLine = line.Split(',');
                if (splitLine[0][0] == '#' || splitLine.Length == 1) continue;
                if (splitLine.Length == 5)
                {
                    teaParameters.Add(new Tea() { Name = splitLine[0], Kind = splitLine[1], BrewingTemperature = int.Parse(splitLine[2]), BrewingTime = int.Parse(splitLine[3]), SpecialFeature = splitLine[4] });
                }
                else if (splitLine.Length == 4)
                {
                    teaParameters.Add(new Tea() { Name = splitLine[0], Kind = splitLine[1], BrewingTemperature = int.Parse(splitLine[2]), BrewingTime = int.Parse(splitLine[3]) });
                }
                else
                {
                    Console.WriteLine("Wrong record length");
                }

            }

            TeaParameters = teaParameters;
        }


        public static string CheckTeaParameters(string name, int checkedTemperature, int checkedTime)
        {
            
            var teaParameter =  from tea in TeaParameters
                                where tea.Name == name
                                select tea;
            
            int perfectTemperature = teaParameter.ElementAt(0).BrewingTemperature;
            int perfectTime = teaParameter.ElementAt(0).BrewingTime;
            double highTemperature = perfectTemperature * 1.1;
            double lowTemperature = perfectTemperature * 0.9;
            double highTime = perfectTime * 60 * 1.1;
            double lowTime = perfectTime * 60 * 0.9;

            if (checkedTemperature <= highTemperature && checkedTemperature >= lowTemperature
                && checkedTime <= highTime && checkedTime >= lowTime)
            {
                return Result.perfect.ToString();
            }
            else if (checkedTemperature > highTemperature || checkedTime > highTime)
            {
                return Result.yucky.ToString();
            }
            else
            {
                return Result.weak.ToString();
            }

        }

        public static string CheckTeaParameters(string[] inputData)
        {
            return CheckTeaParameters(inputData[0].Trim(), int.Parse(inputData[1]), int.Parse(inputData[2]));
          
        }
    }
}
