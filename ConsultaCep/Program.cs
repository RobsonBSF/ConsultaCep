using ConsultaCep.Services;
using ConsultaCep.Utils;
using ConsultaCep.Views;
using System.Text.Json;

namespace ConsultaCep
{
    class Program
    {
        static async Task Main(string[] args)
        {
            JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
            HttpClient httpClient = new();

            ViaCepService service = new(httpClient, jsonSerializerOptions);
            ArquivoHelper arquivoHelper = new();

            Menu menu = new(service, arquivoHelper);

            await menu.ExibirMenu();
        }
    }
}