using Microsoft.EntityFrameworkCore;
using NineDotsAssesment.Domain.Entities;
using NineDotsAssesment.Domain.IRepository;
using NineDotsAssesment.Shared.Helpers;

namespace NineDotsAssesment.Infrastructure.Sql.Repository.DriversRepository
{
    public class CustomerRepository : ICrudCommandsRepository<Customer>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Customer> _DriversSet;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
            _DriversSet = _context.Customers;
        }

        public async Task<string> Create(Customer Input)
        {
            await _DriversSet.AddAsync(Input);

            await _context.SaveChangesAsync();

            return $"{Input.Id} Added Successfully";
        }

        public async Task<string> Delete(Guid ID)
        {
            Customer? record = await ReadById(ID);
            if (record != null)
            {
                _DriversSet.Remove(record);

                await _context.SaveChangesAsync();

                return $"{ID} deleted Successfully";
            }
            else
            {
                throw new Exception("Not Exist");

            }
        }

        public async Task<List<Customer>> ReadAll()
        {
            return await _DriversSet.ToListAsync();
        }

        public async Task<Customer?> ReadByIC(string ic)
        {
            return await _DriversSet.FirstOrDefaultAsync(x => x.IC == ic);
        }

        public async Task<Customer?> ReadById(Guid id)
        {
            return await _DriversSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Customer input)
        {
            try
            {
                Customer? customer = await _DriversSet.FirstOrDefaultAsync(b => b.Id == input.Id);
                if (customer != null)
                {
                    customer.ToUpdateEntity(input);
                    _context.Update(customer);
                    await _context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
