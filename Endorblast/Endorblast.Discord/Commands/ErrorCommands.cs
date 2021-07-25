using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;


namespace Endorblast.DBase.Discord
{
    public class ErrorCommands : BaseCommandModule
    {
        [Command("error"), Description("Check what a error code means")]
        public async Task ReserveName(CommandContext ctx, DiscordChannel chn = null)
        {
            
        }
    }
}