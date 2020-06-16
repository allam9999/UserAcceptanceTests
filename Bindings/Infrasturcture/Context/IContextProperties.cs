using System.Net.Http;

namespace Bindings.Context
{
    public interface IContextProperties
    {
        HttpResponseMessage Response { get; set; }
        string Url { get; set; }
    }
}