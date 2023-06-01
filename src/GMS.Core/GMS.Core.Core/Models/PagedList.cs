namespace GMS.Core.WebHost.Models
{
    public class PagedList<T> 
    {
        public List<T> Entities { get; set; }
        public Pagination Pagination { get; set; }
    }
}
