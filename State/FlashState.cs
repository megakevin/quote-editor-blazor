namespace QuoteEditorBlazor.State;

public class FlashState
{
    public List<string> Messages { get; private set; } = new List<string>();

    public event Action? MessageAdded;

    public async void AddMessage(string message)
    {
        Messages.Add(message);
        MessageAdded?.Invoke();

        await Task.Delay(TimeSpan.FromSeconds(5));

        Messages.Remove(message);
        MessageAdded?.Invoke();
    }
}