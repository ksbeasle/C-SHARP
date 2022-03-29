using GraphQLDemo.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Services.Courses
{
    public class CoursesRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _contextFactory;

        public CoursesRepository(IDbContextFactory<SchoolDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<CourseDTO>> GetAll()
        {
            using (SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Courses
                    .Include(c => c.Instructor)
                    .Include(s => s.Students)
                    .ToListAsync();
            }
        }

        public async Task<CourseDTO> GetById(Guid id)
        {
            using (SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Courses
                    .Include(c => c.Instructor)
                    .Include(s => s.Students)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
        }


        // Should return domain object and not DTO, this is just an example
        public async Task<CourseDTO> Create(CourseDTO course)
        {
            using(SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                context.Courses.Add(course);
                await context.SaveChangesAsync();

                return course;
            }
        }

        // Should return domain object and not DTO, this is just an example
        public async Task<CourseDTO> Update(CourseDTO course)
        {
            using (SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                context.Courses.Update(course);
                await context.SaveChangesAsync();

                return course;
            }
        }

        // Should return domain object and not DTO, this is just an example
        public async Task<bool> Delete(Guid id)
        {
            using (SchoolDbContext context = _contextFactory.CreateDbContext())
            {
                CourseDTO course = new CourseDTO()
                {
                    Id = id
                };
                context.Courses.Remove(course);
                return await context.SaveChangesAsync() > 0;

            }
        }
    }
}
