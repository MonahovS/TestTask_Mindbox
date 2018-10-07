using System;
using System.Collections.Generic;
using System.Text;

using SquareLib.Elements;
using SquareLib;

namespace SquareSharp
{
    public static class SquareTests
    {
        static bool DoTest(Func<bool> t)
        {
            bool b = t();
            Console.WriteLine(b ? "ok" : "ERROR");

            return !b;
        }
        public static bool RunTests()
        {
            bool HaveError = false;

            #region Circle

            Console.WriteLine(nameof (Circle_GreaterZero_Equal));
            HaveError |= DoTest(Circle_GreaterZero_Equal);

            Console.WriteLine(nameof(Circle_GreaterZero_TryOnly));
            HaveError |= DoTest(Circle_GreaterZero_TryOnly);

            Console.WriteLine(nameof(Circle_GreaterZero_TryEqual));
            HaveError |= DoTest(Circle_GreaterZero_TryEqual);

            Console.WriteLine(nameof(Circle_GreaterZero));
            HaveError |= DoTest(Circle_GreaterZero);

            Console.WriteLine(nameof(Circle_Zero));
            HaveError |= DoTest(Circle_Zero);

            Console.WriteLine(nameof(Circle_LessZero));
            HaveError |= DoTest(Circle_LessZero);

            #endregion

            #region Triangle

            Console.WriteLine(nameof(Triangle_ZeroSide_Exception));
            HaveError |= DoTest(Triangle_ZeroSide_Exception);

            Console.WriteLine(nameof(Triangle_ZeroSide_NoException));
            HaveError |= DoTest(Triangle_ZeroSide_NoException);

            Console.WriteLine(nameof(Triangle_MinusSide_Exception));
            HaveError |= DoTest(Triangle_MinusSide_Exception);

            Console.WriteLine(nameof(Triangle_MinusSide_NoException));
            HaveError |= DoTest(Triangle_MinusSide_NoException);

            Console.WriteLine(nameof(Triangle_BadSides_Exception));
            HaveError |= DoTest(Triangle_BadSides_Exception);

            Console.WriteLine(nameof(Triangle_BadSides_NoException));
            HaveError |= DoTest(Triangle_BadSides_NoException);

            Console.WriteLine(nameof(Triangle_GoodSides_NoException));
            HaveError |= DoTest(Triangle_GoodSides_NoException);

            Console.WriteLine(nameof(Triangle_BadSides_RightAngled_Exception));
            HaveError |= DoTest(Triangle_BadSides_RightAngled_Exception);

            Console.WriteLine(nameof(Triangle_NoRightAngled));
            HaveError |= DoTest(Triangle_NoRightAngled);

            Console.WriteLine(nameof(Triangle_IsRightAngled));
            HaveError |= DoTest(Triangle_IsRightAngled);

            #endregion

            #region Unknown
            Console.WriteLine(nameof(Unknown_NoFunc_Exc));
            HaveError |= DoTest(Unknown_NoFunc_Exc);

            Console.WriteLine(nameof(Unknown_SampleFunc));
            HaveError |= DoTest(Unknown_SampleFunc);

            Console.WriteLine(nameof(Unknown_SampleFunc));
            HaveError |= DoTest(Unknown_SampleFunc);

            Console.WriteLine(nameof(Unknown_SampleFunc_Error));
            HaveError |= DoTest(Unknown_SampleFunc_Error);           


            #endregion



            return HaveError;
        }

        #region Circle

        static bool Circle_GreaterZero_Equal()
        {
            try
            {
                var c = new Circle { Radius = 10 };
                double res = c.CalcSquare();

                double RealRes = 100 * Math.PI;

                bool result = Math.Abs(RealRes - res) < SquareMeter.VSMALL;

                return result;
            }
            catch
            {
                return false;
            }
        }

        static bool Circle_GreaterZero_TryOnly()
        {
            try
            {
                var c = new Circle { Radius = 10 };
                double res;

                bool result = c.TryCalcSquare(out res);

                return result;

            }
            catch
            {
                return false;
            }
        }

        static bool Circle_GreaterZero_TryEqual()
        {
            try
            {
                var c = new Circle { Radius = 10 };
                double res;
                c.TryCalcSquare(out res);

                double res2 = c.CalcSquare();

                bool result = Math.Abs(res2 - res) < SquareMeter.VSMALL;
                return result;

            }
            catch
            {
                return false;
            }
        }

        static bool Circle_GreaterZero()
        {
            try
            {
                var c = new Circle{ Radius = 10 };
                double res = c.CalcSquare();

                double RealRes = 100 * Math.PI;

                bool result = Math.Abs(RealRes - res) < SquareMeter.VSMALL;

                return result;
            }
            catch
            {
                return false;
            }
        }

        static bool Circle_Zero()
        {
            try
            {
                var c = new Circle { Radius = 0 };
                double res = c.CalcSquare();

                double RealRes = 0;

                bool result = Math.Abs(RealRes - res) < SquareMeter.VSMALL;

                return result;
            }
            catch
            {
                return false;
            }
        }

