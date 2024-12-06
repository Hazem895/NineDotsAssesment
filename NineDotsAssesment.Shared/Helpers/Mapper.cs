using NineDotsAssesment.Domain.Entities;
using NineDotsAssesment.Shared.DTO;

namespace NineDotsAssesment.Shared.Helpers
{
    public static class Mapper
    {
        public static CustomerDTO ToDTO(this Customer customer)
        {
            return new()
            {
                Id = customer.Id,
                Name = customer.Name,
                IC = customer.IC,
                Mobile = customer.Mobile,
                Email = customer.Email,
                PIN = customer.PIN,
                Verified = customer.Verified
            };
        }

        public static Customer ToEntity(this CustomerDTO dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                IC = dto.IC,
                Mobile = dto.Mobile,
                Email = dto.Email,
                PIN = dto.PIN,
                Verified = dto.Verified
            };
        }

        public static CustomerDTO UpdateWithPIN(this CustomerDTO entity, string pin)
        {

            entity.PIN = pin;
            entity.Verified = true;
            return entity;
        }

        public static Customer ToUpdateEntity(this Customer record, Customer input)
        {
            record.Name = input.Name;
            record.IC = input.IC;
            record.Mobile = input.Mobile;
            record.Email = input.Email;
            record.PIN = input.PIN;
            record.Verified = input.Verified;
            return record;

        }
    }
}