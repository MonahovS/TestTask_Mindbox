using System;
using System.Collections.Generic;
using System.Text;

namespace SquareLib.Elements
{
    /// <summary>
    /// Класс для измерения площади произвольной фигуры заданным алгоритмом пользователя.
    /// Т.к. задача была недоопределена, я предположил, что на стороне пользователя есть специалист по измерению нетривиальных фигур.
    /// Для удобства я обеспечил ему отдельный класс для подключения произвольных данных и алгоритмов, которые он может использовать.
    /// В реальной жизни я безусловно бы связался с заказчиком и уточнил данный пункт ТЗ, возможно реализовав специальные классы для различных типов фигур, вплоть до фракталов, если это необходимо.    
    /// </summary>
    public class Unknown:SquareMeter
    {
        /// <summary>
        /// Параметры фигуры
        /// </summary>
        public List<double> Params { get; private set; } = new List<double>();

        /// <summary>
        /// Алгоритм измерения площади фигуры по заданным в Params параметрам.
        /// </summary>
        public Func<List<double>, double> ExternCalcFunction { get; set; }

        /// <summary>
        /// Расчет площади треугольника
        /// </summary>
        /// <returns>
        /// Площадь фигуры.
        /// Выдаст исключение, если алгоритм ExternCalcFunction не задан. Не перехватывает исключения из самого алгоритма.
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
