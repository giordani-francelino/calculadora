using System;
using System.Text;


namespace MeuAppConsole
{

    public class Converter
    {
        public Converter()
        {
        }

        public string DecimalBinarioInteiro(string numeroDecimal)
        {

            StringBuilder numeroBinario = new StringBuilder("");
            //numeroBinario.Insert(0, "Novo texto ");
            int i = 0;
            int soma = 0;
            sbyte[] valores = new sbyte[numeroDecimal.Length];
            if (numeroDecimal[0] == '-')
            {
                i = 1;
                numeroBinario.Append("-");
            }
            for (int j = i; j < numeroDecimal.Length; j++)
            {
                //string s = numeroDecimal[j].ToString
                valores[j] = sbyte.Parse(numeroDecimal[j].ToString());

            }

            while (valores[i] != 0)
            {
                for (int j = i; j < numeroDecimal.Length - 1; j++)
                {
                    if (valores[j] % 2 == 1)
                    {
                        soma = valores[j] + 5;
                        valores[j] = (sbyte)soma;
                    }

                    soma = valores[j] / 2;
                    valores[j] = (sbyte)soma;

                    if (valores[j] == 0)
                    {
                        soma = valores[j] + 1;
                        i = (sbyte)soma;
                    }
                }
            }
            while (valores[numeroDecimal.Length] != 0)
            {
                if (valores[numeroDecimal.Length] % 2 == 1) numeroBinario.Append("1");
                else numeroBinario.Append("0");
                soma = valores[numeroDecimal.Length] / 2;
                valores[numeroDecimal.Length] = (sbyte)soma;
            }


            string resultado = numeroBinario.ToString();
            Console.WriteLine(resultado);


            return numeroBinario.ToString();
        }

    }
}