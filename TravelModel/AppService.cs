
using Newtonsoft.Json;
using System.Text;

namespace TravelModel
{
    public class AppService : IAppSevice
    {
        private string _baseUrl = "http://localhost:5033";
        public async Task<string> AuthenticateUser(LoginDto loginModel)
        {
            var returnStr = string.Empty;
            try
            {
                var url = $"{_baseUrl}{APIs.AuthenticateUser}";
                using var client = new HttpClient();
                var serlizeStr = JsonConvert.SerializeObject(loginModel);
                var response = await client.PostAsync(url, new StringContent(serlizeStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode == true)
                {
                    returnStr = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnStr;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegisterDto registerModel)
        {
            var returnStr = string.Empty;
            bool isSuccess = false;
            try
            {
                var url = $"{_baseUrl}{APIs.RegisterUser}";
                using var client = new HttpClient();
                var serlizeStr = JsonConvert.SerializeObject(registerModel);
                var response = await client.PostAsync(url, new StringContent(serlizeStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode == true)
                {
                    returnStr = await response.Content.ReadAsStringAsync();
                    isSuccess = true;
                }
                else
                {
                    returnStr = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                returnStr = ex.Message;
            }
            return (isSuccess, returnStr);
        }
    }
}
