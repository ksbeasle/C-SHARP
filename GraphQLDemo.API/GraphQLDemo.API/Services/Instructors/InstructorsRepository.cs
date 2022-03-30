using GraphQLDemo.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Services.Instructors
{
    public class InstructorsRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _contextFactory;

        public InstructorsRepository(IDbContextFactory<SchoolDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<InstructorDTO> GetById(Guid id)
        {
            using (SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Instructors
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
        }

        public async Task<IEnumerable<InstructorDTO>> GetManyByIds(IReadOnlyList<Guid> ids)
        {
            using (SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Instructors
                    .Where(i => ids.Contains(i.Id))
                    .ToListAsync();
            }
        }
    }
}
