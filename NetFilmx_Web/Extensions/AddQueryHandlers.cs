using MediatR;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Service.Dtos.Comment;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Dtos.SeriesPurchase;
using NetFilmx_Service.Dtos.Tag;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Dtos.VideoPurchase;
using NetFilmx_Service.Query.Category;
using NetFilmx_Service.Query.Comment;
using NetFilmx_Service.Query.Like;
using NetFilmx_Service.Query.Series;
using NetFilmx_Service.Query.SeriesPurchase;
using NetFilmx_Service.Query.Tag;
using NetFilmx_Service.Query.User;
using NetFilmx_Service.Query.Video;
using NetFilmx_Service.Query.VideoPurchase;
using NetFilmx_Service.Result;

namespace NetFilmx_Web.Extensions
{
    public static partial class ServiceCollectionExtension
    {

        /// <summary>
        /// Registers all possible combinations of QueryHandler and Dto by object. Brute Force Generated, to be optimized.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>

        public static IServiceCollection AddRequestHandlers(this IServiceCollection serviceCollection)
        {
            // Category Requests
            serviceCollection.AddTransient<IRequestHandler<GetAllCategoriesQuery<CategoryAddDto>, QResult<List<CategoryAddDto>>>, GetAllCategoriesQueryHandler<CategoryAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllCategoriesQuery<CategoryDetailsDto>, QResult<List<CategoryDetailsDto>>>, GetAllCategoriesQueryHandler<CategoryDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllCategoriesQuery<CategoryEditDto>, QResult<List<CategoryEditDto>>>, GetAllCategoriesQueryHandler<CategoryEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllCategoriesQuery<CategoryListDto>, QResult<List<CategoryListDto>>>, GetAllCategoriesQueryHandler<CategoryListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetCategoryByIdQuery<CategoryAddDto>, QResult<CategoryAddDto>>, GetCategoryByIdQueryHandler<CategoryAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoryByIdQuery<CategoryDetailsDto>, QResult<CategoryDetailsDto>>, GetCategoryByIdQueryHandler<CategoryDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoryByIdQuery<CategoryEditDto>, QResult<CategoryEditDto>>, GetCategoryByIdQueryHandler<CategoryEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoryByIdQuery<CategoryListDto>, QResult<CategoryListDto>>, GetCategoryByIdQueryHandler<CategoryListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetCategoryByNameQuery<CategoryAddDto>, QResult<CategoryAddDto>>, GetCategoryByNameQueryHandler<CategoryAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoryByNameQuery<CategoryDetailsDto>, QResult<CategoryDetailsDto>>, GetCategoryByNameQueryHandler<CategoryDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoryByNameQuery<CategoryEditDto>, QResult<CategoryEditDto>>, GetCategoryByNameQueryHandler<CategoryEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoryByNameQuery<CategoryListDto>, QResult<CategoryListDto>>, GetCategoryByNameQueryHandler<CategoryListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetCategoriesByVideoIdQuery<CategoryAddDto>, QResult<List<CategoryAddDto>>>, GetCategoriesByVideoIdQueryHandler<CategoryAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoriesByVideoIdQuery<CategoryDetailsDto>, QResult<List<CategoryDetailsDto>>>, GetCategoriesByVideoIdQueryHandler<CategoryDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoriesByVideoIdQuery<CategoryEditDto>, QResult<List<CategoryEditDto>>>, GetCategoriesByVideoIdQueryHandler<CategoryEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoriesByVideoIdQuery<CategoryListDto>, QResult<List<CategoryListDto>>>, GetCategoriesByVideoIdQueryHandler<CategoryListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetCategoriesByExcludedVideoIdQuery<CategoryAddDto>, QResult<List<CategoryAddDto>>>, GetCategoriesByExcludedVideoIdQueryHandler<CategoryAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoriesByExcludedVideoIdQuery<CategoryDetailsDto>, QResult<List<CategoryDetailsDto>>>, GetCategoriesByExcludedVideoIdQueryHandler<CategoryDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoriesByExcludedVideoIdQuery<CategoryEditDto>, QResult<List<CategoryEditDto>>>, GetCategoriesByExcludedVideoIdQueryHandler<CategoryEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoriesByExcludedVideoIdQuery<CategoryListDto>, QResult<List<CategoryListDto>>>, GetCategoriesByExcludedVideoIdQueryHandler<CategoryListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetCategoryCountByIdQuery, QResult<int>>, GetCategoryCountByIdQueryHandler>();
            serviceCollection.AddTransient<IRequestHandler<GetCategoryCountByNameQuery, QResult<int>>, GetCategoryCountByNameQueryHandler>();

            // Comment Requests
            serviceCollection.AddTransient<IRequestHandler<GetAllCommentsQuery<CommentAddDto>, QResult<List<CommentAddDto>>>, GetAllCommentsQueryHandler<CommentAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllCommentsQuery<CommentDetailsDto>, QResult<List<CommentDetailsDto>>>, GetAllCommentsQueryHandler<CommentDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllCommentsQuery<CommentEditDto>, QResult<List<CommentEditDto>>>, GetAllCommentsQueryHandler<CommentEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllCommentsQuery<CommentListDto>, QResult<List<CommentListDto>>>, GetAllCommentsQueryHandler<CommentListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetCommentByIdQuery<CommentAddDto>, QResult<CommentAddDto>>, GetCommentByIdQueryHandler<CommentAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCommentByIdQuery<CommentDetailsDto>, QResult<CommentDetailsDto>>, GetCommentByIdQueryHandler<CommentDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCommentByIdQuery<CommentEditDto>, QResult<CommentEditDto>>, GetCommentByIdQueryHandler<CommentEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCommentByIdQuery<CommentListDto>, QResult<CommentListDto>>, GetCommentByIdQueryHandler<CommentListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetCommentsByUserIdQuery<CommentAddDto>, QResult<List<CommentAddDto>>>, GetCommentsByUserIdQueryHandler<CommentAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCommentsByUserIdQuery<CommentDetailsDto>, QResult<List<CommentDetailsDto>>>, GetCommentsByUserIdQueryHandler<CommentDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCommentsByUserIdQuery<CommentEditDto>, QResult<List<CommentEditDto>>>, GetCommentsByUserIdQueryHandler<CommentEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCommentsByUserIdQuery<CommentListDto>, QResult<List<CommentListDto>>>, GetCommentsByUserIdQueryHandler<CommentListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetCommentsByVideoIdQuery<CommentAddDto>, QResult<List<CommentAddDto>>>, GetCommentsByVideoIdQueryHandler<CommentAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCommentsByVideoIdQuery<CommentDetailsDto>, QResult<List<CommentDetailsDto>>>, GetCommentsByVideoIdQueryHandler<CommentDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCommentsByVideoIdQuery<CommentEditDto>, QResult<List<CommentEditDto>>>, GetCommentsByVideoIdQueryHandler<CommentEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetCommentsByVideoIdQuery<CommentListDto>, QResult<List<CommentListDto>>>, GetCommentsByVideoIdQueryHandler<CommentListDto>>();

            // Like Requests
            serviceCollection.AddTransient<IRequestHandler<GetLikesCountByVideoIdQuery, QResult<int>>, GetLikesCountByVideoIdQueryHandler>();

            // Series Requests
            serviceCollection.AddTransient<IRequestHandler<GetAllSeriesQuery<SeriesAddDto>, QResult<List<SeriesAddDto>>>, GetAllSeriesQueryHandler<SeriesAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllSeriesQuery<SeriesDetailsDto>, QResult<List<SeriesDetailsDto>>>, GetAllSeriesQueryHandler<SeriesDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllSeriesQuery<SeriesEditDto>, QResult<List<SeriesEditDto>>>, GetAllSeriesQueryHandler<SeriesEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllSeriesQuery<SeriesListDto>, QResult<List<SeriesListDto>>>, GetAllSeriesQueryHandler<SeriesListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetSeriesByUserIdQuery<SeriesAddDto>, QResult<List<SeriesAddDto>>>, GetSeriesByUserIdQueryHandler<SeriesAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByUserIdQuery<SeriesDetailsDto>, QResult<List<SeriesDetailsDto>>>, GetSeriesByUserIdQueryHandler<SeriesDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByUserIdQuery<SeriesEditDto>, QResult<List<SeriesEditDto>>>, GetSeriesByUserIdQueryHandler<SeriesEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByUserIdQuery<SeriesListDto>, QResult<List<SeriesListDto>>>, GetSeriesByUserIdQueryHandler<SeriesListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetSeriesByIdQuery<SeriesAddDto>, QResult<SeriesAddDto>>, GetSeriesByIdQueryHandler<SeriesAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByIdQuery<SeriesDetailsDto>, QResult<SeriesDetailsDto>>, GetSeriesByIdQueryHandler<SeriesDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByIdQuery<SeriesEditDto>, QResult<SeriesEditDto>>, GetSeriesByIdQueryHandler<SeriesEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByIdQuery<SeriesListDto>, QResult<SeriesListDto>>, GetSeriesByIdQueryHandler<SeriesListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetSeriesByNameQuery<SeriesAddDto>, QResult<SeriesAddDto>>, GetSeriesByNameQueryHandler<SeriesAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByNameQuery<SeriesDetailsDto>, QResult<SeriesDetailsDto>>, GetSeriesByNameQueryHandler<SeriesDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByNameQuery<SeriesEditDto>, QResult<SeriesEditDto>>, GetSeriesByNameQueryHandler<SeriesEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByNameQuery<SeriesListDto>, QResult<SeriesListDto>>, GetSeriesByNameQueryHandler<SeriesListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetSeriesByVideoIdQuery<SeriesAddDto>, QResult<List<SeriesAddDto>>>, GetSeriesByVideoIdQueryHandler<SeriesAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByVideoIdQuery<SeriesDetailsDto>, QResult<List<SeriesDetailsDto>>>, GetSeriesByVideoIdQueryHandler<SeriesDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByVideoIdQuery<SeriesEditDto>, QResult<List<SeriesEditDto>>>, GetSeriesByVideoIdQueryHandler<SeriesEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByVideoIdQuery<SeriesListDto>, QResult<List<SeriesListDto>>>, GetSeriesByVideoIdQueryHandler<SeriesListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetSeriesByExcludedVideoIdQuery<SeriesAddDto>, QResult<List<SeriesAddDto>>>, GetSeriesByExcludedVideoIdQueryHandler<SeriesAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByExcludedVideoIdQuery<SeriesDetailsDto>, QResult<List<SeriesDetailsDto>>>, GetSeriesByExcludedVideoIdQueryHandler<SeriesDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByExcludedVideoIdQuery<SeriesEditDto>, QResult<List<SeriesEditDto>>>, GetSeriesByExcludedVideoIdQueryHandler<SeriesEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByExcludedVideoIdQuery<SeriesListDto>, QResult<List<SeriesListDto>>>, GetSeriesByExcludedVideoIdQueryHandler<SeriesListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetSeriesByExcludedUserIdQuery<SeriesAddDto>, QResult<List<SeriesAddDto>>>, GetSeriesByExcludedUserIdQueryHandler<SeriesAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByExcludedUserIdQuery<SeriesDetailsDto>, QResult<List<SeriesDetailsDto>>>, GetSeriesByExcludedUserIdQueryHandler<SeriesDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByExcludedUserIdQuery<SeriesEditDto>, QResult<List<SeriesEditDto>>>, GetSeriesByExcludedUserIdQueryHandler<SeriesEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesByExcludedUserIdQuery<SeriesListDto>, QResult<List<SeriesListDto>>>, GetSeriesByExcludedUserIdQueryHandler<SeriesListDto>>();


            serviceCollection.AddTransient<IRequestHandler<GetSeriesCountByIdQuery, QResult<int>>, GetSeriesCountByIdQueryHandler>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesCountByNameQuery, QResult<int>>, GetSeriesCountByNameQueryHandler>();

            // Tag Requests
            serviceCollection.AddTransient<IRequestHandler<GetAllTagsQuery<TagAddDto>, QResult<List<TagAddDto>>>, GetAllTagsQueryHandler<TagAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllTagsQuery<TagDetailsDto>, QResult<List<TagDetailsDto>>>, GetAllTagsQueryHandler<TagDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllTagsQuery<TagEditDto>, QResult<List<TagEditDto>>>, GetAllTagsQueryHandler<TagEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllTagsQuery<TagListDto>, QResult<List<TagListDto>>>, GetAllTagsQueryHandler<TagListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetTagByIdQuery<TagAddDto>, QResult<TagAddDto>>, GetTagByIdQueryHandler<TagAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagByIdQuery<TagDetailsDto>, QResult<TagDetailsDto>>, GetTagByIdQueryHandler<TagDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagByIdQuery<TagEditDto>, QResult<TagEditDto>>, GetTagByIdQueryHandler<TagEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagByIdQuery<TagListDto>, QResult<TagListDto>>, GetTagByIdQueryHandler<TagListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetTagByNameQuery<TagAddDto>, QResult<TagAddDto>>, GetTagByNameQueryHandler<TagAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagByNameQuery<TagDetailsDto>, QResult<TagDetailsDto>>, GetTagByNameQueryHandler<TagDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagByNameQuery<TagEditDto>, QResult<TagEditDto>>, GetTagByNameQueryHandler<TagEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagByNameQuery<TagListDto>, QResult<TagListDto>>, GetTagByNameQueryHandler<TagListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetTagsByVideoIdQuery<TagAddDto>, QResult<List<TagAddDto>>>, GetTagsByVideoIdQueryHandler<TagAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagsByVideoIdQuery<TagDetailsDto>, QResult<List<TagDetailsDto>>>, GetTagsByVideoIdQueryHandler<TagDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagsByVideoIdQuery<TagEditDto>, QResult<List<TagEditDto>>>, GetTagsByVideoIdQueryHandler<TagEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagsByVideoIdQuery<TagListDto>, QResult<List<TagListDto>>>, GetTagsByVideoIdQueryHandler<TagListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetTagsByExcludedVideoIdQuery<TagAddDto>, QResult<List<TagAddDto>>>, GetTagsByExcludedVideoIdQueryHandler<TagAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagsByExcludedVideoIdQuery<TagDetailsDto>, QResult<List<TagDetailsDto>>>, GetTagsByExcludedVideoIdQueryHandler<TagDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagsByExcludedVideoIdQuery<TagEditDto>, QResult<List<TagEditDto>>>, GetTagsByExcludedVideoIdQueryHandler<TagEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetTagsByExcludedVideoIdQuery<TagListDto>, QResult<List<TagListDto>>>, GetTagsByExcludedVideoIdQueryHandler<TagListDto>>();


            serviceCollection.AddTransient<IRequestHandler<GetTagCountByIdQuery, QResult<int>>, GetTagCountByIdQueryHandler>();
            serviceCollection.AddTransient<IRequestHandler<GetTagCountByNameQuery, QResult<int>>, GetTagCountByNameQueryHandler>();

            // User Requests
            serviceCollection.AddTransient<IRequestHandler<GetAllUsersQuery<UserAddDto>, QResult<List<UserAddDto>>>, GetAllUsersQueryHandler<UserAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllUsersQuery<UserDetailsDto>, QResult<List<UserDetailsDto>>>, GetAllUsersQueryHandler<UserDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllUsersQuery<UserEditDto>, QResult<List<UserEditDto>>>, GetAllUsersQueryHandler<UserEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllUsersQuery<UserListDto>, QResult<List<UserListDto>>>, GetAllUsersQueryHandler<UserListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetUserByCommentIdQuery<UserAddDto>, QResult<UserAddDto>>, GetUserByCommentIdQueryHandler<UserAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByCommentIdQuery<UserDetailsDto>, QResult<UserDetailsDto>>, GetUserByCommentIdQueryHandler<UserDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByCommentIdQuery<UserEditDto>, QResult<UserEditDto>>, GetUserByCommentIdQueryHandler<UserEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByCommentIdQuery<UserListDto>, QResult<UserListDto>>, GetUserByCommentIdQueryHandler<UserListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetUsersByExcludedSeriesIdQuery<UserAddDto>, QResult<List<UserAddDto>>>, GetUsersByExcludedSeriesIdQueryHandler<UserAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersByExcludedSeriesIdQuery<UserDetailsDto>, QResult<List<UserDetailsDto>>>, GetUsersByExcludedSeriesIdQueryHandler<UserDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersByExcludedSeriesIdQuery<UserEditDto>, QResult<List<UserEditDto>>>, GetUsersByExcludedSeriesIdQueryHandler<UserEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersByExcludedSeriesIdQuery<UserListDto>, QResult<List<UserListDto>>>, GetUsersByExcludedSeriesIdQueryHandler<UserListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetUsersByExcludedSeriesIdQuery<UserAddDto>, QResult<List<UserAddDto>>>, GetUsersByExcludedSeriesIdQueryHandler<UserAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersByExcludedSeriesIdQuery<UserDetailsDto>, QResult<List<UserDetailsDto>>>, GetUsersByExcludedSeriesIdQueryHandler<UserDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersByExcludedSeriesIdQuery<UserEditDto>, QResult<List<UserEditDto>>>, GetUsersByExcludedSeriesIdQueryHandler<UserEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersByExcludedSeriesIdQuery<UserListDto>, QResult<List<UserListDto>>>, GetUsersByExcludedSeriesIdQueryHandler<UserListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetUserByIdQuery<UserAddDto>, QResult<UserAddDto>>, GetUserByIdQueryHandler<UserAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByIdQuery<UserDetailsDto>, QResult<UserDetailsDto>>, GetUserByIdQueryHandler<UserDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByIdQuery<UserEditDto>, QResult<UserEditDto>>, GetUserByIdQueryHandler<UserEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByIdQuery<UserListDto>, QResult<UserListDto>>, GetUserByIdQueryHandler<UserListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetUserByLikeIdQuery<UserAddDto>, QResult<UserAddDto>>, GetUserByLikeIdQueryHandler<UserAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByLikeIdQuery<UserDetailsDto>, QResult<UserDetailsDto>>, GetUserByLikeIdQueryHandler<UserDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByLikeIdQuery<UserEditDto>, QResult<UserEditDto>>, GetUserByLikeIdQueryHandler<UserEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByLikeIdQuery<UserListDto>, QResult<UserListDto>>, GetUserByLikeIdQueryHandler<UserListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetUsersBySeriesIdQuery<UserAddDto>, QResult<List<UserAddDto>>>, GetUsersBySeriesIdQueryHandler<UserAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersBySeriesIdQuery<UserDetailsDto>, QResult<List<UserDetailsDto>>>, GetUsersBySeriesIdQueryHandler<UserDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersBySeriesIdQuery<UserEditDto>, QResult<List<UserEditDto>>>, GetUsersBySeriesIdQueryHandler<UserEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersBySeriesIdQuery<UserListDto>, QResult<List<UserListDto>>>, GetUsersBySeriesIdQueryHandler<UserListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetUserBySeriesPurchaseIdQuery<UserAddDto>, QResult<UserAddDto>>, GetUserBySeriesPurchaseIdQueryHandler<UserAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserBySeriesPurchaseIdQuery<UserDetailsDto>, QResult<UserDetailsDto>>, GetUserBySeriesPurchaseIdQueryHandler<UserDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserBySeriesPurchaseIdQuery<UserEditDto>, QResult<UserEditDto>>, GetUserBySeriesPurchaseIdQueryHandler<UserEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserBySeriesPurchaseIdQuery<UserListDto>, QResult<UserListDto>>, GetUserBySeriesPurchaseIdQueryHandler<UserListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetUserByUsernameQuery<UserAddDto>, QResult<UserAddDto>>, GetUserByUsernameQueryHandler<UserAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByUsernameQuery<UserDetailsDto>, QResult<UserDetailsDto>>, GetUserByUsernameQueryHandler<UserDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByUsernameQuery<UserEditDto>, QResult<UserEditDto>>, GetUserByUsernameQueryHandler<UserEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByUsernameQuery<UserListDto>, QResult<UserListDto>>, GetUserByUsernameQueryHandler<UserListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetUsersByVideoIdQuery<UserAddDto>, QResult<List<UserAddDto>>>, GetUsersByVideoIdQueryHandler<UserAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersByVideoIdQuery<UserDetailsDto>, QResult<List<UserDetailsDto>>>, GetUsersByVideoIdQueryHandler<UserDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersByVideoIdQuery<UserEditDto>, QResult<List<UserEditDto>>>, GetUsersByVideoIdQueryHandler<UserEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUsersByVideoIdQuery<UserListDto>, QResult<List<UserListDto>>>, GetUsersByVideoIdQueryHandler<UserListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetUserByVideoPurchaseIdQuery<UserAddDto>, QResult<UserAddDto>>, GetUserByVideoPurchaseIdQueryHandler<UserAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByVideoPurchaseIdQuery<UserDetailsDto>, QResult<UserDetailsDto>>, GetUserByVideoPurchaseIdQueryHandler<UserDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByVideoPurchaseIdQuery<UserEditDto>, QResult<UserEditDto>>, GetUserByVideoPurchaseIdQueryHandler<UserEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetUserByVideoPurchaseIdQuery<UserListDto>, QResult<UserListDto>>, GetUserByVideoPurchaseIdQueryHandler<UserListDto>>();

            serviceCollection.AddTransient<IRequestHandler<IsUsernameAvailableQuery, QResult<bool>>, IsUsernameAvailableQueryHandler>();

            // Video Requests
            serviceCollection.AddTransient<IRequestHandler<GetAllVideosQuery<VideoAddDto>, QResult<List<VideoAddDto>>>, GetAllVideosQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllVideosQuery<VideoDetailsDto>, QResult<List<VideoDetailsDto>>>, GetAllVideosQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllVideosQuery<VideoEditDto>, QResult<List<VideoEditDto>>>, GetAllVideosQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllVideosQuery<VideoListDto>, QResult<List<VideoListDto>>>, GetAllVideosQueryHandler<VideoListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideosByCategoryIdQuery<VideoAddDto>, QResult<List<VideoAddDto>>>, GetVideosByCategoryIdQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByCategoryIdQuery<VideoDetailsDto>, QResult<List<VideoDetailsDto>>>, GetVideosByCategoryIdQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByCategoryIdQuery<VideoEditDto>, QResult<List<VideoEditDto>>>, GetVideosByCategoryIdQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByCategoryIdQuery<VideoListDto>, QResult<List<VideoListDto>>>, GetVideosByCategoryIdQueryHandler<VideoListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideoByCommentIdQuery<VideoAddDto>, QResult<VideoAddDto>>, GetVideoByCommentIdQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByCommentIdQuery<VideoDetailsDto>, QResult<VideoDetailsDto>>, GetVideoByCommentIdQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByCommentIdQuery<VideoEditDto>, QResult<VideoEditDto>>, GetVideoByCommentIdQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByCommentIdQuery<VideoListDto>, QResult<VideoListDto>>, GetVideoByCommentIdQueryHandler<VideoListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedCategoryQuery<VideoAddDto>, QResult<List<VideoAddDto>>>, GetVideosByExcludedCategoryQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedCategoryQuery<VideoDetailsDto>, QResult<List<VideoDetailsDto>>>, GetVideosByExcludedCategoryQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedCategoryQuery<VideoEditDto>, QResult<List<VideoEditDto>>>, GetVideosByExcludedCategoryQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedCategoryQuery<VideoListDto>, QResult<List<VideoListDto>>>, GetVideosByExcludedCategoryQueryHandler<VideoListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedSeriesQuery<VideoAddDto>, QResult<List<VideoAddDto>>>, GetVideosByExcludedSeriesQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedSeriesQuery<VideoDetailsDto>, QResult<List<VideoDetailsDto>>>, GetVideosByExcludedSeriesQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedSeriesQuery<VideoEditDto>, QResult<List<VideoEditDto>>>, GetVideosByExcludedSeriesQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedSeriesQuery<VideoListDto>, QResult<List<VideoListDto>>>, GetVideosByExcludedSeriesQueryHandler<VideoListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedTagIdQuery<VideoAddDto>, QResult<List<VideoAddDto>>>, GetVideosByExcludedTagIdQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedTagIdQuery<VideoDetailsDto>, QResult<List<VideoDetailsDto>>>, GetVideosByExcludedTagIdQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedTagIdQuery<VideoEditDto>, QResult<List<VideoEditDto>>>, GetVideosByExcludedTagIdQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedTagIdQuery<VideoListDto>, QResult<List<VideoListDto>>>, GetVideosByExcludedTagIdQueryHandler<VideoListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideoByIdQuery<VideoAddDto>, QResult<VideoAddDto>>, GetVideoByIdQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByIdQuery<VideoDetailsDto>, QResult<VideoDetailsDto>>, GetVideoByIdQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByIdQuery<VideoEditDto>, QResult<VideoEditDto>>, GetVideoByIdQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByIdQuery<VideoListDto>, QResult<VideoListDto>>, GetVideoByIdQueryHandler<VideoListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideoByLikeIdQuery<VideoAddDto>, QResult<VideoAddDto>>, GetVideoByLikeIdQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByLikeIdQuery<VideoDetailsDto>, QResult<VideoDetailsDto>>, GetVideoByLikeIdQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByLikeIdQuery<VideoEditDto>, QResult<VideoEditDto>>, GetVideoByLikeIdQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByLikeIdQuery<VideoListDto>, QResult<VideoListDto>>, GetVideoByLikeIdQueryHandler<VideoListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideosBySeriesIdQuery<VideoAddDto>, QResult<List<VideoAddDto>>>, GetVideosBySeriesIdQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosBySeriesIdQuery<VideoDetailsDto>, QResult<List<VideoDetailsDto>>>, GetVideosBySeriesIdQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosBySeriesIdQuery<VideoEditDto>, QResult<List<VideoEditDto>>>, GetVideosBySeriesIdQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosBySeriesIdQuery<VideoListDto>, QResult<List<VideoListDto>>>, GetVideosBySeriesIdQueryHandler<VideoListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideosByTagIdQuery<VideoAddDto>, QResult<List<VideoAddDto>>>, GetVideosByTagIdQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByTagIdQuery<VideoDetailsDto>, QResult<List<VideoDetailsDto>>>, GetVideosByTagIdQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByTagIdQuery<VideoEditDto>, QResult<List<VideoEditDto>>>, GetVideosByTagIdQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByTagIdQuery<VideoListDto>, QResult<List<VideoListDto>>>, GetVideosByTagIdQueryHandler<VideoListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideosByUserIdQuery<VideoAddDto>, QResult<List<VideoAddDto>>>, GetVideosByUserIdQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByUserIdQuery<VideoDetailsDto>, QResult<List<VideoDetailsDto>>>, GetVideosByUserIdQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByUserIdQuery<VideoEditDto>, QResult<List<VideoEditDto>>>, GetVideosByUserIdQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByUserIdQuery<VideoListDto>, QResult<List<VideoListDto>>>, GetVideosByUserIdQueryHandler<VideoListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideoByVideoPurchaseIdQuery<VideoAddDto>, QResult<VideoAddDto>>, GetVideoByVideoPurchaseIdQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByVideoPurchaseIdQuery<VideoDetailsDto>, QResult<VideoDetailsDto>>, GetVideoByVideoPurchaseIdQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByVideoPurchaseIdQuery<VideoEditDto>, QResult<VideoEditDto>>, GetVideoByVideoPurchaseIdQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoByVideoPurchaseIdQuery<VideoListDto>, QResult<VideoListDto>>, GetVideoByVideoPurchaseIdQueryHandler<VideoListDto>>();


            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedUserIdQuery<VideoAddDto>, QResult<List<VideoAddDto>>>, GetVideosByExcludedUserIdQueryHandler<VideoAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedUserIdQuery<VideoDetailsDto>, QResult<List<VideoDetailsDto>>>, GetVideosByExcludedUserIdQueryHandler<VideoDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedUserIdQuery<VideoEditDto>, QResult<List<VideoEditDto>>>, GetVideosByExcludedUserIdQueryHandler<VideoEditDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideosByExcludedUserIdQuery<VideoListDto>, QResult<List<VideoListDto>>>, GetVideosByExcludedUserIdQueryHandler<VideoListDto>>();



            // seriespurchase Requests

            serviceCollection.AddTransient<IRequestHandler<GetAllSeriesPurchasesQuery<SeriesPurchaseAddDto>, QResult<List<SeriesPurchaseAddDto>>>, GetAllSeriesPurchasesQueryHandler<SeriesPurchaseAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllSeriesPurchasesQuery<SeriesPurchaseDetailsDto>, QResult<List<SeriesPurchaseDetailsDto>>>, GetAllSeriesPurchasesQueryHandler<SeriesPurchaseDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllSeriesPurchasesQuery<SeriesPurchaseListDto>, QResult<List<SeriesPurchaseListDto>>>, GetAllSeriesPurchasesQueryHandler<SeriesPurchaseListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetSeriesPurchaseByIdQuery<SeriesPurchaseAddDto>, QResult<SeriesPurchaseAddDto>>, GetSeriesPurchaseByIdQueryHandler<SeriesPurchaseAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesPurchaseByIdQuery<SeriesPurchaseDetailsDto>, QResult<SeriesPurchaseDetailsDto>>, GetSeriesPurchaseByIdQueryHandler<SeriesPurchaseDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesPurchaseByIdQuery<SeriesPurchaseListDto>, QResult<SeriesPurchaseListDto>>, GetSeriesPurchaseByIdQueryHandler<SeriesPurchaseListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetSeriesPurchasesBySeriesIdQuery<SeriesPurchaseAddDto>, QResult<List<SeriesPurchaseAddDto>>>, GetSeriesPurchasesBySeriesIdQueryHandler<SeriesPurchaseAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesPurchasesBySeriesIdQuery<SeriesPurchaseDetailsDto>, QResult<List<SeriesPurchaseDetailsDto>>>, GetSeriesPurchasesBySeriesIdQueryHandler<SeriesPurchaseDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesPurchasesBySeriesIdQuery<SeriesPurchaseListDto>, QResult<List<SeriesPurchaseListDto>>>, GetSeriesPurchasesBySeriesIdQueryHandler<SeriesPurchaseListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetSeriesPurchasesByUserIdQuery<SeriesPurchaseAddDto>, QResult<List<SeriesPurchaseAddDto>>>, GetSeriesPurchasesByUserIdQueryHandler<SeriesPurchaseAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesPurchasesByUserIdQuery<SeriesPurchaseDetailsDto>, QResult<List<SeriesPurchaseDetailsDto>>>, GetSeriesPurchasesByUserIdQueryHandler<SeriesPurchaseDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetSeriesPurchasesByUserIdQuery<SeriesPurchaseListDto>, QResult<List<SeriesPurchaseListDto>>>, GetSeriesPurchasesByUserIdQueryHandler<SeriesPurchaseListDto>>();



            // videopurchase Requests

            serviceCollection.AddTransient<IRequestHandler<GetAllVideoPurchasesQuery<VideoPurchaseAddDto>, QResult<List<VideoPurchaseAddDto>>>, GetAllVideoPurchasesQueryHandler<VideoPurchaseAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllVideoPurchasesQuery<VideoPurchaseDetailsDto>, QResult<List<VideoPurchaseDetailsDto>>>, GetAllVideoPurchasesQueryHandler<VideoPurchaseDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetAllVideoPurchasesQuery<VideoPurchaseListDto>, QResult<List<VideoPurchaseListDto>>>, GetAllVideoPurchasesQueryHandler<VideoPurchaseListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideoPurchaseByIdQuery<VideoPurchaseAddDto>, QResult<VideoPurchaseAddDto>>, GetVideoPurchaseByIdQueryHandler<VideoPurchaseAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoPurchaseByIdQuery<VideoPurchaseDetailsDto>, QResult<VideoPurchaseDetailsDto>>, GetVideoPurchaseByIdQueryHandler<VideoPurchaseDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoPurchaseByIdQuery<VideoPurchaseListDto>, QResult<VideoPurchaseListDto>>, GetVideoPurchaseByIdQueryHandler<VideoPurchaseListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideoPurchasesByUserIdQuery<VideoPurchaseAddDto>, QResult<List<VideoPurchaseAddDto>>>, GetVideoPurchasesByUserIdQueryHandler<VideoPurchaseAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoPurchasesByUserIdQuery<VideoPurchaseDetailsDto>, QResult<List<VideoPurchaseDetailsDto>>>, GetVideoPurchasesByUserIdQueryHandler<VideoPurchaseDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoPurchasesByUserIdQuery<VideoPurchaseListDto>, QResult<List<VideoPurchaseListDto>>>, GetVideoPurchasesByUserIdQueryHandler<VideoPurchaseListDto>>();

            serviceCollection.AddTransient<IRequestHandler<GetVideoPurchasesByVideoIdQuery<VideoPurchaseAddDto>, QResult<List<VideoPurchaseAddDto>>>, GetVideoPurchasesByVideoIdQueryHandler<VideoPurchaseAddDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoPurchasesByVideoIdQuery<VideoPurchaseDetailsDto>, QResult<List<VideoPurchaseDetailsDto>>>, GetVideoPurchasesByVideoIdQueryHandler<VideoPurchaseDetailsDto>>();
            serviceCollection.AddTransient<IRequestHandler<GetVideoPurchasesByVideoIdQuery<VideoPurchaseListDto>, QResult<List<VideoPurchaseListDto>>>, GetVideoPurchasesByVideoIdQueryHandler<VideoPurchaseListDto>>();



            return serviceCollection;
        }




    }
}
