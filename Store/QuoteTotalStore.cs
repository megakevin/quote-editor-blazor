namespace QuoteEditorBlazor.Store;

public class QuoteTotalStore
{
    public event Action? TotalChanged;

    public void NotifyTotalChanged()
    {
        TotalChanged?.Invoke();
    }
}
