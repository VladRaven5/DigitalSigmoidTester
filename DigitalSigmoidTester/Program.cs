using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalSigmoidTester
{
    class Program
    {
        private static int _attempts = 1000;
        private static int _shownWorstResultCount = 30;

        static void Main(string[] args)
        {
            var random = new Random();

            var naturalSigmoid = new Sigmoid();
            var digitalSigmoid = new DigitalSigmoid();

            double maxEpsilon = Double.MinValue;
            double averageEpsilon = 0;

            List<Result> allResults = new List<Result>(_attempts);
            
            for (int i = 0; i < _attempts; i++)
            {
                var arg = (random.NextDouble() * 10) - 5;

                double natValue = naturalSigmoid.CalculateForValue(arg);
                double digValue = digitalSigmoid.CalculateForValue(arg);

                double epsilon = Math.Abs(natValue - digValue);

                if (epsilon > maxEpsilon)
                    maxEpsilon = epsilon;

                averageEpsilon += epsilon / _attempts;

                allResults.Add(new Result(arg, natValue, digValue, epsilon));
            }

            Console.WriteLine($"Max epsilon: {maxEpsilon}");
            Console.WriteLine($"Avg epsilon: {averageEpsilon}");
            Console.WriteLine($"==================");
            Console.WriteLine($"Worst results:");

            var worstResults = allResults.OrderByDescending(res => res.Epsilon).Take(_shownWorstResultCount).ToArray();
            for (int i = 0; i < _shownWorstResultCount; i++)
            {
                var worstResult = worstResults[i];
                Console.WriteLine($"{i}) Arg = {worstResult.Argument}, Nat.Sigmoid = {worstResult.NaturalResult}, Dig.Sigmoid = {worstResult.DigitalResult}, Eps = {worstResult.Epsilon}");
            }

            Console.ReadKey();
        }

        private class Result
        {
            public Result(double argument, double naturalResult, double digitalResult, double epsilon)
            {
                Argument = argument;
                NaturalResult = naturalResult;
                DigitalResult = digitalResult;
                Epsilon = epsilon;
            }

            public double Argument { get; }
            public double NaturalResult { get; }
            public double DigitalResult { get; }
            public double Epsilon { get; }
        }
    }
}
