namespace QuoteEditorBlazor.AppState;

public class QuoteTotalEventBus
{
    public event Action? TotalChanged;

    public void NotifyTotalChanged()
    {
        TotalChanged?.Invoke();
    }
}
