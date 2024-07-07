using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Dtos.VideoSeries
{
    public class VideoSeriesDto
    {

        public VideoSeriesDto(int id, int videoId, int seriesId)
        {
            Id = id;
            VideoId = videoId;
            SeriesId = seriesId;
        }

        public int Id { get; }

        public int VideoId { get; }

        public int SeriesId { get; }
    }
}
