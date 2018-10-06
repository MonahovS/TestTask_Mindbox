using System;
using System.Collections.Generic;
using System.Text;

namespace SquareLib.Elements
{
    /// <summary>
    /// Класс для измерения площади и других параметров треугольника, заданного длинами сторон.
    /// В случае невозможности существования треугольника с заданными сторонами будет выдано исключение.
    /// </summary>
    public class Triangle:SquareMeter
    {
        /// <summary>
        /// 1-я сторона треугольника
        /// </summary>
        public double SideA { get; set; }
        /// <summary>
        /// 2-я сторона треугольника
        /// </summary>
        public double SideB { get; set; }
        /// <summary>
        /// 3-я сторона треугольника
        /// </summary>
        public double SideC { get; set; }

        void FastTestSides()
        {
            if (SideA <= 0)
                throw new ArgumentOutOfRangeException("Длина стороны A должна быть >= 0 ");
            if (SideB <= 0)
                throw new ArgumentOutOfRangeException("Длина стороны B должна быть >= 0 ");
            if (SideC <= 0)
                throw new ArgumentOutOfRangeException("Длина стороны C должна быть >= 0 ");
        }

        double PrecalcSquare()
        {
            FastTestSides();

            var p = (SideA + SideB + SideC) / 2; //полупериметр

            var d = p * (p - SideA) * (p - SideB) * (p - SideC);

            if (d <= VSMALL)
            {
                throw new ArgumentOutOfRangeException("Не существует треугольник с заданными сторонами");
            }

            return d;
        }

        /// <summary>
        /// Расчет площади треугольника
        /// </summary>
        /// <returns>
        /// Площадь фигуры
        /// Выдаст исключение, если фигура некорректно задана
        /// </returns>
        public override double CalcSquare()
        {
            var d = PrecalcSquare();

            var S = Math.Sqrt(d);

            return S;
        }

        /// <summary>
        /// Проверяет прямоугольный ли заданный треугольник
        /// </summary>
        /// <returns>
        /// true - если треугольник прямоугольный
        /// При некорректных данных выдаст исключение.
        /// </returns>
        public bool IsRightAngled()
        {
            PrecalcSquare();

            var Sides = new List<double>() { SideA*SideA, SideB*SideB, SideC*SideC };
            Sides.Sort();

            var d = Sides[3] - Sides[2] - Sides[1];
            if (Math.Abs(d) < VSMALL)
                return true;
            else
                return false;
        }
    }
}
