using System;
using System.Text;

namespace MeuAppConsole
{
    public class Aritmetica
    {
        public string Divisao(string inteiroDividendo, string fracaoDividendo, string inteiroDivisor, string fracaoDivisor, string digitos)
        {
            int tamanhoFracao = fracaoDividendo.Length;
            int tamanhoInteiro = inteiroDividendo.Length;
            if (fracaoDivisor.Length > fracaoDividendo.Length) tamanhoFracao = fracaoDivisor.Length;
            if (inteiroDivisor.Length > inteiroDividendo.Length) tamanhoInteiro = inteiroDivisor.Length;

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
            int posQuociente = posDividendo - posDivisor;

            for (int i = 0; i > posQuociente; i--)
            {
                quociente.Append("0");
            }

            Console.WriteLine(posQuociente);

            return quociente.ToString();
        }
    }
}