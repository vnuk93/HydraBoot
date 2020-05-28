using System;
using System.Collections.Generic;
using System.Text;
using Grpc.Core;
using Boot;

namespace HydraBoot.Client
{
    public class MainCore
    {

        public MainCore(string IP, string port)
        {
            Channel channel = new Channel(IP + ":" + port, ChannelCredentials.Insecure); //Creamos un nuevo canal de cliente incresando direccion y puerto del servidor
            client = new SrvBoot.SrvBootClient(channel); //Creamos un nuevo cliente, pasandole el servicio de proto (Greeter) y junto con el canal.

            //channel.ShutdownAsync().Wait();
        }

        SrvBoot.SrvBootClient client;

        public GetO Get(string getService)
        {
            var _out = client.Get(new GetI { Service = getService });
            return _out;
        }
    }
}