using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Endorblast.DBase.Discord
{
    public class Bot
    {
        public readonly EventId BotEventId = new EventId(42, "Bot-Ex04");
        
        public DiscordClient Client { get; set; }
        public CommandsNextExtension Commands { get; set; }
        //public VoiceNextExtension Voice { get; set; }
        

        public async Task RunBotAsync()
        {
            // first, let's load our configuration file
            var json = "";
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();

            // next, let's load the values from that file
            // to our client's configuration
            var cfgjson = JsonConvert.DeserializeObject<ConfigJson>(json);
            var cfg = new DiscordConfiguration
            {
                Token = cfgjson.Token,
                TokenType = TokenType.Bot,

                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };

            // then we want to instantiate our client
            this.Client = new DiscordClient(cfg);

            // next, let's hook some events, so we know
            // what's going on
            // this.Client.Ready += this.Client_Ready;
            // this.Client.GuildAvailable += this.Client_GuildAvailable;
            // this.Client.ClientErrored += this.Client_ClientError;

            // up next, let's set up our commands
            var ccfg = new CommandsNextConfiguration
            {
                // let's use the string prefix defined in config.json
                StringPrefixes = new[] { cfgjson.CommandPrefix },

                // enable responding in direct messages
                EnableDms = true,

                // enable mentioning the bot as a command prefix
                EnableMentionPrefix = true
            };

            // and hook them up
            this.Commands = this.Client.UseCommandsNext(ccfg);

            // let's hook some command events, so we know what's 
            // going on
            //this.Commands.CommandExecuted += this.Commands_CommandExecuted;
            //this.Commands.CommandErrored += this.Commands_CommandErrored;

            // up next, let's register our commands
            this.Commands.RegisterCommands<CharacterCommands>();

            // let's enable voice
            //this.Voice = this.Client.UseVoiceNext();

            // finally, let's connect and log in
            await this.Client.ConnectAsync();

            // for this example you will need to read the 
            // VoiceNext setup guide, and include ffmpeg.

            // and this is to prevent premature quitting
            await Task.Delay(-1);
        }
    }
}