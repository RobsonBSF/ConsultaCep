using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultaCep.Utils
{
    internal class ArquivoHelper
    {
        private const string FilePath = "historico.txt";

        public static void Salvar(string cep)
        {
            using (var stream = new StreamWriter(FilePath, append: true, Encoding.UTF8))
            {
                stream.WriteLine($"{cep} - {DateTime.Now}");
            }
        }

        public static List<string> LerHistorico()
        {
            if (!File.Exists(FilePath))
            {
                return new List<string>();
            }

            var linhas = File.ReadAllLines(FilePath);
            return linhas.ToList();
        }
    }
}
