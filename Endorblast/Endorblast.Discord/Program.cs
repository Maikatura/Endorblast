using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Endorblast.DBase.Discord
{
    internal class Program
    {
        
        
        public static void Main(string[] args)
        {
            var prog = new Bot();
            prog.RunBotAsync().GetAwaiter().GetResult();
        }
        
        
    }
    
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("prefix")]
        public string CommandPrefix { get; private set; }
    }
}