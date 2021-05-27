using System.Threading.Tasks;
using ProcessSystem.Contracts;
using SeedWork.DB;

namespace ProcessSystem.DB
{

    public interface IRegisterRepository : IRepository<Register>
    {
        Task<Register> AddAsync(Register register);
        Task<Register> DeleteAsync(string token);
        Task<Register> FindByTokenAsync(string token);
        Task<Register> FindByChannelAndUrlAsync(Register register);
    }
}
