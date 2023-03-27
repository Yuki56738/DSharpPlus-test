using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.VoiceNext;

namespace DShardPlus_proj;

public class SlashCommands : ApplicationCommandModule
{
    [SlashCommand("test", "A slash command made to test the DSharpPlus Slash Commands extension!")]
    public async Task TestCommand(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Success!"));
    }
    [SlashCommand("join", "Connect to VC.")]
    public async Task JoinCommand(InteractionContext ctx)
    {
        // await ctx.CreateResponseAsync("Connecting...");
        await ctx.DeferAsync();
        var channel = ctx.Member.VoiceState.Channel;
        
        await channel.ConnectAsync().ContinueWith(async task =>
        {
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Connected."));

        });
        
        
        
        // await ctx.FollowUpAsync(new DiscordFollowupMessageBuilder().WithContent("Connected."));
        // await ctx.Channel.SendMessageAsync("Connected.");
        // await ctx.CreateResponseAsync("Conntected.");
        // await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Connected."));
        // await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Conntected."));
    }
    
}