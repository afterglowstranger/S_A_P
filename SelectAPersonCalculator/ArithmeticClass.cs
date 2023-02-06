using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectAPersonCalculator
{
    public class ArithmeticClass
    {
        public ArithmeticClass() { }

        public List<double> cleanUpSampleEntry(List<double> entries) { 
        
            var removeLessThanZero = entries.Where(x => x >= 0);
            var removeGreaterThan100 =removeLessThanZero.Where(y=> y <= 100); 

            return removeGreaterThan100.ToList();
        }

        public double arithmeticMean(List<double> entries)
        {
            var sum = 0.0;
            var count = entries.Count();

            //Debatable if an empty set should return 0, error or warning?
            if (count == 0) return 0;

            foreach ( var entry in entries)
            {
                sum += entry;
            }

            return sum/count;

        }

        public double standardDeviation(List<double> entries) {

            var mean = arithmeticMean(entries);
            
            var subtractMeanSquared = new List<double>();
            foreach (var item in entries) { 
                subtractMeanSquared.Add(Math.Pow(item-mean,2.0));
            }

            var squaredDifferencesMean = arithmeticMean(subtractMeanSquared);

            var standardDeviation = squareRoot(squaredDifferencesMean);
            return standardDeviation;
        }

      

        public static double squareRoot(double x)
        {
            if (x == 0) return 0;

            double r = x / 2; 
                              
            double last = 0;
            int maxIters = 100;

            for (int i = 0; i < maxIters; i++)
            {
                r = (r + x / r) / 2;
                if (r == last)
                    break;
                last = r;
            }

            return r;
        }

        public List<int> binFrequencies(List<double> entries)
        {

            var binFrequencies = new List<int>();
            for (int i = 0; i < 11; i++)
            {
                binFrequencies.Add(entries.Where(num => num >= 10 * i && num < 10 + 10 * i).Count());
            }

            return binFrequencies;  

        }

        public double compoundAmountIncrease(double principal, double rate, int nTimesPerYear, int term)
        { 

            return Math.Round(principal * Math.Pow((1 + rate / (100 * nTimesPerYear)), nTimesPerYear * term),2);
        }

        public double compoundAmountDecrease(double principal, double rate, int nTimesPerYear, int term)
        {

            return Math.Round(principal * Math.Pow((1 - rate / (100 * nTimesPerYear)), nTimesPerYear * term),2);
        }

    }
}
