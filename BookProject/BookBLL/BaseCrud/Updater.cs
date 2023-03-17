using AutoMapper;
using BookBLL.Interfaces;
using BookDAL.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using BookDAL.Context;

namespace BookBLL.BaseCrud
{

    public class Updater<Entity, UpdateDto> : IUpdater<UpdateDto>
        where Entity : class, IEntity
        where UpdateDto : class
    {
        private readonly IBookContext context;
        private readonly IValidator<UpdateDto> validator;
        private readonly IMapper mapper;

        public Updater(IBookContext context,
            IValidator<UpdateDto> validator,
            IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task Update(UpdateDto updateDto, CancellationToken token = default)
        {
            await validator.Validate(updateDto);

            var entity = mapper.Map<Entity>(updateDto);

            var entry = await Task.Factory.StartNew(() => context.Set<Entity>().Update(entity), token);

            await context.SaveChangesAsync(token);
        }
    }
}
