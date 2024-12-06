using NineDotsAssesment.Shared.DTO;

namespace NineDotsAssesment.Shared.Models
{
    public class GetCustomerResponse : ResponseModel
    {
        public CustomerDTO Customer { get; set; }
    }
}
