using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerEjercicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     /*   
        Debug.Log(lucky_8(9, 1));
        Debug.Log(lucky_8(8, 100));
        Debug.Log(lucky_8(1, 7));
        Debug.Log(lucky_8(9, 9));
 

        Debug.Log(FinfDayFromDate("10-08-2020"));
   */


        Debug.Log(CalculateWordScore("Hello"));
        Debug.Log(CalculateWordScore("HELLO"));
        Debug.Log(CalculateWordScore("Hello WORD"));
        
    }

    public static bool lucky_8(int a, int b)
    {
        bool respuesta = false;
        int suma = a + b;
        int resta = a - b;
        if ((suma == 8) || (resta == 8) || (a == 8) || (b == 8))
        {
            respuesta = true;
        }
        return respuesta;
    }

    public static string FinfDayFromDate(string date)
    {
        string[] datos = date.Split('-');

        int d = int.Parse(datos[0] + "");
        int m = int.Parse(datos[1] + "");
        int y = int.Parse(datos[2] + "");

        int[] t = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
        if (m < 3)
        {
            y--;
        }

        /*
            En esta versión, se utiliza la fórmula conocida como "Algoritmo de Zeller", que se utiliza 
            para calcular el día de la semana a partir de una fecha. La fórmula es la siguiente:

            h: el día de la semana (0 para domingo, 1 para lunes, etc.)
            d: el día del mes (1 a 31)
            m: el mes (1 a 12)
            y: el año

            h = (d + floor(13*(m+1)/5) + y + floor(y/4) - floor(y/100) + floor(y/400)) % 7
        */
        int day = (y + y / 4 - y / 100 + y / 400 + t[m - 1] + d) % 7;

        string result = "";
        switch (day)
        {
            case 1:
                result = "Monday";
                break;
            case 2:
                result = "Tuesday";
                break;
            case 3:
                result = "Wedneday";
                break;
            case 4:
                result = "Thrusday";
                break;
            case 5:
                result = "Friday";
                break;
            case 6:
                result = "Saturday";
                break;
            case 7:
                result = "Sunday";
                break;
        }
        return result;
    }

    public static int CalculateWordScore(string word)
    {
        string cadenaMayuscula = word.ToUpper();
        char[] compararLetras = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        char[] letrasWord = new char[word.Length];
        byte[] assci = new byte[word.Length];
        int sumaTotal = 0;
        // Rellenamos el arreglo de letrasWord segun el parametro de entrada
        for (int i = 0; i < word.Length; i++)
        {
            letrasWord[i] = cadenaMayuscula[i];
        }

        //Convertimos cada letra a codigo ASCCI y lo almacenamos en el array
        for (int i = 0; i < letrasWord.Length; i++)
        {
            assci[i] = System.Convert.ToByte(letrasWord[i]);
        }

        //Comparamos cada valor de nuestro array de assci  con nuestro array de compararLetras
        for (int i = 0; i < assci.Length; i++)
        {
            for (int j = 0; j < compararLetras.Length; j++)
            {
                // si el valor del codigo ascci es igual al valor assci de nuestro array compararLetras entonces tomo el valor de i
                // y se lo sumo a la variable sumaTotal
                if (assci[i] == System.Convert.ToByte(compararLetras[j]))
                {
                    sumaTotal += j + 1;
                    continue;
                }
                // Si el valor del codigo assci es menor al codigo ascci de A o mayor al codigo assci de Z es porque esa palabra
                // no esta en el alfabeto
                if (assci[i] < System.Convert.ToByte(compararLetras[0]) || assci[i] > System.Convert.ToByte(compararLetras[compararLetras.Length - 1]))
                {
                    return sumaTotal = -1;
                }
            }
        }
        return sumaTotal;
    }
}
