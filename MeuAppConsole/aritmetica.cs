using System;
using System.Text;

namespace MeuAppConsole
{
    public class Aritmetica
    {
        public string Divisao(string inteiroDividendo, string fracaoDividendo, string inteiroDivisor, string fracaoDivisor, int fracaoDigitos)
        {
            int tamanhoFracao = fracaoDividendo.Length;
            int tamanhoInteiro = inteiroDividendo.Length;
            if (fracaoDivisor.Length > fracaoDividendo.Length) tamanhoFracao = fracaoDivisor.Length;
            if (inteiroDivisor.Length > inteiroDividendo.Length) tamanhoInteiro = inteiroDivisor.Length;
            tamanhoInteiro++;
            StringBuilder quociente = new StringBuilder("0");
            sbyte[] dividendo = new sbyte[tamanhoInteiro + tamanhoFracao];
            sbyte[] divisor = new sbyte[tamanhoInteiro + tamanhoFracao];
            for (int i = 0; i < inteiroDividendo.Length; i++)
                dividendo[tamanhoInteiro - 1 - i] = sbyte.Parse(inteiroDividendo[inteiroDividendo.Length - 1 - i].ToString());
            for (int i = 0; i < inteiroDivisor.Length; i++)
                divisor[tamanhoInteiro - 1 - i] = sbyte.Parse(inteiroDivisor[inteiroDivisor.Length - 1 - i].ToString());
            for (int i = 0; i < fracaoDividendo.Length; i++)
                dividendo[tamanhoInteiro + i] = sbyte.Parse(fracaoDividendo[i].ToString());
            for (int i = 0; i < fracaoDivisor.Length; i++)
                divisor[tamanhoInteiro + i] = sbyte.Parse(fracaoDivisor[i].ToString());
            int posDividendo = -1;
            int posDivisor = -1;
            for (int i = 0; i < dividendo.Length; i++)
            {
                if (dividendo[i] != 0)
                {
                    posDividendo = i;
                    break;
                }
            }
            for (int i = 0; i < divisor.Length; i++)
            {
                if (divisor[i] != 0)
                {
                    posDivisor = i;
                    break;
                }
            }
            if (posDivisor == -1) { return "Divisão por zero"; }
            if (posDividendo == -1) { return "0"; }

            int posQuociente = posDividendo - posDivisor; //se maior que zero, somente casas decimais
            for (int i = 0; i < posQuociente; i++) //se o quociente for apenas fração 
            {
                quociente.Append("0");
            }

            int dividendoZero = 0;
            do
            {

                int qct = (dividendo[posDividendo - 1] * 10 + dividendo[posDividendo]) / divisor[posDivisor];
                int rst = (dividendo[posDividendo - 1] * 10 + dividendo[posDividendo]) % divisor[posDivisor];
            Console.WriteLine(dividendo[posDividendo]);
            Console.WriteLine(divisor[posDivisor]);
                if (qct == 0)
                {
                    dividendoZero++;
                    if (dividendoZero > dividendo.Length) break;
                    posQuociente++;
                    posDividendo++;
                    posDividendo = posDividendo % dividendo.Length;
                    continue;
                }
                while (dividendoZero > 0)
                {
                    dividendoZero--;
                    quociente.Append("0");
                }
                dividendo[posDividendo - 1] = 0;
                dividendo[posDividendo] = (sbyte)rst;
                for (int i = 1; i < dividendo.Length - 1; i++)
                {
                    int posDividendoMovel = (i + posDividendo) % dividendo.Length;
                    int posDivisorMovel = (i + posDivisor) % divisor.Length;
                    int restoAcima = (dividendo[posDividendoMovel] - (divisor[posDivisorMovel] * qct)) / 10;
                    int novoDvd = (dividendo[posDividendoMovel] - (divisor[posDivisorMovel] * qct)) % 10;
                    dividendo[posDividendoMovel] = (sbyte)novoDvd;
                    int j = -1;
                    while (restoAcima > 0)
                    {
                        int posDividendoRetorno = (j + i + posDividendo) % dividendo.Length;
                        //int posDivisorRetorno = (j + i + posDivisor) % divisor.Length;
                        restoAcima = (dividendo[posDividendoRetorno] + restoAcima) / 10;
                        novoDvd = (dividendo[posDividendoRetorno] + restoAcima) % 10;
                        dividendo[posDividendoRetorno] = (sbyte)novoDvd;
                        j--;
                    }
                }
            Console.WriteLine((char)qct);
            Console.WriteLine(qct);
                quociente[quociente.Length - 1] = (char)qct;
                posDividendo = posDividendo++ % dividendo.Length;

            }
            while (posQuociente < fracaoDigitos);

           // if (posQuociente > 0) quociente.Insert(quociente.ToString().Length - posQuociente, "."); //inserir ponto decimal, se necessário
            Console.WriteLine(posQuociente);

            return quociente.ToString();
        }
    }
}