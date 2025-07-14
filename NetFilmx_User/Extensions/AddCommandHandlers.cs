using MediatR;
using NetFilmx_Service.Command.Category;
using NetFilmx_Service.Command.Comment;
using NetFilmx_Service.Command.Series;
using NetFilmx_Service.Command.SeriesPurchase;
using NetFilmx_Service.Command.Tag;
using NetFilmx_Service.Command.User;
using NetFilmx_Service.Command.Video;
using NetFilmx_Service.Command.VideoPurchase;
using NetFilmx_Service.Command.Cart;
using NetFilmx_Service.Command.Cart.Add;
using NetFilmx_Service.Command.Cart.Delete;
using NetFilmx_Service.Command.ViewHistory;
using NetFilmx_Service.Command.ViewHistory.Record;
using NetFilmx_Service.Command.ViewHistory.Complete;
using NetFilmx_Service.Command.ViewHistory.Delete;
using NetFilmx_Service.Command.Favorite;
using NetFilmx_Service.Command.UserSettings;
using NetFilmx_Service.Result;

namespace NetFilmx_User.Extensions
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
            serviceCollection.AddTransient<IRequestHandler<NewPasswordCommand, CResult>, NewPasswordCommandHandler>();

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

            // cart
            serviceCollection.AddTransient<IRequestHandler<AddVideoToCartCommand, CResult>, AddVideoToCartCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<AddSeriesToCartCommand, CResult>, AddSeriesToCartCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<RemoveCartItemCommand, CResult>, RemoveCartItemCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<ClearCartCommand, CResult>, ClearCartCommandHandler>();

            // viewhistory
            serviceCollection.AddTransient<IRequestHandler<RecordViewingProgressCommand, CResult>, RecordViewingProgressCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<MarkVideoCompletedCommand, CResult>, MarkVideoCompletedCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<RemoveFromViewHistoryCommand, CResult>, RemoveFromViewHistoryCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<ClearViewHistoryCommand, CResult>, ClearViewHistoryCommandHandler>();

            // favorites (already implemented)
            serviceCollection.AddTransient<IRequestHandler<AddFavoriteCommand, CResult>, AddFavoriteCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<DeleteFavoriteCommand, CResult>, DeleteFavoriteCommandHandler>();

            // usersettings (already implemented)
            serviceCollection.AddTransient<IRequestHandler<AddUserSettingsCommand, CResult>, AddUserSettingsCommandHandler>();
            serviceCollection.AddTransient<IRequestHandler<EditUserSettingsCommand, CResult>, EditUserSettingsCommandHandler>();

            return serviceCollection;
        }



    }
}
