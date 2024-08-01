using MediatR;
using NetFilmx_Service.Command.Category;
using NetFilmx_Service;
using NetFilmx_Storage;
using NetFilmx_Storage.Repositories;
using System.Reflection;
using NetFilmx_Service.Command.Comment;
using NetFilmx_Service.Command.Series;
using NetFilmx_Service.Command.SeriesPurchase;
using NetFilmx_Service.Command.Tag;
using NetFilmx_Service.Command.User;
using NetFilmx_Service.Command.VideoPurchase;
using NetFilmx_Service.Command.Video;

namespace NetFilmx_Web.Extensions
{
    public static partial class ServiceCollectionExtension
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection serviceCollection)
        {
            // categories
            serviceCollection.AddTransient<IRequestHandler<EditCategoryCommand, CResult>, EditCategoryCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<AddCategoryCommand, CResult>, AddCategoryCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<DeleteCategoryCommand, CResult>, DeleteCategoryCommandHandler>();

            //comments

            serviceCollection.AddTransient<IRequestHandler<AddCommentCommand, CResult>, AddCommentCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<DeleteCommentCommand, CResult>, DeleteCommentCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<EditCommentCommand, CResult>, EditCommentCommandHandler>();

            // series
            serviceCollection.AddTransient<IRequestHandler<AddSeriesCommand, CResult>, AddSeriesCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<EditSeriesCommand, CResult>, EditSeriesCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<DeleteSeriesCommand, CResult>, DeleteSeriesCommandHandler>();

            // seriesPurchases
            serviceCollection.AddTransient<IRequestHandler<AddSeriesPurchaseCommand, CResult>, AddSeriesPurchaseCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<DeleteSeriesPurchaseCommand, CResult>, DeleteSeriesPurchaseCommandHandler>();

            // tags
            serviceCollection.AddTransient<IRequestHandler<AddTagCommand, CResult>, AddTagCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<DeleteTagCommand, CResult>, DeleteTagCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<EditTagCommand, CResult>, EditTagCommandHandler>();
            
            // users

            serviceCollection.AddTransient<IRequestHandler<AddUserCommand, CResult>, AddUserCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<DeleteUserCommand, CResult>, DeleteUserCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<EditUserCommand, CResult>, EditUserCommandHandler>();
            
            // videoPurchases
            serviceCollection.AddTransient<IRequestHandler<AddVideoPurchaseCommand, CResult>, AddVideoPurchaseCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<DeleteVideoPurchaseCommand, CResult>, DeleteVideoPurchaseCommandHandler>();

            // videos
            serviceCollection.AddTransient<IRequestHandler<AddVideoCommand, CResult>, AddVideoCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<EditVideoCommand, CResult>, EditVideoCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<DeleteVideoCommand, CResult>, DeleteVideoCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<AddVideoToCategoryCommand, CResult>, AddVideoToCategoryCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<AddVideoToSeriesCommand, CResult>, AddVideoToSeriesCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<AddVideoToTagCommand, CResult>, AddVideoToTagCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<RemoveVideoFromCategoryCommand, CResult>, DeleteVideoFromCategoryCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<RemoveVideoFromSeriesCommand, CResult>, DeleteVideoFromSeriesCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<RemoveVideoFromTagCommand, CResult>, DeleteVideoFromTagCommandHandler>();
            
            return serviceCollection;
        }



    }
}
