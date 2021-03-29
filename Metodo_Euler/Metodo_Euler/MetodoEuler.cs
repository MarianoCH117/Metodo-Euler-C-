using System;
using System.Collections.Generic;
using System.Text;

namespace Metodo_Euler
{
    class MetodoEuler
    {
        double xn = 0;
        double yn = 4;
        double h = 0;
        double y = 0;
        double yr = 0;
        int contador = 0;

        public void calcularEuler()
        {
            while (xn < 2f)
            {
                double raiz = Math.Sqrt(y);
                double denominador = (2 * xn) + 1;
                y = yn + (h * (raiz / denominador));
                yr = yn + (h * (raiz / denominador));
                Math.Round(yr);
                double ecuacion = Math.Pow((Math.Log((2 * xn) + 1) / 4) + 2, 2);
                contador++;
                Console.Write("Vuelta: " + contador + "El valor de la ecuacion es:");
                Console.WriteLine(y);
                Console.Write("El valor de la ecuacion chido es :");
                Console.WriteLine(ecuacion);
                xn = xn + h;
                h = 0.25f;
                yn = y;
            }
        }
    }
}
