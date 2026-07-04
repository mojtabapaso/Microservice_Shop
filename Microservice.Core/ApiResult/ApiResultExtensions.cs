using Microsoft.AspNetCore.Mvc;

namespace Microservice.Core.ApiResult;

public static class ApiResultExtensions
{
    public static IActionResult ToApiResult(this ServiceResult result)
    {
        return new ObjectResult(result)
        {
            StatusCode = result.StatusCode
        };
    }

}