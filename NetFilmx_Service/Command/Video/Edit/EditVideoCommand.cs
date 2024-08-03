using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class EditVideoCommand : IRequest<CResult>
    {

        public EditVideoCommand(int id, string title, string description, decimal price, string video_url, string thumbnail_url)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Video_url = video_url;
            Thumbnail_url = thumbnail_url;
        }

        public int Id { get; }
        public string Title { get; }

        public string? Description { get; }

        public decimal Price { get; }

        public string Video_url { get; }

        public string Thumbnail_url { get; }


    }
}
