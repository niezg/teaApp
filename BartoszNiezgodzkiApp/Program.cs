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

            string readText = File.ReadAllText("tea-data.txt");
            string[] splitText = readText.Split('\n');
            string heading = splitText[0];


            for (int i=0; ;i++)
            {
                if (i >= 1)
                {
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.WriteLine("Which command do you wish to run? (1-6, 0-Exit) ");
                int taskNumber = int.Parse(Console.ReadLine());
                if (taskNumber == 0) break;
                Console.Clear();

                switch (taskNumber)
                {

                    case 1:

                        string[] splitTextReverse = splitText;
                        Array.Reverse(splitTextReverse);
                        File.WriteAllLines("result-1.txt", splitTextReverse);

                        foreach (string line in splitTextReverse)
                        {
                            Console.WriteLine(line);
                        }

                        break;

                    case 2:

                        List<Tea> teaList = Tea.WriteData(splitText);
                        var sortedTeaList = from tea in teaList
                                            orderby tea.Kind
                                            select tea;

                        string resultTextCommand_2 = heading  + "\n" + Environment.NewLine;

                        foreach (Tea tea in sortedTeaList)
                        {
                            resultTextCommand_2 += tea.Name + ", " + tea.Kind + ", " + tea.BrewingTemperature + ", " + tea.BrewingTime + ", " + tea.SpecialFeature + "\n";
                        }

                        Console.WriteLine(resultTextCommand_2);
                        File.WriteAllText("result-2.txt", resultTextCommand_2);

                        break;

                    case 3:
                        break;
                    case 4:
                        Console.WriteLine("put the name of the tea to be used");
                        string readName = Console.ReadLine();
                        Console.WriteLine("put the temperature of water you want to use");
                        int readTemperature = int.Parse(Console.ReadLine()); 
                        Console.WriteLine("put the amount of time you want to spend brewing that tea (in seconds)");
                        int readTime = int.Parse(Console.ReadLine());

                        Tea
                        break;
                    case 5:
                    case 6:


                    default:
                    Console.WriteLine("Incorrect number");
                    break;
                }
            }

        }

    }

   }
