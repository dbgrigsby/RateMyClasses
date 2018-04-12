using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RateMyClasses.Models
{
    public interface IDbContext
    {
        DbSet<Review> Review { get; set; }
        Task<int> SaveChangesAsync();

        void Add(Review review);

        void Update(Review review);
    }

    public class ReviewContext : DbContext, IDbContext
    {
        //public ReviewContext(DbContextOptions<ReviewContext> options)
        //: base(options)
        //{
        //}

        public virtual DbSet<Review> Review { get; set; }

        public void Add(Review review)
        {
            base.Add(review);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public void Update(Review review)
        {
            base.Update(review);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=RateMyClasses.db");

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                var connectionString = ("Data Source=RateMyClasses.db");
                optionsBuilder.UseSqlite(connectionString);
            }
        }*/
    }

    /*
    public static class DbSetMocking
    {
        private static Mock<DbSet<T>> CreateMockSet<T>(IQueryable<T> data)
                where T : class
        {
            var queryableData = data.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider)
                    .Returns(queryableData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression)
                    .Returns(queryableData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType)
                    .Returns(queryableData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator())
                    .Returns(queryableData.GetEnumerator());
            return mockSet;
        }

        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                TEntity[] entities)
            where TEntity : class
            where TContext : DbContext
        {
            var mockSet = CreateMockSet(entities.AsQueryable());
            return setup.Returns(mockSet.Object);
        }

        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                IQueryable<TEntity> entities)
            where TEntity : class
            where TContext : DbContext
        {
            var mockSet = CreateMockSet(entities);
            return setup.Returns(mockSet.Object);
        }

        public static IReturnsResult<TContext> ReturnsDbSet<TEntity, TContext>(
                this IReturns<TContext, DbSet<TEntity>> setup,
                IEnumerable<TEntity> entities)
            where TEntity : class
            where TContext : DbContext
        {
            var mockSet = CreateMockSet(entities.AsQueryable());
            return setup.Returns(mockSet.Object);
        }
    }
    */
}