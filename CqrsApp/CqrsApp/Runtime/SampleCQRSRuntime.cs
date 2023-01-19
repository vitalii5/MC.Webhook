using SimpleCqrs.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleCqrs;
using SimpleCqrs.Eventing;
using SimpleCqrs.EventStore.SqlServer;
using SimpleCqrs.EventStore.SqlServer.Serializers;
using System.Configuration;

namespace CqrsApp.Runtime
{
    public class SampleCQRSRuntime : SimpleCqrs.SimpleCqrsRuntime<UnityServiceLocator>
    {
        protected override IEventStore GetEventStore(IServiceLocator serviceLocator)
        {
            var configuration = new SqlServerConfiguration(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            return new SqlServerEventStore(configuration, new JsonDomainEventSerializer());
        }
    }
}