        static bool Circle_LessZero()
        {
            try
            {
                var c = new Circle { Radius = -2 };
                double res = c.CalcSquare();

                double RealRes = 4 * Math.PI;

                bool result = Math.Abs(RealRes - res) < SquareMeter.VSMALL;

                return result;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Triangle

        static bool Triangle_ZeroSide_Exception()
        {
            try
            {
                var t1 = new Triangle { SideA = 0, SideB = 2, SideC = 2 };
                t1.CalcSquare();

                var t2 = new Triangle { SideA = 2, SideB = 0, SideC = 2 };
                t2.CalcSquare();

                var t3 = new Triangle { SideA = 2, SideB = 2, SideC = 0 };
                t2.CalcSquare();

                return false;
            }
            catch
            {
                return true;
            }
        }

        static bool Triangle_ZeroSide_NoException()
        {
            try
            {                
                double res;               

                var t1 = new Triangle { SideA = 0, SideB = 2, SideC = 2 };
                if (t1.TryCalcSquare(out res))                
                    return false;

                var t2 = new Triangle { SideA = 2, SideB = 0, SideC = 2 };
                if (t2.TryCalcSquare(out res))                
                    return false;

                var t3 = new Triangle { SideA = 2, SideB = 2, SideC = 0 };
                if (t3.TryCalcSquare(out res))                
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        static bool Triangle_MinusSide_Exception()
        {
            try
            {
                var t1 = new Triangle { SideA = -1, SideB = 2, SideC = 2 };
                t1.CalcSquare();

                var t2 = new Triangle { SideA = 2, SideB = -1, SideC = 2 };
                t2.CalcSquare();

                var t3 = new Triangle { SideA = 2, SideB = 2, SideC = -1 };
                t2.CalcSquare();

                return false;
            }
            catch
            {
                return true;
            }
        }

        static bool Triangle_MinusSide_NoException()
        {
            try
            {
                double res;               

                var t1 = new Triangle { SideA = -1, SideB = 2, SideC = 2 };
                if (t1.TryCalcSquare(out res))                
                    return false;

                var t2 = new Triangle { SideA = 2, SideB = -1, SideC = 2 };
                if (t2.TryCalcSquare(out res))
                    return false;

                var t3 = new Triangle { SideA = 2, SideB = 2, SideC = -1 };
                if (t3.TryCalcSquare(out res))                
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        static bool Triangle_BadSides_Exception()
        {
            try
            {
                var t1 = new Triangle { SideA = 1000, SideB = 100, SideC = 1 };
                t1.CalcSquare();

                return false;
            }
            catch
            {
                return true;
            }
        }

        static bool Triangle_BadSides_NoException()
        {
            try
            {
                var t1 = new Triangle { SideA = 1000, SideB = 100, SideC = 1 };

                double res;
                if (t1.TryCalcSquare(out res))
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        static bool Triangle_GoodSides_NoException()
        {
            try
            {
                var t1 = new Triangle { SideA = 4, SideB = 2, SideC = 3 };

                double res;
                if (!t1.TryCalcSquare(out res))
                {
                    return false;
                }

                double p = (4.0 + 2.0 + 3.0) / 2.0;
                double RealRes = Math.Sqrt(p * (p - 4) * (p - 2) * (p - 3));

                bool result = Math.Abs(RealRes - res) < SquareMeter.VSMALL;

                return result;
            }
            catch
            {
                return false;
            }
        }

        static bool Triangle_BadSides_RightAngled_Exception()
        {
            try
            {
                var t1 = new Triangle { SideA = 1000, SideB = 100, SideC = 1 };
                t1.IsRightAngled();

                var t2 = new Triangle { SideA = 0, SideB = 20, SideC = 20 };
                t2.IsRightAngled();

                var t3 = new Triangle { SideA = 20, SideB = -1, SideC = 20 };
                t3.IsRightAngled();

                return false;
            }
            catch
            {
                return true;
            }
        }

        static bool Triangle_NoRightAngled()
        {
            try
            {
                var t1 = new Triangle { SideA = 200, SideB = 400, SideC = 300 };
                bool result = t1.IsRightAngled();

                return !result;
            }
            catch
            {
                return false;
            }
        }

        static bool Triangle_IsRightAngled()
        {
            try
            {
                var t1 = new Triangle { SideA = 3, SideB = 5, SideC = 4 };
                bool result = t1.IsRightAngled();

                return result;
            }
            catch
            {
                return false;
            }
        }



        #endregion

        #region Unknown
        static bool Unknown_NoFunc_Exc()
        {
            try
            {
                var u = new Unknown();
                                
                u.CalcSquare();

                return false;
            }
            catch
            {
                return true;
            }
        }

        static bool Unknown_SampleFunc()
        {
            try
            {
                var u = new Unknown()
                {
                    ExternCalcFunction = (lst => { return lst[0] * lst[0]; })
                };

                u.Params.Add(10);
                               
                var res = u.CalcSquare();

                if (Math.Abs(res - 100) < SquareMeter.VSMALL)
                    return true;


                return false;
            }
            catch
            {
                return false;
            }
        }

        static bool Unknown_SampleFunc_Error()
        {
            try
            {
                var u = new Unknown()
                {
                    ExternCalcFunction = (lst => { return lst[0] * lst[0]; })
                };

                u.CalcSquare();

                return false;
            }
            catch
            {
                return true;
            }
        }

        #endregion

    }
}
