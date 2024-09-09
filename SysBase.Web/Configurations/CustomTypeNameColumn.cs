using Serilog.Core;
using Serilog.Events;

namespace SysBase.Web.Configurations
{
    public class CustomTypeNameColumn : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var (typename, value) = logEvent.Properties.FirstOrDefault(x => x.Key == "TypeName");
            if (value != null)
            {
                var getValue = propertyFactory.CreateProperty(typename, value);
                logEvent.AddPropertyIfAbsent(getValue);
            }
        }
    }
}
