using System.Text;

namespace ConsultaCep.Utils
{
    internal class ArquivoHelper
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "historico.txt");

        public void Salvar(string cep)
        {
            try
            {
                using var stream = new StreamWriter(FilePath, append: true, Encoding.UTF8);
                stream.WriteLine($"{cep} - {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC");
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> LerHistorico()
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
