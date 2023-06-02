using Newtonsoft.Json;
using System.Text;
using VerstaTask.Models.Dtos;
using VerstaTask.Models;
using VerstaTask.Services.Interfaces;

namespace VerstaTask.Services
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory HttpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<ResponseDto> SendAsync(ApiRequest apiRequest)
        {
            try
            {
                var client = HttpClient.CreateClient("KostaAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8,
                        "application/json");
                }
                HttpResponseMessage apiResponse;
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
					//case SD.ApiType.PUT:
					//    message.Method = HttpMethod.Put;
					//    break;
					//case SD.ApiType.DELETE:
					//    message.Method = HttpMethod.Delete;
					//    break;
					default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                if (!apiResponse.IsSuccessStatusCode)
                    throw new Exception(apiContent);

                var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = "API request error!",
                    ErrorMessages = new List<string> { ex.Message },
                    IsSuccess = false
                };
                return dto;
            }
        }
    }
}
