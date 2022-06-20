
namespace DurbelALora.Shared
{
    public class PaginationShared<T> where T : class
    {
        public double Count { get; set; }
        public IEnumerable<T> Records { get; set; }
        public int PagesQuantity { get; set; }
    }

    public class PaginationView
    {
        public int Page { get; set; } = 1;
        public int QuantityPerPage { get; set; } = 10;
    }
}
