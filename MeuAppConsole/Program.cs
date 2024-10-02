


namespace MeuAppConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Converter c = new Converter();
            Console.WriteLine(c.DecimalBinarioInteiro("11"));
            Console.WriteLine(c.DecimalBinarioFracao("00000000000000000984375"));
        }

    }
}

//281018792484564845846
//2810187924845648458461
