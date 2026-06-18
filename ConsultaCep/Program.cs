using ConsultaCep.Services;
using ConsultaCep.Models;
using ConsultaCep.Utils;

namespace ConsultaCep
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ViaCepService service = new ViaCepService();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("[1] - Consultar CEP.");
                Console.WriteLine("[2] - Ver Histórico.");
                Console.WriteLine("[3] - Sair.");

                Console.Write("Opção: ");

                string answer = Console.ReadLine();

                Console.Clear();

                switch (answer)
                {
                    case "1":
                        try
                        {
                            Console.Write("Digite o CEP: ");
                            string cep = Console.ReadLine();

                            var endereco = await service.BuscarCepAsync(cep);

                            Console.WriteLine();
                            Console.WriteLine($"CEP --------> {endereco.Cep}");
                            Console.WriteLine($"Logradouro -> {endereco.Logradouro}");
                            Console.WriteLine($"Bairro -----> {endereco.Bairro}");
                            Console.WriteLine($"Cidade -----> {endereco.Localidade}");
                            Console.WriteLine($"UF ---------> {endereco.Uf}");

                            try
                            {
                                ArquivoHelper.Salvar(cep);
                            }
                            catch
                            {
                                Console.WriteLine("Erro ao salvar histórico");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        break;
                    case "2":
                        var historico = ArquivoHelper.LerHistorico();

                        if (historico.Count == 0)
                        {
                            Console.WriteLine("Nenhum CEP consultado ainda.");
                        }
                        else
                        {
                            Console.WriteLine("Histórico de consultas: ");
                            Console.WriteLine($"Número de registros: {historico.Count}\n");

                            foreach (var item in historico)
                            {
                                Console.WriteLine($"- {item}");
                            }
                        }
                        break;
                    case "3":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.Write("\npressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}