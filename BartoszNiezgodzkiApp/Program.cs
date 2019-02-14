using System;
using System.Collections.Generic;
using System.IO;


namespace BartoszNiezgodzkiApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string readText = File.ReadAllText("tea-data.txt");
            string[] splitText = readText.Split('\n');
            string[] splitTextReverse = splitText;
            Array.Reverse(splitTextReverse);
            File.WriteAllLines("result-1.txt", splitTextReverse);
            foreach (string line in splitTextReverse)
            {
                Console.WriteLine(line);
            }

            List<Tea> teaList = new List<Tea>();

            foreach (string line in splitText)
            {
                string[] splitLine = line.Split(',');
                
                teaList.Add(new Tea() { Name = splitLine[0], Kind = splitLine[1], BrewingTemperature = splitLine[2], BrewingTime = splitLine[3], Note = splitLine[3]  } );
            }

            Console.ReadKey();


        }

    }


       
   }
