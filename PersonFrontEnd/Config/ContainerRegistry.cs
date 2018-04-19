using StructureMap;
using PersonFrontEnd.Services;

namespace PersonFrontEnd.Config
{
    public class ContainerRegistry : Registry
    {
        public ContainerRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });

            For<IPersonsService>().Use<PersonsService>();
        }
    }
}
