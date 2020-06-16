using System.Net.Http;

namespace Bindings.Context
{
    public class ContextProperties:IContextProperties
    {
        public HttpResponseMessage Response { get; set; }
        public string Url { get; set; }   
    }
}