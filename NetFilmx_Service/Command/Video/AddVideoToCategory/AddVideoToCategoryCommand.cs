using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Video
{
    public sealed class AddVideoToCategoryCommand : IRequest<CResult>
    {

        public AddVideoToCategoryCommand(int categoryId, int videoId)
        {
            CategoryId = categoryId;
            VideoId = videoId;
        }

        public int CategoryId { get; set; }
        public int VideoId { get; set; }
    }
}
