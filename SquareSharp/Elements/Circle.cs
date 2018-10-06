using System;
using System.Collections.Generic;
using System.Text;


namespace SquareSharp
{
    public class Circle:SquareMeter
    {
        /// <summary>
        /// Радиус круга.
        /// Может быть и положительным и отрицательным.
        /// Отрицательный радиус считается корректным, т.к. это часто принято в чертежных системах - там различаются внешний и внутренний радиусы.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Расчет площади круга
        /// </summary>
        /// <returns>
        /// Площадь фигуры
        /// Выдаст исключение, если фигура некорректно задана
        /// </returns>
        public override double CalcSquare()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
