using System.Security.AccessControl;
using static VerstaTask.SD;

namespace VerstaTask.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }
        public string Url { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
