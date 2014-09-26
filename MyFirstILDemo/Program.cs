using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstILDemo
{
    class Program
    {
        static double Divider(int a, int b)
        {
            return a / b;
        }

        delegate double DivideDelegate(int a, int b);

        static void Main(string[] args)
        {
            var myMethod = new DynamicMethod("DivideMethod", 
                typeof(double), new[] { typeof(int), typeof(int) }, 
                typeof(Program).Module);
            var il = myMethod.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Div);
            il.Emit(OpCodes.Ret);
            
            var method = (DivideDelegate)myMethod.CreateDelegate(typeof(DivideDelegate));
            var result = method(6, 2);

            Console.Write(result);
            Console.ReadKey();
        }
    }
}
