using NineDotsAssesment.Shared.DTO;
using NineDotsAssesment.Shared.Models;

namespace NineDotsAssesment.Core.Services.Interface
{
    public interface ICustomerServices
    {
        Task<RegisterationProcessResponse> RegisterAccount(CustomerDTO customer);
        Task<ResponseModel> ConfirmPIN(ConfirmPINModel confirmPINModel);
        Task<GetCustomerResponse> GetCustomerById(Guid id);
        Task<MigratedAccountResponse> MigrateNewUser(string ic);
    }
}
