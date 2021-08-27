using System.Collections.Generic;

namespace WebApiOne
{
    public interface IInMemoryDb
    {
        List<string> Summaries { get; }
    }
}