using CSharpIntermediateAssign.Interface;

namespace CSharpIntermediateAssign
{
    public class Calculator : ICalculator
    {
        protected double _result;

        public virtual double GetResult()
        { 
            return _result;
        }

        public int Add(int num1, int num2)
        {
            _result = num1 + num2;
            return num1 + num2;
        }

        public int Add(int num1, int num2, int num3)
        {
            _result = num1 + num2 + num3;
            return num1 + num2 + num3;
        }

        public float Add(float fnum1, float fnum2)
        {
            _result = fnum1 + fnum2;
            return fnum1 + fnum2;
        }
    }
}
