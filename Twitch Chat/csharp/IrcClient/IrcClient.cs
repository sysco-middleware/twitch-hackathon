using System.IO;
using System.Net.Sockets;
using System.Net;

namespace IrcClient
{
    class ircClient
    {
        private string userName;
        private string channel;
        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;
        private string address = "";
        private int port = 6667;
        private string oauthKey = ""; 

        public ircClient(string ip, string userName, string oauth)
        {
            this.oauthKey = oauth;
            this.userName = userName;
            tcpClient = new TcpClient(ip, port);
            address = ((IPEndPoint)tcpClient.Client.LocalEndPoint).Address.ToString();
            inputStream = new StreamReader(tcpClient.GetStream());
            outputStream = new StreamWriter(tcpClient.GetStream());
            outputStream.WriteLine("PASS oauth:" + oauthKey);
            outputStream.WriteLine("NICK " + userName);
            outputStream.Flush();

        }
        public void joinRoom(string channel)
        {
            this.channel = channel;
            outputStream.WriteLine("JOIN #" + channel);
            outputStream.Flush();

        }
        public void sendIrcMessage(string message)
        {
            outputStream.WriteLine(message);
            outputStream.Flush();

        }
        public void sendChatMessage(string message)
        {
            sendIrcMessage(":" + userName + "!" + userName + "@" + userName + "." + channel + ".no PRIVMSG #" + channel + " :" + message);
        }

        public void SendWhisper(string message, string recipient)
        {
            sendChatMessage($"/w {recipient} {message}");
        }
        public void kickUser(string user, string channel, string reason)
        {
            sendIrcMessage(":" + userName + "!" + userName + "@" + userName + "." + channel + ".no KICK #" + channel + " " + user + " :" + reason);
        }
        public string readMessage()
        {
            string message = inputStream.ReadLine();
            return message;
        }
        public string getIP()
        {
            return address;
        }
    }
}
