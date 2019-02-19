using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BartoszNiezgodzkiApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] readText = File.ReadAllText("tea-data.txt").Split('\n');
            string heading = readText[0];
            Tea.ReadTeaParameters(readText);
            
            for (int i=0; ;i++)
            {
                #region console display 
                if (i >= 1)
                {
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.WriteLine("Which command do you wish to run? (1-6, 0-Exit) ");
                var taskNumber = int.Parse(Console.ReadLine());
                if (taskNumber == 0) break;
                Console.Clear();
                #endregion
                switch (taskNumber)
                {
                    case 1:
                        ReverseText(readText); //task 1
                        break;
                    case 2:
                        SortedByKind(heading); //task 2
                        break;
                    case 3:
                        break;
                    case 4:
                        CheckByWriting(); //task 4
                        break;
                    case 5:
                        CheckByInput(); //task 5
                        break;
                    case 6:
                        MakeTouareg(); //task 6
                        break;
                    default:
                    Console.WriteLine("Incorrect number");
                    break;
                }
            }
        }

        private static void MakeTouareg()
        {
            string inputPath = @"..\\..\\..\\Inputs\\input-file-2.txt";
            string outputPath = @"..\\..\\..\\Results\\result-6.txt";
            string[] inputData = File.ReadAllText(inputPath).Split('\n', StringSplitOptions.RemoveEmptyEntries);
            List<string> outputData = new List<string>();
            
            
            for (int i = 0; i < inputData.Length; i+=2)
            {

                var waterData = inputData[i].Split(',');
                var mintData = inputData[i+1].Split(',');

                var waterBrewingResult = Tea.CheckTeaParameters(waterData[0].Trim(), int.Parse(waterData[2]), int.Parse(waterData[3]));
                var mintBrewingResult = Tea.CheckTeaParameters(mintData[0].Trim(), int.Parse(mintData[2]), int.Parse(mintData[3]));

                string outputLine;
                if (waterBrewingResult == "perfect" && mintBrewingResult == "perfect")
                {
                    outputLine = "Congratulations, perfect Touareg \n";
                }
                else
                {
                    outputLine = "Sadly, yourTouareg is ruined. \n";
                }
                outputData.Add(outputLine);
                Console.WriteLine(outputLine);
                
            }

            File.WriteAllLines(outputPath, outputData);
        }

        private static void CheckByWriting()
        {
            Console.WriteLine("put the name of the tea to be used");
            string readName = Console.ReadLine();
            Console.WriteLine("put the temperature of water you want to use");
            int readTemperature = int.Parse(Console.ReadLine());
            Console.WriteLine("put the amount of time you want to spend brewing that tea (in seconds)");
            int readTime = int.Parse(Console.ReadLine());
            string[] result = { readName + ",  " + readTemperature + ",  " + readTime + ",  "
                                        + Tea.CheckTeaParameters(readName, readTemperature, readTime) };
            File.AppendAllLines(@"..\\..\\..\\Results\\result-4.txt", result);
            Console.WriteLine(Tea.CheckTeaParameters(readName, readTemperature, readTime));
            
        }

        private static void CheckByInput()
        {
            string inputPath = @"..\\..\\..\\Inputs\\input-file.txt";
            string outputPath = @"..\\..\\..\\Results\\result-5.txt";
            string[] inputData = File.ReadAllText(inputPath).Split('\n', StringSplitOptions.RemoveEmptyEntries);
            string[] outputData = new string[inputData.Length];

            for (int i = 0; i < outputData.Length; i++)
            {
                outputData[i] = inputData[i].Trim() + " " + Tea.CheckTeaParameters(inputData[i].Split(','));
                Console.WriteLine(outputData[i]);
            }

            File.WriteAllLines(outputPath, outputData);
        }

        private static void ReverseText(string[] text)
        {
            Array.Reverse(text);
            File.WriteAllLines(@"..\\..\\..\\Results\\result-1.txt", text);

            foreach (string line in text)
            {
                Console.WriteLine(line);
            }
        }

        private static void SortedByKind(string heading)
        {
                var sortedTeaParameters = from tea in Tea.TeaParameters
                                          orderby tea.Kind
                                          select tea;

                string textToDisplay = heading + "\n" + Environment.NewLine;

                foreach (Tea tea in sortedTeaParameters)
                {
                    textToDisplay += tea.Name + ", " + tea.Kind + ", " + tea.BrewingTemperature + ", " + tea.BrewingTime + ", " + tea.SpecialFeature + "\n";
                }

                Console.WriteLine(textToDisplay);
                File.WriteAllText(@"..\\..\\..\\Results\\result-2.txt", textToDisplay);
        }
        
    }

 }
