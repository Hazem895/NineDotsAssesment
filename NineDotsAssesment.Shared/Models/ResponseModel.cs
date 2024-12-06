using System.Net;

namespace NineDotsAssesment.Shared.Models
{
    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Response { get; set; }
    }
}
