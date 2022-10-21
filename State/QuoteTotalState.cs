namespace QuoteEditorBlazor.State;

public class QuoteTotalState
{
    public event Action? TotalChanged;

    public void NotifyTotalChanged()
    {
        TotalChanged?.Invoke();
    }
}
