using System;

namespace FinancialForecasting
{
    class Program
    {
        // Recursive Method
        static double PredictFutureValue(double currentValue, double growthRate, int years)
        {
            if (years == 0)
                return currentValue;

            return PredictFutureValue(
                currentValue * (1 + growthRate),
                growthRate,
                years - 1
            );
        }

        static void Main(string[] args)
        {
            double currentValue = 10000; // Initial Investment
            double growthRate = 0.10;    // 10%
            int years = 5;

            double futureValue = PredictFutureValue(currentValue, growthRate, years);

            Console.WriteLine($"Current Value : {currentValue}");
            Console.WriteLine($"Growth Rate   : {growthRate * 100}%");
            Console.WriteLine($"Years         : {years}");
            Console.WriteLine($"Future Value  : {futureValue:F2}");
        }
    }
}