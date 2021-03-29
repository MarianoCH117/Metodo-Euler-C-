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
        double tope = 2f;
        int contador = 0;

        public void calcularEuler()
        {
            while (xn < tope)
            {
                double raiz = Math.Sqrt(y);
                double denominador = (2 * xn) + 1;
                double porcentajes;
                y = yn + (h * (raiz / denominador));
                Console.Write("Vuelta: " + contador + "El valor de la ecuacion es:");
                Console.WriteLine("{0:N6}", y);
                contador++;
                xn = xn + h;
                h = 0.25f;
                yn = y;
                double ecuacion = Math.Pow((Math.Log((2 * xn) + 1) / 4) + 2, 2);
                Console.Write("El valor de la ecuacion chido es :");
                Console.WriteLine("{0:N6}", ecuacion);
                porcentajes = ((ecuacion - y) / ecuacion) * 100;
                Console.Write("Porcentaje: ");
                Console.WriteLine("{0:N1}", +Math.Abs(porcentajes));
            }
        }
    }
}
