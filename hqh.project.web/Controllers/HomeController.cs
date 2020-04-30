using hqh.project.Application.IServices.Test;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace hqh.project.web.Controllers
{
    public class HomeController: AbpController
    {
        private ITestService _testService;
        public HomeController(ITestService testService)
        {
            _testService = testService;
        }

        public IActionResult Index()
        {
            return Content("Hello World!");
        }

        public string Test123()
        {
            return _testService.Test123();
        }
    }
}
