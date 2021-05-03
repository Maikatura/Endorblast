using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace Endorblast.DBase.Discord
{
    public class CharacterCommands : BaseCommandModule
    {
        [Command("reservename"), Description("Reserve a name for a character.")]
        public async Task ReserveName(CommandContext ctx, DiscordChannel chn = null)
        {
            ctx.Channel.SendMessageAsync("I dont have that function yet :)");
        }

        [Command("character"), Description("check a characters information.")]
        public async Task Character(CommandContext ctx, string name)
        {
            var charaInfo = LoadCharacterByNameCmd.GrabCharacterByName(name);

            string infoString = "Name: " + charaInfo.CharacterName + "\n";
            infoString += "Rank: " + charaInfo.RoleTag;

            ctx.Channel.SendMessageAsync(infoString);

        }
    }
}