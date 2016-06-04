using Microsoft.AspNetCore.Mvc;

namespace aspnetconf.presentation.api.Controllers
{
    [Route("api")]
    public class AspNetConfController : Controller
    {
        [HttpGet]
        [Route("log")]
        public string Log()
        {
            return "Obrigado pela participação.";
        }

        [HttpGet]
        [Route("log-get")]
        public string LogGet()
        {
            return "Obrigado pela participação.";
        }

        [HttpGet]
        [Route("log-asp")]
        public string LogAsp()
        {
            return "Obrigado pela participação.";
        }

        [HttpGet]
        [Route("log-net")]
        public string LogNet()
        {
            return "Obrigado pela participação.";
        }

        [HttpGet]
        [Route("log-conf")]
        public string LogConf()
        {
            return "Obrigado pela participação.";
        }

        [HttpGet]
        [Route("log-log")]
        public string LogLog()
        {
            return "Obrigado pela participação.";
        }

        [HttpGet]
        [Route("log-a")]
        public string LogA()
        {
            return "Obrigado pela participação.";
        }
    }
}
