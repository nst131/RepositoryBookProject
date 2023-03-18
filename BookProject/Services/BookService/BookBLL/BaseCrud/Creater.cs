using AutoMapper;
using BookBLL.Interfaces;
using BookDAL.Context;
using BookDAL.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace BookBLL.BaseCrud
{
    public class Creater<Entity, CreateDto> : ICreater<CreateDto>
        where Entity : class, IEntity
        where CreateDto : class
    {
        private readonly IBookContext context;
        private readonly IValidator<CreateDto> validator;
        private readonly IMapper mapper;

        public Creater(IBookContext context,
            IValidator<CreateDto> validator,
            IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<int> Create(CreateDto createDto, CancellationToken token = default)
        {
            await validator.Validate(createDto);

            var entity = mapper.Map<Entity>(createDto);

            await context.Set<Entity>().AddAsync(entity, token);

            await context.SaveChangesAsync(token);

            return entity.Id;
        }
    }
}
