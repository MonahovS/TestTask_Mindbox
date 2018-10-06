using System;
using System.Collections.Generic;
using System.Text;

namespace SquareSharp.Elements
{
    /// <summary>
    /// Класс для пользовательского вычисления площади неизвестной фигуры
    /// </summary>
    public class Unknown:SquareMeter
    {
        /// <summary>
        /// Параметры фигуры
        /// </summary>
        public List<double> Params { get; private set; } = new List<double>();

        /// <summary>
        /// Функция вычисления площади фигуры
        /// Должна принимать список действительных параметров.
        /// Должна выдавать исключение, если расчет по переданным параметрам не возможен.
        /// </summary>
        public Func<List<double>, double> ExternCalcFunction { get; private set; }

        /// <summary>
        /// Расчет площади фигуры
        /// </summary>
        /// <returns>
        /// Площадь фигуры
        /// Выдаст исключение, если фигура некорректно задана.
        /// </returns>
        public override double CalcSquare()
        {
            if (ExternCalcFunction == null)
                throw new ArgumentNullException("Не задана функция расчета фигуры");
            else
                return ExternCalcFunction(Params);
        }
    }
}
