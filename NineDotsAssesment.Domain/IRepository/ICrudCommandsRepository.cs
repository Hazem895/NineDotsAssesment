using NineDotsAssesment.Domain.Entities;

namespace NineDotsAssesment.Domain.IRepository
{
    public interface ICrudCommandsRepository<T> where T : class
    {
        Task<string> Create(T Input);
        Task<List<T>> ReadAll();
        Task<Customer?> ReadByIC(string ic);
        Task<Customer?> ReadById(Guid id);
        Task<bool> Update(T Input);
        Task<string> Delete(Guid ID);
    }
}
