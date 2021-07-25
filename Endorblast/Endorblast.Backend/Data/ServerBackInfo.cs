using System.Collections.Generic;
using System.Net;
using Endorblast.Library.Enums;

namespace Endorblast.Backend
{
    public class ServerBackInfo
    {
        public long token;
        public ServerTypes serverType;


        public List<IPEndPoint> connectedClients;

        public IPEndPoint[] address;

        public ServerBackInfo(IPEndPoint[] addresses)
        {
            address = addresses;
            connectedClients = new List<IPEndPoint>();
        }
    }
}