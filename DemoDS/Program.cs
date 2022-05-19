using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;

namespace DemoDS
{
    class Program
    {
        static void Main(string[] args)
        {
            //CountOccurenceofGivenCharacters();
            //CountOccrenceOfAllCharachters();
            //DynamicType();
            ParseConfigureFile();
        }

        public static void CountOccurenceofGivenCharacters()
        {
            Console.Write("Enter a String : ");
            string inputValue = Console.ReadLine();
            Console.Write("Enter character to count the occurence : ");
            char countCharacter = Console.ReadLine()[0];
            int totalCount = 0;

            // simple foreach loop
            //foreach (char c in inputValue)
            //{
            //    if (c == countCharacter)
            //    {
            //        totalCount++;
            //    }
            //}

            //LINQ and Count method
            //totalCount = inputValue.Count(f => (f == countCharacter));

            // LING and Where method
            totalCount = inputValue.Where(x => (x == countCharacter)).Count();

            Console.WriteLine($"Total count occurence of the Character {countCharacter} is {totalCount}");
        }

        public static void CountOccrenceOfAllCharachters()
        {
            Console.Write("Enter a String to Count all character occrences : ");
            string inputValue = Console.ReadLine();

            //Remove the empty spaces from the message
            inputValue = inputValue.Replace(" ", string.Empty);

            while (inputValue.Length > 0)
            {
                Console.Write($"{inputValue[0]} : ");
                int count = 0;
                for (int i = 0; i < inputValue.Length; i++)
                {                    
                    if (inputValue[0] == inputValue[i])
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
                inputValue = inputValue.Replace(inputValue[0].ToString(), string.Empty);
            }
        }

        public static void DynamicType()
        {
            dynamic d;
            d = 100;
            Console.WriteLine($"d value is {d} and its Type is {d.GetType()}");

            d = "Hello World";
            Console.WriteLine($"d value is {d} and its Type is {d.GetType()}");

            // Difference between Dynamic and var
            string[] strMonths = { "Jan", "Feb", "Mar" };
            int[] numMonths = { 1, 2, 3 };
            var varMonths = from m in strMonths
                                select m;
            // Below code throws compile time error because once var is assigned its type cannot be changed
            // To change the type after assignation intead use dynamic
            // varMonths = from m in numMonths
            //            select m;

            // Now use DynamicEmployee Class;
            dynamic dynamicEmployee = new DynamicEmployee();
            dynamicEmployee.FirstName = "Tom";
            dynamicEmployee.LastName = "Jerry";
            dynamicEmployee.DOB = new DateTime(1998, 05, 01);

            Func<string, string, string> method = (a, b) => a + " " + b;
            dynamicEmployee.GetData = method;
            Console.WriteLine($"FirstName: {dynamicEmployee.FirstName} \n" +
                $"LastName: {dynamicEmployee.LastName} \n" +
                $"DOB: {dynamicEmployee.DOB} \n" +
                $"FullName: {dynamicEmployee.GetData("Mike", "Tyson")} \n" +
                $"Its Type: {dynamicEmployee.GetType()}");

            // Now use ExpandoObject Class;
            dynamic expandoEmployee = new ExpandoObject();
            expandoEmployee.FirstName = "ExpandoTom";
            expandoEmployee.LastName = "Jerry";
            expandoEmployee.DOB = new DateTime(1998, 05, 01);

            Func<string, string, string> method2 = (a, b) => a + " " + b;
            expandoEmployee.GetData = method2;
            Console.WriteLine($"FirstName: {expandoEmployee.FirstName} \n" +
                $"LastName: {expandoEmployee.LastName} \n" +
                $"DOB: {expandoEmployee.DOB} \n" +
                $"FullName: {expandoEmployee.GetData("Mike", "Tyson")} \n" +
                $"Its Type: {expandoEmployee.GetType()}");

            Console.ReadLine();

        }

        public static void ParseConfigureFile()
        {
            var allText = File.ReadAllText(@"D:\LTCodes\DS\DemoDS\UserFile.txt");
            var allLines = allText.Trim(' ').Split(';');

            var dataObj = new Dynamic();
            for (int i = 0; i < allLines.Length - 1; i++)
            {
                var currentLine = allLines[i].Split(":");                
                for(int j = 0; j < currentLine.Length; j++)
                {
                    dataObj.AddProperty(currentLine[0], currentLine[1]);
                }
            }


        }
    }
}
