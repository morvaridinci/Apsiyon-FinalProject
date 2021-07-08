using Application.Abstract;
using Application.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Concrete.Services
{

    public class CreditCardService : ICreditCardService
    {
        private readonly HttpClient _httpClient;

        public CreditCardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task Login(string userName, string password)
        {
            var json = JsonSerializer.Serialize(new { userName = userName, password = password });
            //_httpClient.DefaultRequestHeaders.Add("content-type", "application/json");
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var uri = new Uri($"{_httpClient.BaseAddress}auth/login");
            var response = await _httpClient.PostAsync(uri, content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var apiResult = JsonSerializer.Deserialize<ApiResult>(result);// "{status:true, token:'ddsdsds'}""

                JwtToken.Token = apiResult.Token;
                JwtToken.ValidDate = DateTime.Now.AddDays(1);
            }



        }
        public async Task<bool> WithdrawMoney(CreditCardDto creditCardDto)
        {

            if (string.IsNullOrWhiteSpace(JwtToken.Token))

            {
                //login
                //token ı ata
                // validdate + 1 gün yap
                await Login("a", "a");
            }

            if (JwtToken.ValidDate < DateTime.Now) await Login("a", "a");

            //geçerlilik tarihi

            string json = JsonSerializer.Serialize(creditCardDto);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {JwtToken.Token}");

            var uri = new Uri($"{_httpClient.BaseAddress}banking/withdrawmoney");

            var response = await _httpClient.PostAsync(uri, content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();

                return bool.Parse(result);
            }

            return false;
        }
    }
}
