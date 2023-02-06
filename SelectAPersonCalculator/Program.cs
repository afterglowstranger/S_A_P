using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace SelectAPersonCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userSelection = "";
            var calculator = new ArithmeticClass();
            var sampleList1 = new List<double>();
            var strSampleList = "1,3,-2,101,40,45,56,57,85,85,83,100,0,3.1415";
            var strings = strSampleList.Split(',');
            double result;

            // declare variables for compound interest
            double amount, principal, rate;
            int nTimesPerYear, term;

            foreach ( var s in strings )
            {
                if (double.TryParse(s, out double number)){ 
                    sampleList1.Add(number);
                }
            }

            var cleanList = calculator.cleanUpSampleEntry(sampleList1);

            while (userSelection != "x") {
                Console.WriteLine("Select A Person - Fun With Numbers");
                Console.WriteLine("Calculate the Arimetic Mean of a list of numbers - Enter m");
                Console.WriteLine(" ");
                Console.WriteLine("Calculate the Standard Deviation of a list of numbers - Enter s");
                Console.WriteLine(" ");
                Console.WriteLine("Calculate the Bin Frequences of a list of numbers - Enter f");
                Console.WriteLine(" ");
                Console.WriteLine("Calculate the Square Root of a number - Enter r");
                Console.WriteLine(" ");
                Console.WriteLine("Calculate the compound increase of a value given interest rate for a number of years - Enter c");
                Console.WriteLine(" ");
                Console.WriteLine("Calculate the compound decrease of a value given interest rate for a number of years - Enter d");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("To Exit - Enter x");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "m":
                        Console.WriteLine("Calculating Mean of " + strSampleList);
                        Console.WriteLine("Values less than 0 or greater than 100 are excluded.");
                        result = calculator.arithmeticMean(cleanList);
                        Console.WriteLine("The Arithmetic Mean = " + result.ToString());
                        Console.WriteLine("--------------------------------------");
                        break;
                    case "s":
                        Console.WriteLine("Calculating the Standard Deviation of " + strSampleList);
                        Console.WriteLine("Values less than 0 or greater than 100 are excluded.");
                        result = calculator.standardDeviation(cleanList);
                        Console.WriteLine("The Standard Deviation = " + result.ToString());
                        Console.WriteLine("--------------------------------------");
                        break;
                    case "f":
                        Console.WriteLine("Calculating the Bin Frequencies of " + strSampleList);
                        Console.WriteLine("Values less than 0 or greater than 100 are excluded.");
                        var resultList= calculator.binFrequencies(cleanList);
                        var i=0; 
                        foreach (var item in resultList)
                        {
                            Console.WriteLine("Bin " + (i*10).ToString() + " to " + (i*10+10) + " Count:" + item.ToString());

                            i++;
                        }
                        //Console.WriteLine("The Bin Frequencies = " + result.ToString());
                        Console.WriteLine("--------------------------------------");
                        break;
                    case "r":
                        Console.WriteLine("Calculating the Square Root of 27");
                        Console.WriteLine("Values less than 0 or greater than 100 are excluded.");
                        result = ArithmeticClass.squareRoot(27.0);
                        Console.WriteLine("The Square root of 27.0 is = +or- " + result.ToString());
                        Console.WriteLine("--------------------------------------");
                        break;
                    case "c":
                       

                        // take input of initial principal amount,
                        // interest rate, periodicity of payment and year
                        Console.Write("Enter the principal balance = ");
                        principal = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter interest rate= ");
                        rate = Convert.ToDouble(Console.ReadLine());
                        
                        Console.Write("Enter compound frequency / year = ");
                        nTimesPerYear = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("Enter the year  = ");
                        term = Convert.ToInt32(Console.ReadLine());

                        // calculate compounded value using formula
                        amount = calculator.compoundAmountIncrease(principal, rate, nTimesPerYear, term);
                        //amount = principal * Math.Pow((1 + rate / (100 * nTimesPerYear)), nTimesPerYear * term);
                        Console.WriteLine("Principal plus Compound interest = £ " + Math.Round(amount, 2));

                        break;
                    case "d":
                        // declare variables
                        //double amount, p, r;
                        //int n, t;

                        // take input of initial principal amount,
                        // interest rate, periodicity of payment and year
                        Console.Write("Enter the principal balance = ");
                        principal = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter interest rate= ");
                        rate = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter compound frequency / year = ");
                        nTimesPerYear = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter the year  = ");
                        term = Convert.ToInt32(Console.ReadLine());

                        // calculate compounded value using formula
                        amount = calculator.compoundAmountDecrease(principal, rate, nTimesPerYear, term);
                        //amount = principal * Math.Pow((1 - rate / (100 * nTimesPerYear)), nTimesPerYear * term);
                        Console.WriteLine("Principal now worth = £ " + Math.Round(amount, 2));

                        break;
                    case "x":
                        Console.WriteLine("Closing Programme...");
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                 }
            }
            
        }
    }
}
