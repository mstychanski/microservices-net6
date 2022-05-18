namespace Core.Domain
{
    public abstract class SearchCriteria
    {
        public Order OrderBy { get; set; }
    }

    public enum Order
    {
        Ascending,
        Descending
    }

}