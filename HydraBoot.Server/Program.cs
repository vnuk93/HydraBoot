using System;
using System.Threading.Tasks;
using Grpc.Core;
using Boot;
using HydraBoot.Server.Controllers;

namespace HydraBoot.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("> Starting HydraBoot");
            MainCore _ = new MainCore();
            var config = _.GetConfig("HydraBoot");
            Grpc.Core.Server server = new Grpc.Core.Server
            {
                Services = { SrvBoot.BindService(new HydraBootController()) }, //Bindea los metodos del codigo "Impl" con los servicio generado por proto (En este caso con el service Greeter de proto)
                Ports = { new ServerPort("localhost", config.port, ServerCredentials.Insecure) } //asignacion de direccion, puerto y seguridad
            };
            server.Start();

            Console.WriteLine("> HydraBoot server listening on port " + config.port);
            Console.ReadKey();

            server.ShutdownAsync().Wait();



        }
    }
}
