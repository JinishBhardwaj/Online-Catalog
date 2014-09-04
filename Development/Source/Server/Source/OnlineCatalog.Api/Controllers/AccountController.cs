using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using OnlineCatalog.Api.Models;
using OnlineCatalog.Service.Contracts;
using Model = OnlineCatalog.Data.Model;

namespace OnlineCatalog.Api.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        [Route("Signup")]
        public async Task<IHttpActionResult> Signup(SignupModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = Mapper.Map<SignupModel, Model.User>(model);
            var userService = ServiceLocator.Current.GetInstance<IUserService>();

            var result = await userService.CreateUser(user, model.Password);
            IHttpActionResult errorResult = GetErrorResult(result);
            if (errorResult != null)
            {
                return errorResult;
            }
            return Ok();
        }
    }
}
