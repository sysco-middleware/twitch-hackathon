public class SlashCommandHandler
{
    DiscordSocketClient _client;
    public SlashCommandHandler(DiscordSocketClient client)
    {
        _client = client;
        client.SlashCommandExecuted += SlashCommandAsync;
    }
    
    private async Task SlashCommandAsync(SocketSlashCommand command)
    {
        // Handle slash command!
        if (command.CommandName.Equals("my-command"))
        {
            await command.RespondAsync($"I've received your request, {command.User.Username}. This is my result.");

            dynamic imgUrl = command.Data.Options.First().Value;
            var uri = imgUrl.Url; // This is the uri to the uploaded image

            var embed = new EmbedBuilder
            {
                Color = Color.Orange,
                Description = "A delayed follow-up with an embedded message",
                ImageUrl = "https://cdn.icon-icons.com/icons2/510/PNG/512/at_icon-icons.com_50456.png",
                Title = "Picture description"
            };
            await command.FollowupAsync(embed: embed.Build());
        }
        else if (command.CommandName.Equals("another-command"))
        {
            // Handle my other command

            var name = command.Data.Options.First(x => x.Name.Equals("name")).Value as string;
            var employee = (bool)command.Data.Options.First(x => x.Name.Equals("private")).Value;
            var age = (Int64)command.Data.Options.First(x => x.Name.Equals("timeout")).Value;

            await command.RespondAsync("Working on it....");

            // Do a lot of work

            await command.FollowupAsync("Here is my final result!");
            await command.DeleteOriginalResponseAsync();
        }
    }
}