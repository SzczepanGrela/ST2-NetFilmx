using NetFilmx_Storage.Context;
using NetFilmx_Storage.Repositories;
using NetFilmx_User.Services;
using NetFilmx_Service.Mappings;
using MediatR;
using NetFilmx_Service.Query.Video;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Result;

namespace NetFilmx_User.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNetFilmxServices(this IServiceCollection services)
        {
            // Repository registrations
            services.AddTransient<IVideoRepository, VideoRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<ISeriesRepository, SeriesRepository>();
            services.AddTransient<ILikeRepository, LikeRepository>();
            services.AddTransient<IVideoPurchaseRepository, VideoPurchaseRepository>();
            services.AddTransient<ISeriesPurchaseRepository, SeriesPurchaseRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IViewHistoryRepository, ViewHistoryRepository>();
            services.AddTransient<IFavoriteRepository, FavoriteRepository>();
            services.AddTransient<IUserSettingsRepository, UserSettingsRepository>();

            // Application services
            services.AddScoped<ICartService, CartService>();
            
            // Database context
            services.AddDbContext<NetFilmxDbContext>();

            return services;
        }


        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CategoryMappingProfile));
            services.AddAutoMapper(typeof(CommentMappingProfile));
            services.AddAutoMapper(typeof(LikeMappingProfile));
            services.AddAutoMapper(typeof(SeriesMappingProfile));
            services.AddAutoMapper(typeof(SeriesPurchaseMappingProfile));
            services.AddAutoMapper(typeof(TagMappingProfile));
            services.AddAutoMapper(typeof(UserMappingProfile));
            services.AddAutoMapper(typeof(VideoMappingProfile));
            services.AddAutoMapper(typeof(VideoPurchaseMappingProfile));

            return services;
        }

        public static IServiceCollection AddMediatRHandlers(this IServiceCollection services)
        {
            // Video query handlers
            services.AddTransient<IRequestHandler<GetAllVideosQuery<VideoListDto>, QResult<List<VideoListDto>>>, GetAllVideosQueryHandler<VideoListDto>>();
            services.AddTransient<IRequestHandler<GetVideoByIdQuery<VideoDetailsDto>, QResult<VideoDetailsDto>>, GetVideoByIdQueryHandler<VideoDetailsDto>>();
            services.AddTransient<IRequestHandler<GetVideoByIdQuery<VideoEditDto>, QResult<VideoEditDto>>, GetVideoByIdQueryHandler<VideoEditDto>>();

            return services;
        }
    }
}