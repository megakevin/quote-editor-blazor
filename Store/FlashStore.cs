namespace QuoteEditorBlazor.Store;

public class FlashStore
{
    public List<string> Messages { get; private set; } = new List<string>();

    public event Action? MessagesChanged;

    public async void AddMessage(string message)
    {
        Messages.Add(message);
        MessagesChanged?.Invoke();

        await Task.Delay(TimeSpan.FromSeconds(5));

        Messages.Remove(message);
        MessagesChanged?.Invoke();
    }
}