using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Dis
{

    class Program
    {

        static void Main(string[] args)
        {
            MainAsyn().ConfigureAwait(false).GetAwaiter().GetResult();

            Console.Read();
        }
        static DiscordClient discord;
        static CommandsNextModule commands;


        static async Task MainAsyn()
        {
            string _Token = "";
            string url = @"C:\Users\stepa\OneDrive\Рабочий стол\TokenBot.txt";
            using (StreamReader sr = new StreamReader(url))
            {
                _Token = sr.ReadToEnd();
            }
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = _Token,
                TokenType = TokenType.Bot,

            });
            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "!"
            });
            commands.RegisterCommands<MyCommands>();

            discord.MessageCreated += async e =>
            {
                DiscordGame game = new DiscordGame();
                
                var html = @"https://topcraft.ru/servers/308/servers/";

                HtmlWeb web = new HtmlWeb();

                var htmlDoc = web.Load(html);
                string[] OnlServers = new string[15];
                string OnlServersStr = "";

                var nodes = htmlDoc.DocumentNode.SelectNodes("//span[@class='online']");
                int count = 0;

                foreach (var node in nodes)
                {
                    OnlServers[count] = node.InnerText;
                    OnlServersStr += OnlServers[count] + "\n";
                    count++;
                }
                game.Name = "TM (" + OnlServers[3] + ")";

                await discord.UpdateStatusAsync(game);
            };
            

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }


    }

}



