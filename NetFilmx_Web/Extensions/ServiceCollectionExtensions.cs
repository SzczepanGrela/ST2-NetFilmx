using NetFilmx_Storage;
using NetFilmx_Storage.Repositories;
using System.Reflection;

namespace NetFilmx_Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNetFilmxServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddTransient<IVideoRepository, VideoRepository>();
            serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddTransient<ICommentRepository, CommentRepository>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<ITagRepository, TagRepository>();
            serviceCollection.AddTransient<ISeriesRepository, SeriesRepository>();
            serviceCollection.AddTransient<ILikeRepository, LikeRepository>();
            serviceCollection.AddTransient<IVideoPurchaseRepository, VideoPurchaseRepository>();
            serviceCollection.AddTransient<ISeriesPurchaseRepository, SeriesPurchaseRepository>();
            serviceCollection.AddDbContext<NetFilmxDbContext>();
            
            return serviceCollection;

            
        }
    }
}
