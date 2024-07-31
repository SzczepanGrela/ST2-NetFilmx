using Microsoft.CodeAnalysis.CSharp.Syntax;
using NetFilmx_Service.Mappings;

namespace NetFilmx_Web.Extensions
{
    public static partial class ServiceCollectionExtension
    {


        public static IServiceCollection AddAutoMapProfiles (this IServiceCollection serviceCollection)
        {

            serviceCollection.AddAutoMapper(typeof(CategoryMappingProfile));
            serviceCollection.AddAutoMapper(typeof(VideoMappingProfile));
            serviceCollection.AddAutoMapper(typeof(TagMappingProfile));
            serviceCollection.AddAutoMapper(typeof(SeriesMappingProfile));
            serviceCollection.AddAutoMapper(typeof(UserMappingProfile));
            serviceCollection.AddAutoMapper(typeof(CommentMappingProfile));


            return serviceCollection;
        }


    }
}
