namespace NetFilmx_User.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string? ErrorMessage { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public bool HasErrors => !string.IsNullOrEmpty(ErrorMessage) || Errors.Any();
    }
}