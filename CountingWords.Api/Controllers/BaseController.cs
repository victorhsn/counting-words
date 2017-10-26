using CountingWords.Shared.FluentValidator;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CountingWords.Api.Controllers
{
    public class BaseController : ApiController
    {
        public async Task<IHttpActionResult> Response(object result, IEnumerable<Notification> notifications)
        {

            if (!notifications.Any())
            {
                return Ok(result);
            }
            else
            {
                var json = JsonConvert.SerializeObject(notifications);
                return BadRequest(json);
            }
        }
    }
}
