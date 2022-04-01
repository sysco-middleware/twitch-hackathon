public class MessageHandler
{
    private readonly DiscordSocketClient _client;


    // Retrieve client and CommandService instance via ctor
    public MessageHandler(DiscordSocketClient client)
    {
        _client = client;
        _client.MessageReceived += HandleCommandAsync;
        _client.ReactionAdded += ReactionAdded;
        _client.ReactionRemoved += ReactionRemoved;

    }

    // Reaction to a message removed
    private Task ReactionRemoved(Cacheable<IUserMessage, ulong> arg1, Cacheable<IMessageChannel, ulong> arg2, SocketReaction arg3)
    {
        return Task.CompletedTask;
    }

    // Reaction to a message added
    private Task ReactionAdded(Cacheable<IUserMessage, ulong> arg1, Cacheable<IMessageChannel, ulong> arg2, SocketReaction arg3)
    {
        return Task.CompletedTask;
    }

    private async Task HandleCommandAsync(SocketMessage messageParam)
    {
        var guild = _client.GetGuild(811714891563008030); // Mammoth Herd ID

        // Don't process the command if it was a system message
        var message = messageParam as SocketUserMessage;
        if (message == null) return;

        if(message.Channel is SocketDMChannel)
        {
           // Handle message sent in DM
        }
        else if(message.Channel is SocketChannel)
        {
            var channelMessage = message.Channel as SocketChannel;
            // Handle channel message
        }
    }
}