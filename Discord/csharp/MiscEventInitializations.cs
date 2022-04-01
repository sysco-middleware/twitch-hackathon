public class MiscEventInitializations
{
    public MiscEventInitializations(DiscordSocketClient client)
    {
        client.GuildScheduledEventStarted += _client_GuildScheduledEventStarted;
        client.InviteCreated += _client_InviteCreated;
    }
    private Task _client_GuildScheduledEventStarted(SocketGuildEvent arg)
    {
        return Task.CompletedTask;
    }

    private Task _client_InviteCreated(SocketInvite arg)
    {
        return Task.CompletedTask;
    }
}