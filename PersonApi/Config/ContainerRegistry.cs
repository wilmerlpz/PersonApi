﻿using StructureMap;
using PersonApi.Repository;
using PersonApi.Services;

namespace PersonApi.Config
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

            For<IPersonService>().Use<PersonService>();
            For<IPersonRepository>().Use<PersonRepository>().Singleton();
        }

    }
}
