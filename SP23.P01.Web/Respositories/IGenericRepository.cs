using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FA22.P02.Web.Respositories
{
    public interface IGenericRepository<TDto>
    {
        Task<List<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task<TDto> Create(TDto dto);
        Task<TDto> Update(int id, TDto dto);
        Task Delete(int id);
    }
}
