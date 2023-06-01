namespace GMS.Core.WebHost.Models.Infrastructure
{
    public class ResponseWrapper<TContent>
    {

        public ResponseWrapper(TContent content, Pagination paging = null)
        {
            Success = true;
            Content = content;
            Paging = paging;
        }

        public ResponseWrapper(string error)
        {
            Success = false;
            Error = error;
        }

        public bool Success { get; set; }
        public string Error { get; set; }
        public Pagination Paging { get; set; }

        public TContent Content { get; set; }
    }
}
