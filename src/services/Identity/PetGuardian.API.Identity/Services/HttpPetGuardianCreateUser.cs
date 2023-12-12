using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PetGuadian.Application.Commands.UserCommands;
using PetGuardian.API.Identity.Services.Interfaces;

namespace PetGuardian.API.Identity.Services
{
    public static class HttpPetGuardianCreateUser
    {
        public static async Task<string> CreateUserApi(IdentityUser user)
        {
            var userCommand = new CreateUserCommand(Guid.Parse(user.Id), user.UserName, user.Email, null);

            using (HttpClient client = new HttpClient())
            {
                // Configurar timeout se necessário
                client.Timeout = TimeSpan.FromSeconds(30);

                string json = JsonSerializer.Serialize(userCommand);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var apiLink = new Uri("https://localhost:7057/api/User/create_user");
                    var response = await client.PostAsync(apiLink, content);
                    response.EnsureSuccessStatusCode(); // Lançará uma exceção se a resposta não for bem-sucedida

                    string responseContent = await response.Content.ReadAsStringAsync();
                    // Lógica para lidar com a resposta, se necessário
                    return responseContent;
                }
                catch (HttpRequestException ex)
                {
                    // Lógica para lidar com falhas de solicitação
                    throw new HttpRequestException(ex.Message);
                }
            }
        }
    }
}