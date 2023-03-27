using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using DSharpPlus.SlashCommands;
using DSharpPlus.VoiceNext;


namespace DShardPlus_proj;

public class Program
{
    static async Task Main()
    {
        var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = Environment.GetEnvironmentVariable("DISCORD_TOKEN"),
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All,
            MinimumLogLevel = LogLevel.Debug
        });
        var slash = discord.UseSlashCommands();
        slash.RegisterCommands<DShardPlus_proj.SlashCommands>(977138017095520256);
        discord.UseVoiceNext();
        discord.Ready += DiscordOnReady;
        await discord.ConnectAsync();
        await Task.Delay(-1);
    }

    private static Task DiscordOnReady(DiscordClient sender, ReadyEventArgs args)
    {
        Console.WriteLine("Bot is ready.");
        return Task.CompletedTask;
        // throw new NotImplementedException();
    }
}