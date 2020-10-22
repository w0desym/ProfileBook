namespace ProfileBook
{
    public interface ISettingsManager
    {
        int CurrentUser { get; set; }
        int Sorting { get; set; }
        int Theme { get; set; }
        string Language { get; set; }
    }
}
