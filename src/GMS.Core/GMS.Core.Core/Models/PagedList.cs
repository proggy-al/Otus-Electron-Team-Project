namespace GMS.Core.WebHost.Models
{
    public class PagedList<T> where T : class
    {
        public List<T> Entities { get; set; }
        public Pagination Pagination { get; set; }
    }
}
