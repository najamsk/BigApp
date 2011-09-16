using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using BigApp.Domain.Concrete;
using System.Data.Entity.Infrastructure;
using DataServicesJSONP;

namespace BigApp
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [JSONPSupportBehavior]
    public class Big : DataService<BigAppContext>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }

        protected override BigAppContext CreateDataSource()
        {
            var context = base.CreateDataSource();
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.ProxyCreationEnabled = false;
            return context;
        }
    }
}
