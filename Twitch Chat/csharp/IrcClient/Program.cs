using System;
using System.Threading;

namespace IrcClient
{
    class Program
    {
        static string server;
        static string serverUsername;
        static string channel;
        static string oauth;
        static int pongs = 0;
        static int count = 0;
        static string rawMessage;
        static void Main(string[] args)
        {
            serverUsername = "<<BotName>>"; // Must be a valid user
            channel = "<<channel>>";
            oauth = "<<OAuth string>>"; // https://twitchapps.com/tmi/
            server = "irc.chat.twitch.tv";

            ircClient irc = new ircClient(server, serverUsername, oauth);
            irc.joinRoom(channel);
            try
            {
                while (true)
                {
                    string message = irc.readMessage();
                    if (!string.IsNullOrEmpty(message) && message.Contains("/NAMES list"))
                    {
                        Console.Title = "Connected to: " + channel + ". Messages: " + count + ". Pongs: " +  pongs;
                        Console.WriteLine("Welcome to TwitchBot");
                        Console.WriteLine(message);
                        irc.sendIrcMessage("CAP REQ :twitch.tv/tags"); // This command enables rich tags in messages
                        break;
                    }
                    else if(!string.IsNullOrEmpty(message))
                        Console.WriteLine(message);
                }
                Thread t = new Thread(() => readChat(irc));
                t.Start();
                Thread send = new Thread(() => sendMessage(irc));
                send.Start();
            }
            catch (Exception x)
            {
                Console.WriteLine("Error: " + x);
            }
            while(true)
            {
                Thread.Sleep(10000);
            }

        }
        static void readChat(ircClient irc)
        {
            while (true)
            {
                try
                {
                    string message = irc.readMessage();
                    rawMessage = message;

                    if (message.Contains("PING"))
                    {
                        irc.sendIrcMessage(message.Replace("PING", "PONG"));
                        Console.WriteLine("PONG message sent");
                        pongs++;
                        Console.Title = "Connected to: " + channel + ". Messages: " + count + ". Pongs: " + pongs;
                    }
                    else // (message != null)
                    {
                        try
                        {
                               // Handle incoming chats here!                            
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: " + ex.Message);
                            Console.WriteLine("Raw message: " + rawMessage);
                            Console.ResetColor();
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("EXP: " + ex.Message);
                }
            }             
        }
        static void sendMessage(ircClient irc)
        {
            while(true)
            {
                string sendingMessage = Console.ReadLine();

                irc.sendChatMessage(sendingMessage);
            }
        }
    }
}
