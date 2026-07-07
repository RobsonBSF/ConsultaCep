using ConsultaCep.Models;
using System.Text.Json;

namespace ConsultaCep.Services
{
    internal class ViaCepService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ViaCepService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = jsonSerializerOptions;
        }

        public async Task<Endereco> BuscarCepAsync(string cep)
        {
            try
            {
                if (cep.Length != 8 || !cep.All(char.IsDigit))
                {
                    throw new ArgumentException("Cep inválido. Deve conter 8 números.");
                }

                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Erro Http: {response.StatusCode}");
                }

                var content = await response.Content.ReadAsStringAsync();

                var endereco = JsonSerializer.Deserialize<Endereco>(content, _jsonSerializerOptions);

                if (endereco == null)
                {
                    throw new Exception("Erro ao converter dados da API.");
                }

                if ("true".Equals(endereco.Erro, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("CEP não encontrado.");
                }

                return endereco;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Erro de conexão com a API: {ex}");
            }
        }
    }
}
