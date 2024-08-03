﻿using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class AddVideoCommand : IRequest<CResult>
    {

        public AddVideoCommand(string title, string? description, decimal price, string videoUrl, string? thumbnailUrl)
        {
            Title = title;
            Description = description;
            Price = price;
            VideoUrl = videoUrl;
            ThumbnailUrl = thumbnailUrl;
        }

        public string Title { get; }

        public string? Description { get; }

        public decimal Price { get; }

        public string VideoUrl { get; }

        public string? ThumbnailUrl { get; }



    }
}
