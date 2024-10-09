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
            int posDividendoAnterior = -1;
            int posDivisor = -1;
            for (int i = 0; i < dividendo.Length; i++)
            {
                if (dividendo[i] != 0)
                {
                    posDividendo = i;
                    posDividendoAnterior = posDividendo - 1;
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

                int qct = (dividendo[posDividendoAnterior] * 10 + dividendo[posDividendo]) / divisor[posDivisor];
                if (qct > 9)
                {
                    for (int i = 2; i < dividendo.Length + 1; i++)
                    {
                        int posDividendoTmp = posDividendo - i;
                        if (posDividendoTmp < 0) posDividendoTmp = dividendo.Length + posDividendoTmp;
                        int posDividendoAnteriorTmp = posDividendoTmp - 1;
                        if (posDividendoAnteriorTmp < 0) posDividendoAnteriorTmp = dividendo.Length - 1;
                        if (dividendo[posDividendoTmp] < 0)
                        {
                            int tmp = dividendo[posDividendoTmp] + 10;
                            dividendo[posDividendoTmp] = (sbyte)tmp;
                            tmp = dividendo[posDividendoAnteriorTmp] - 1;
                            dividendo[posDividendoAnteriorTmp] = (sbyte)tmp;
                        }
                    }
                    qct = 9;
                }
                int rst = dividendo[posDividendoAnterior] * 10 + dividendo[posDividendo] - divisor[posDivisor] * qct;

                dividendo[posDividendoAnterior] = 0;
                dividendo[posDividendo] = (sbyte)rst;

                while (rst == 0)
                {
                    dividendoZero++;
                    if (dividendoZero > dividendo.Length)
                    {
                        Console.WriteLine("break");
                        break;
                    }
                    posQuociente++;
                    posDividendoAnterior = posDividendo;
                    posDividendo++;
                    if (posDividendo == dividendo.Length) posDividendo = 0;
                    continue;
                }
                while (dividendoZero > 0)
                {
                    dividendoZero--;
                    quociente.Append("0");
                }
                Console.WriteLine(rst);
                for (int i = 1; i < dividendo.Length; i++)
                {
                    int posDividendoMovel = posDividendo + i;
                    if (posDividendoMovel >= dividendo.Length) posDividendoMovel = posDividendoMovel - dividendo.Length;
                    int posDivisorMovel = posDivisor + i;
                    if (posDivisorMovel >= divisor.Length) posDivisorMovel = posDivisorMovel - divisor.Length;
                    int restoAcima = (dividendo[posDividendoMovel] - (divisor[posDivisorMovel] * qct)) / 10;
                    int novoDvd = (dividendo[posDividendoMovel] - (divisor[posDivisorMovel] * qct)) % 10;
                    if (rst == 0)
                    {
                        rst = rst + novoDvd;
                        if (rst < 0)
                        {

                        }
                    }
                    dividendo[posDividendoMovel] = (sbyte)novoDvd;
                    Console.WriteLine(novoDvd + " " + posDivisorMovel + " " + posDividendoMovel);

                    int j = -1;
                    while (restoAcima > 0)
                    {
                        int posDividendoRetorno = posDividendoMovel + j;
                        if (posDividendoRetorno < 0) posDividendoRetorno = dividendo.Length;
                        //int posDivisorRetorno = (j + i + posDivisor) % divisor.Length;
                        restoAcima = (dividendo[posDividendoRetorno] + restoAcima) / 10;
                        novoDvd = (dividendo[posDividendoRetorno] + restoAcima) % 10;
                        dividendo[posDividendoRetorno] = (sbyte)novoDvd;
                        j--;
                    }
                }
                Console.WriteLine(qct);
                if (qct >= 0)
                {
                    posQuociente++;
                    quociente.Append("0");
                }

                qct = qct + (quociente[quociente.Length - 2] - '0');
                Console.WriteLine("numero: " + qct);
                quociente[quociente.Length - 2] = (char)(qct + '0');

                posDividendoAnterior = posDividendo;
                posDividendo = posDividendo + 1;
                if (posDividendo == dividendo.Length) posDividendo = 0;

            }
            while (posQuociente <= fracaoDigitos);

            Console.WriteLine(posQuociente);
            // if (posQuociente > 0) quociente.Insert(quociente.ToString().Length - posQuociente+1, "."); //inserir ponto decimal, se necessário

            return quociente.ToString();
        }
    }
}