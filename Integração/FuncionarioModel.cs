using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Polly;
using RestSharp;

namespace Integração
{
    internal class FuncionarioModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("pis")]
        public string? Pis { get; set; }

        [JsonPropertyName("referencia")]
        public string? Referencia { get; set; }

        [JsonPropertyName("telefone")]
        public string? Telefone { get; set; }



        // Metodo Buscar
        // faz uma requisição HTTP assíncrona para obter uma lista de funcionários 
        // lê a resposta como uma string JSON, desserializa essa string em uma lista de objetos FuncionarioModel
        public async Task<List<FuncionarioModel>> ObterFuncionarioModelsAsync()
        {
            using HttpClient httpClient = new()
            {
                BaseAddress = new Uri("https://localhost:7169/")
            };

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("/api/funcionarios");
                string responseJson = await response.Content.ReadAsStringAsync();

                List<FuncionarioModel> funcionarios = JsonSerializer.Deserialize<List<FuncionarioModel>>(responseJson)
                    ?? throw new Exception($"Não foi possível desserializar o conjunto de funcionários do sistema Cronos.");

                return funcionarios;
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve uma falha ao obter os funcionários. Erro: {ex.Message}");
            }



            //var client = new RestClient();
            //var request = new RestRequest("https://localhost:7169/api/Funcionarios", Method.Get);

            //RestResponse response = await client.ExecuteAsync(request);

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)

            //    return JsonConvert.DeserializeObject<List<FuncionarioModel>>(response.Content);

            //else
            //    return null;
        }


        // enviar uma lista de objetos FuncionarioModel
        //serializa uma coleção de objetos FuncionarioModel em JSON e os envia via HTTP POST
        public async Task<IEnumerable<FuncionarioModel>> EnviarFuncionariosAsync(IEnumerable<FuncionarioModel> funcionarios)
        {
            using HttpClient httpClient = new()
            {
                BaseAddress = new Uri("https://localhost:7196/")
            };

            try
            {
                StringContent content = new(
                    content: JsonSerializer.Serialize(funcionarios),
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                HttpResponseMessage response = await httpClient.PostAsync("/api/funcionarios", content);

                response.EnsureSuccessStatusCode();

                return funcionarios;
            }
            catch (Exception ex)
            {
                throw new Exception($"Houve uma falha ao criar uma lista de funcionários. Erro: {ex.Message}");
            }
        }
    }


}