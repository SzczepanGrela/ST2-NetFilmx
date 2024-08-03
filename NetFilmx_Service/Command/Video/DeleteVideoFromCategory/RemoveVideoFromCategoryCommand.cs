using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class RemoveVideoFromCategoryCommand : IRequest<CResult>
    {

        public RemoveVideoFromCategoryCommand(int categoryId, int videoId)
        {
            CategoryId = categoryId;
            VideoId = videoId;
        }

        public int CategoryId { get; }

        public int VideoId { get; }
    }
}
