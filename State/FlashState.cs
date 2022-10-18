namespace QuoteEditorBlazor.State;

public class FlashState
{
    public List<string> Messages { get; private set; } = new List<string>();

    public event Action? MessageAdded;

    public void AddMessage(string message)
    {
        Messages.Add(message);
        MessageAdded?.Invoke();
    }
}