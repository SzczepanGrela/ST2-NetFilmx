using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Dtos.Comment;

namespace NetFilmx_User.Models.ViewModels
{
    public class VideoDetailViewModel
    {
        public VideoDetailsDto Video { get; set; } = null!;
        public List<CommentListDto> Comments { get; set; } = new List<CommentListDto>();
        public int LikesCount { get; set; }
        public List<VideoListDto> RelatedVideos { get; set; } = new List<VideoListDto>();
        public bool IsUserOwner { get; set; }
        public bool IsLikedByUser { get; set; }
    }
}