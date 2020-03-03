namespace OnlineStep.Models
{
    public interface IPage
    {
        string _id { get; set; }
        string type { get; set; }
        string title { get; set; }
        string author { get; set; }
    }

}
