using VerstaTask.Models;
using VerstaTask.Models.Dtos;

namespace VerstaTask.Services.Interfaces
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(ApiRequest apiRequest);
    }
}
