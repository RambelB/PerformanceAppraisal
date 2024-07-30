namespace AppraisalWeb.ViewModel;

public class PaginationVM
{
    public int TotalRows { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public int TotalPages
    {
        get
        {
            return (int)Math.Ceiling((double)TotalRows / PageSize);
        }
    }
}
