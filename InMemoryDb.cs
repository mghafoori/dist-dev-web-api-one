using System.Collections.Generic;

namespace WebApiOne
{
    public class InMemoryDb : IInMemoryDb
    {
        private List<string> _summaries = new List<string>
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public List<string> Summaries { get { return _summaries; }  }
    }
}