using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Model;

namespace ldtiep.be.DL.Repository
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        Task<List<object>> GetChats();
    }
}
