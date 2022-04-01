public class ButtonHandler
{
    private readonly DiscordSocketClient _client;

    public ButtonHandler(DiscordSocketClient client)
    {
        _client = client;
        _client.ButtonExecuted += ButtonExecuted;
        _client.InteractionCreated += _client_InteractionCreated;
    }

    private Task _client_InteractionCreated(SocketInteraction arg)
    {
        return Task.CompletedTask;
    }

    private async Task ButtonExecuted(SocketMessageComponent component)
    {
        
    }
}
