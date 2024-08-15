namespace TrelloApp.Models
{
    public class ErrorViewModel
    {
        //soy giliposha
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
