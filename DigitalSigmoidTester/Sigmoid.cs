using System;

namespace DigitalSigmoidTester
{
    public class Sigmoid
    {
        public double CalculateForValue(double arg)
        {
            return 1 / (1 + Math.Pow(Math.E, -arg));
        }
    }
}
