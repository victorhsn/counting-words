using CountingWords.Domain.CommandHandlers;
using CountingWords.Domain.Commands;
using System.Threading.Tasks;
using System.Web.Http;

namespace CountingWords.Api.Controllers
{

    [RoutePrefix("api")]
    public class PhraseController : BaseController
    {
        private readonly PhraseCommandHandler _handler;

        public PhraseController(PhraseCommandHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/phrase")]
        public async Task<IHttpActionResult> Post([FromBody] PhraseCommand command)
        {
            var result = _handler.Handle(command);

            return await Response(result, _handler.Notifications);
        }
    }
}
