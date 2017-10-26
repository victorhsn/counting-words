using CountingWords.Domain.CommandHandlers;
using CountingWords.Domain.Commands;
using CountingWords.Log.Logging;
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
            Logging.LogInfo(GetType(), "The method post executed");
            Logging.LogInfo(GetType(), $"Values:{command.Sentence}");

            var result = _handler.Handle(command);

            return await Response(result, _handler.Notifications);
        }
    }
}
