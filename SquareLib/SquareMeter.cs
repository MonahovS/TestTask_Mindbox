using System;
using System.Collections.Generic;
using System.Text;

namespace SquareLib
{
    public abstract class SquareMeter
    {
        /// <summary>
        /// Ограничение точности вычислений
        /// </summary>
        public const double VSMALL = 10e-9;

        /// <summary>
        /// Расчет площади фигуры
        /// </summary>
        /// <returns>
        /// Площадь фигуры
        /// Выдаст исключение, если фигура некорректно задана
        /// </returns>
        public abstract double CalcSquare();
        
        /// <summary>
        /// Расчет площади фигуры, если это возможно.
        /// </summary>
        /// <param name="outSquare">Площадь фигуры</param>
        /// <returns>true - если фигура корректра и расчет успешен</returns>
        public bool TryCalcSquare(out double outSquare)
        {
            try
            {
                outSquare = CalcSquare();
                return true;
            }
            catch
            {
                outSquare = 0;
                return false;
            }            
        }
    }
}
