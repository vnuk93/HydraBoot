using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Boot;
using System.Xml.Serialization;

namespace HydraBoot.Server.Controllers
{
    class HydraBootController : SrvBoot.SrvBootBase
    {
        MainCore _ = new MainCore();
        public override Task<GetO> Get(GetI request, ServerCallContext context)
        {
            var data = _.GetConfig(request.Service);
            Console.WriteLine("> Service configuration " + data.name);
            return Task.FromResult(new GetO { 
            
                ModelVersion = data.modelVersion,
                Name = data.name,
                Description = data.description,
                Packages = data.packages,
                Version = data.version,
                Port = data.port,
                RelativePath = data.relativePath,
                Group = data.group
            });
        }

    }
}
