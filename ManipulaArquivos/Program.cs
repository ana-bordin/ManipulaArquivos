using System.Security.Cryptography;

namespace ManipulaArquivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+"\\Dados\\";
            /*@"C:\Dados\"; ou simplesmente: "C:\\Dados\\"*/
            string path = @"C:\Dados\";
            string file = "arquivo.txt";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path + file);
            }
            if (!File.Exists(path + file))
            {
                StreamWriter sw = new(path + file);
                sw.Close();
            }

            else
            {
                StreamReader sr = new StreamReader(path + file);
                string s = sr.ReadToEnd();
                sr.Close();

                Console.WriteLine(s);

                //Console.WriteLine("Escreva algo:");
                //s += "\n";
                //s += Console.ReadLine();

                StreamWriter sw = new(path + file);
                sw.WriteLine(s);
                sw.Close();

                Console.Clear();
                Console.WriteLine("Conteudo da terceira linha do arquivo:");
                var retorno = File.ReadLines(path + file).ElementAt(2);
                Console.WriteLine(retorno);
                int item = 0;
                
                foreach (string line in File.ReadLines(path + file))
                {
                    item++;
                    if (item == 3)
                        Console.WriteLine(line);
                }
                
                var retorno2 = File.ReadLines(path + file).Skip(2).Take(1).First();
                Console.WriteLine(retorno2);
            }
        }
    }
}

