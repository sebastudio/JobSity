using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TripSity.Model;
using TripSity.AzureBlob;
using System.Threading.Tasks;

namespace TripSity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        private readonly IFileManagerLogic _fileManagerLogic;

        public TripController(IFileManagerLogic fileManagerLogic)
        {
            _fileManagerLogic = fileManagerLogic;
        }
        private readonly ILogger<TripController> _logger;

        public TripController(ILogger<TripController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<TripItem> Get()
        {
            return TripContext.Trips.ToArray();
        }
        [HttpGet]
        [Route("/Trip/Average")]
        public object Average()
        {
            var items =
                from trip in TripContext.Trips
                group trip by trip.Region into tripGroup
                orderby tripGroup.Key
                select new
                {
                    Region = tripGroup.Key,
                    Average = tripGroup.Count() / 7
                };
            return items;
        }
        [HttpGet]
        [Route("/Trip/ByOrigin")]
        public object ByOrigin()
        {
            var items = TripContext.Trips.OrderBy(a => a.Region).ThenBy(a => a.DateTimeTrip);
            return items;
        }
        [Route("upload")]
        [HttpPost]
        public async Task<ActionResult> Upload([FromForm]FileModel csvFile)
        {
            if (csvFile.CsvFile != null)
            {
                await _fileManagerLogic.Upload(csvFile);
            }
            return Ok();
        }
    }
}
