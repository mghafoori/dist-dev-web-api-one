using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SummariesController : ControllerBase
    {
        private readonly IInMemoryDb _inMemoryDb;

        public SummariesController(IInMemoryDb inMemoryDb)
        {
            _inMemoryDb = inMemoryDb;
        }

        [HttpGet]
        public IEnumerable<string> GetEnumerable()
        {
            return _inMemoryDb.Summaries;
        }

        [HttpPost] 
        public IActionResult Add([FromBody] string summary)
        {
            if(_inMemoryDb.Summaries.Contains(summary))
            {
                return new ConflictResult();
            }
            _inMemoryDb.Summaries.Add(summary);
            return new OkResult();
        }

        [HttpPut]
        public IActionResult Update([FromBody] SummaryUpdate model)
        {
            if(_inMemoryDb.Summaries.Contains(model.New))
            {
                return new ConflictResult();
            }
            if (!_inMemoryDb.Summaries.Contains(model.Old))
            {
                return new NotFoundResult();
            }
            var index = _inMemoryDb.Summaries.IndexOf(model.Old);
            _inMemoryDb.Summaries[index] = model.New;
            return new OkResult();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] string summary)
        {
            if (!_inMemoryDb.Summaries.Contains(summary))
            {
                return new NotFoundResult();
            }
            _inMemoryDb.Summaries.Remove(summary);
            return new OkResult();
        }
    }

    public class SummaryUpdate
    {
        public string Old { get; set; }
        public string New { get; set; }
    }
}