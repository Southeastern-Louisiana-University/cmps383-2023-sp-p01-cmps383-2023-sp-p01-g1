using AutoMapper;
using FA22.P02.Web.Data;
using FA22.P02.Web.Dtos;
using FA22.P02.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SP23.P01.Web.Exceptions;

namespace FA22.P02.Web.Respositories
{
    public class GenericRepository<TDto, TEntity> : IGenericRepository<TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

       

        public GenericRepository(DataContext context) 
        {
            this.context = context;

            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<TDto, TEntity>();
            cfg.CreateMap<TEntity, TDto>();
            var config = new MapperConfiguration(cfg);

            this.mapper = config.CreateMapper();
        }

        public async Task<TDto> Create(TDto dto)
        {

            var entity = mapper.Map<TEntity>(dto);
            
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            var dtoReturn = mapper.Map<TDto>(entity);
            dtoReturn.Id = entity.Id;
            
            return dtoReturn; 
        }

        public async Task Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
            return;
        }

        public async Task<List<TDto>> GetAll()
        {
            var entities = await context.Set<TEntity>().ToListAsync();
            var dtos = new List<TDto>();

            foreach (var entity in entities)
            {
                var dto = mapper.Map<TDto>(entity);
                dto.Id = entity.Id;
                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<TDto> GetById(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
           
            if (entity != null)
            {
                var dto =  mapper.Map<TDto>(entity);
                dto.Id = entity.Id;
                return dto;
            }
            throw new NotFoundException("Train Station not found!");
        }

        public async Task Update(TDto dto)
        {
            var original = await context.Set<TEntity>().FindAsync(dto.Id);
            if (original != null)
            {
                var entity = mapper.Map<TEntity>(dto);
                var valuesMap = mapper.Map(original, entity);
                context.Set<TEntity>().Update(valuesMap);
            }
        }
    }
}
