using ConsultaCepApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ConsultaCepApi.Services
{
    internal class ViaCepService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ViaCepService()
        {
            _httpClient = new HttpClient();
            _jsonSerializerOptions = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
        }

        public async Task<Endereco> BuscarCepAsync(string cep)
        {
            try
            {
                if (cep.Length != 8 || !cep.All(char.IsDigit))
                {
                    throw new ArgumentException("Cep inválido. deve conter 8 números.");
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

                if (endereco.Erro)
                {
                    throw new Exception("Cep não encontrado.");
                }

                return endereco;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Erro de conexão com a API");
            }
        }
    }
}
