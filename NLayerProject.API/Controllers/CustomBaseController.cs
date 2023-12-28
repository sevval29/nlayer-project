using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.DTOs;

namespace NLayerProject.API.Controllers
{

    public class CustomBaseController : ControllerBase
    {
        [NonAction] //bu attribute ile artık bu swagger tarafında gözükmez.
        public IActionResult CreateActionResult<T>(CustomResponseData<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
