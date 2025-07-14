namespace NetFilmx_Service.Dtos.ViewHistory
{
    public class ViewHistoryListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public int ProgressSeconds { get; set; }
        public int DurationSeconds { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime LastWatchedAt { get; set; }
        
        // Video details
        public string VideoTitle { get; set; } = string.Empty;
        public string? VideoThumbnailUrl { get; set; }
        
        // Calculated properties
        public decimal ProgressPercentage => DurationSeconds > 0 ? (decimal)ProgressSeconds / DurationSeconds * 100 : 0;
        public bool IsContinueWatching => !IsCompleted && ProgressSeconds > 0 && ProgressPercentage < 90;
    }
}