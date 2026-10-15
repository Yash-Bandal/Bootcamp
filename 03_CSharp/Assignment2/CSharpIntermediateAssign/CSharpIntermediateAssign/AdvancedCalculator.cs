using System;
using CSharpIntermediateAssign.Interface;

namespace CSharpIntermediateAssign
{
    public class AdvancedCalculator :  Calculator, IAdvancedCalculator
    {
        public double Power(int baseNum, int exponent)
        {
            _result = Math.Pow(baseNum, exponent);
            return _result;
        }

        public override double GetResult() 
        {
            return _result * 1_000_000;
        }
    }
}
