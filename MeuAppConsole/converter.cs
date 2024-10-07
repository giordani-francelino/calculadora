using System;
using System.Text;


namespace MeuAppConsole
{

    public class Converter
    {
        public Converter()
        {
        }

        public string DecimalBinarioInteiro(string inteiroDecimal)
        {

            StringBuilder inteiroBinario = new StringBuilder("");
            //inteiroBinario.Insert(0, "Novo texto ");
            int i = 0;
            int k = 0;
            sbyte[] valores = new sbyte[inteiroDecimal.Length];
            if (inteiroDecimal[0] == '-') i = 1;
            for (int j = i; j < inteiroDecimal.Length; j++)
                valores[j] = sbyte.Parse(inteiroDecimal[j].ToString());

            while (i < inteiroDecimal.Length)
            {
                sbyte bit = 0;
                if (valores[inteiroDecimal.Length - 1] % 2 == 1) bit = 1;
                inteiroBinario.Append(bit);
                int resto = 0;
                for (int j = i; j < inteiroDecimal.Length; j++)
                {
                    // Console.WriteLine(valores[j]);
                    int soma = valores[j] / 2 + resto;
                    resto = (valores[j] % 2 == 1) ? 5 : 0;
                    valores[j] = (sbyte)soma;

                    if (valores[j] == 0 && j == i) i++;
                }
                k++;
                //Console.WriteLine("fim-" + k + " - " + bit);

            }
            float f = (float)k / (float)inteiroDecimal.Length;
            Console.WriteLine("proporcao-" + f);

            if (inteiroDecimal[0] == '-') inteiroBinario.Append("-");


            string resultado = new string(inteiroBinario.ToString().Reverse().ToArray());

            Console.WriteLine(resultado);

            return resultado;
        }

        public string DecimalBinarioFracao(string fracaoDecimal)
        {

            StringBuilder fracaoBinario = new StringBuilder("");
            //fracaoBinario.Insert(0, "Novo texto ");
            int i = 0;
            int k = 0;
            sbyte[] valores = new sbyte[fracaoDecimal.Length];
            if (fracaoDecimal[0] == '-') i = 1;
            for (int j = i; j < fracaoDecimal.Length; j++)
                valores[fracaoDecimal.Length - 1 - j] = sbyte.Parse(fracaoDecimal[j].ToString());

            while (i < fracaoDecimal.Length && k < fracaoDecimal.Length * 20) // &&
                                                                              //fracaoBinario.ToString()[fracaoBinario.ToString().Length-1] == '0')
            {
                sbyte bit = 0;
                int resto = 0;

                for (int j = i; j < fracaoDecimal.Length; j++)
                {
                    //Console.WriteLine(valores[j]);
                    int soma = valores[j] * 2 + resto;
                    resto = soma / 10;
                    soma = soma % 10;
                    valores[j] = (sbyte)soma;

                    if (valores[j] == 0 && j == i) i++;
                    Console.WriteLine("fim-" + i + " - " + soma);
                }
                k++;
                if (resto == 1) bit = 1;
                Console.WriteLine("fim-" + k + " - " + bit);
                fracaoBinario.Append(bit);

            }
            float f = (float)k / (float)fracaoDecimal.Length;
            //Console.WriteLine("proporcao-" + f);

            if (fracaoDecimal[0] == '-') fracaoBinario.Append("-");


            string resultado = fracaoBinario.ToString();

            Console.WriteLine(resultado);

            return resultado;
        }

    }
}