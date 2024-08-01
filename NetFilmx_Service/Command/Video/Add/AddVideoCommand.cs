﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class AddVideoCommand : IRequest<CResult>
    {

        public AddVideoCommand(string title, string description, decimal price, string video_url, string? thumbnail_url)
        {
            Title = title;
            Description = description;
            Price = price;
            Video_url = video_url;
            Thumbnail_url = thumbnail_url;
        }

        public string Title { get;}

        public string Description { get;}

        public decimal Price { get;}

        public string Video_url { get;}

        public string? Thumbnail_url { get;}



    }
}
