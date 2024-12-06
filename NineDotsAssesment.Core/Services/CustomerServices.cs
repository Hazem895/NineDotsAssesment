using FluentValidation;
using NineDotsAssesment.Core.Services.Interface;
using NineDotsAssesment.Domain.Entities;
using NineDotsAssesment.Domain.IRepository;
using NineDotsAssesment.Shared.DTO;
using NineDotsAssesment.Shared.Helpers;
using NineDotsAssesment.Shared.Models;
using System.Net;

namespace NineDotsAssesment.Core.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICrudCommandsRepository<Customer> _repo;
        private readonly IValidator<CustomerDTO> _validator;
        private readonly IValidator<ConfirmPINModel> _pinValidator;
        public CustomerServices(ICrudCommandsRepository<Customer> repo,
            IValidator<CustomerDTO> validator, IValidator<ConfirmPINModel> pinValidator)
        {
            this._repo = repo;
            _validator = validator;
            _pinValidator = pinValidator;
        }
        public async Task<MigratedAccountResponse> MigrateNewUser(string ic)
        {
            Customer? customer = await _repo.ReadByIC(ic);
            if (customer == null)
            {
                return new()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Response = "No Account registered"
                };
            }

            return new()
            {
                StatusCode = HttpStatusCode.OK,
                Response = customer.Id.ToString()
            };
        }
        public async Task<ResponseModel> ConfirmPIN(ConfirmPINModel confirmPINModel)
        {
            var validateinputResult = await Helper.ValidateInput(confirmPINModel, _pinValidator);

            if (!validateinputResult.IsValid)
            {
                return new()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Response = string.Join(",", validateinputResult.Errors.Select(x => $"Invalid {x.PropertyName}, Error: {x.ErrorMessage}"))
                };
            }

            GetCustomerResponse customerResponse = await GetCustomerById(confirmPINModel.Id);
            string hashedPIN = Helper.HashPIN(confirmPINModel.PIN);
            customerResponse.Customer.UpdateWithPIN(hashedPIN);

            await _repo.Update(customerResponse.Customer.ToEntity());

            return new()
            {
                StatusCode = HttpStatusCode.OK
            };


        }
        public async Task<RegisterationProcessResponse> RegisterAccount(CustomerDTO customerDTO)
        {
            var ICChecker = await CheckIC(customerDTO.IC);
            if (ICChecker.Exist)
            {
                return new()
                {
                    StatusCode = HttpStatusCode.Conflict,
                    Response = "Account already exist"
                };
            }

            var validateinputResult = await Helper.ValidateInput(customerDTO, _validator);
            if (!validateinputResult.IsValid)
            {
                return new()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ValidationErrors = validateinputResult.Errors
                };
            }



            Customer customer = customerDTO.ToEntity();

            customer.Id = Guid.NewGuid();
            customer.Verified = false;

            await _repo.Create(customer);

            return new()
            {
                StatusCode = HttpStatusCode.OK,
                Response = customer.Id.ToString()
            };
        }
        public async Task<GetCustomerResponse> GetCustomerById(Guid id)
        {
            Customer? customer = await _repo.ReadById(id);
            if (customer is null)
            {
                return new()
                {
                    StatusCode = HttpStatusCode.NotFound
                };

            }
            return new()
            {
                StatusCode = HttpStatusCode.OK,
                Customer = customer.ToDTO()
            };
        }
        public async Task<ICExistResponse> CheckIC(string IC)
        {
            Customer? customer = await _repo.ReadByIC(IC);
            if (customer != null)
            {
                return new()
                {
                    Exist = true,
                    Verified = customer.Verified
                };
            }
            return new() { Exist = false };
        }
    }
}
