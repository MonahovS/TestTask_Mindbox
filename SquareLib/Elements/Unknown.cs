using System;
using System.Collections.Generic;
using System.Text;

namespace SquareLib.Elements
{
    public class Unknown:SquareMeter
    {
        public List<double> Params { get; private set; } = new List<double>();

        public Func<List<double>, double> ExternCalcFunction { get; set; }

        public override double CalcSquare()
        {
            if (ExternCalcFunction == null)
                throw new ArgumentNullException("Не задана функция расчета фигуры");
            else
                return ExternCalcFunction(Params);
        }
    }
}
