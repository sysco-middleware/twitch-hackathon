using Discord.Interactions;

public class Program
{
	private static string _botToken = "<<A BOT TOKEN IS REQUIRED>>";
    private DiscordSocketClient _client;

    public static Task Main(string[] args) => new Program().MainAsync();

    public async Task MainAsync()
	{
		_client = new DiscordSocketClient();
        //var _interactionService = new InteractionService(_client.Rest);

        new LoggingService(_client);
        new ButtonHandler(_client);
        new MessageHandler(_client);

        await _client.LoginAsync(TokenType.Bot, _botToken);
		await _client.StartAsync();

        _client.Ready += Client_Ready;
        new SlashCommandHandler(_client);

        new MiscEventInitializations(_client);

        // Block this task until the program is closed.
        await Task.Delay(-1);
	}

    public async Task Client_Ready()
    {
        var guild = _client.GetGuild(834495082446585886); // Cegal Sysco Gaming ID
        
        // Next, lets create our slash command builder. This is like the embed builder but for slash commands.
        var myCommand = new SlashCommandBuilder()
                                                .WithName("my-command")
                                                .WithDescription("This is my first slash command")
                                                .AddOption("picture", ApplicationCommandOptionType.Attachment, "The picture you want to attach", isRequired: true);

        var anotherCommand = new SlashCommandBuilder()
                                                        .WithName("another-command")
                                                        .WithDescription("This is my second command")
                                                        .AddOption("name", ApplicationCommandOptionType.String, "My name", isRequired: true)
                                                        .AddOption("Employee", ApplicationCommandOptionType.Boolean, "Are you an employee?", isRequired: true)
                                                        .AddOption("Age", ApplicationCommandOptionType.Integer, "What's your name?", minValue: 1, maxValue:  120);

        try
        {
            // Now that we have our builder, we can call the CreateApplicationCommandAsync method to make our slash command.
            await guild.CreateApplicationCommandAsync(myCommand.Build());
            await guild.CreateApplicationCommandAsync(anotherCommand.Build());
        }
        catch (HttpException exception)
        {
            // If our command was invalid, we should catch an ApplicationCommandException. This exception contains the path of the error as well as the error message. You can serialize the Error field in the exception to get a visual of where your error is.
            var json = JsonConvert.SerializeObject(exception.Reason, Formatting.Indented);

            // You can send this error somewhere or just print it to the console, for this example we're just going to print it.
            Console.WriteLine(json);
        }
    }
}