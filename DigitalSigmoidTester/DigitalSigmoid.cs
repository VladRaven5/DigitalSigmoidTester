using System.Collections.Generic;

namespace DigitalSigmoidTester
{
    public class DigitalSigmoid
    {
        private readonly List<(double a, double b)> _polynomialCoefficients = new List<(double a, double b)>
        {
            (0.01129, 0.06248),
            (0.02943, 0.13404),
            (0.07177, 0.25902),
            (0.14973, 0.41285),
            (0.23105, 0.49653),
            (0.23105, 0.50346),
            (0.14973, 0.58714),
            (0.07177, 0.74097),
            (0.02943, 0.86595),
            (0.01129, 0.93751)
        };

        public double CalculateForValue(double arg)
        {
            switch (arg)
            {
                case var _ when arg <= -5:
                    return 0;

                case var _ when arg >= 5:
                    return 1;

                default:
                    int argIndex = GetCoefficientsListIndex(arg);
                    var (a, b) = _polynomialCoefficients[argIndex];
                    return GetValue(a, b, arg);
            }
        }

        private int GetCoefficientsListIndex(double arg)
        {
            int index = (int) arg;

            if (arg >= 0)
                index++;

            index += 4;

            return index;
        }

        private double GetValue(double a, double b, double x)
        {
            return a * x + b;
        }
    }
}
