using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var idVal = context.ActionArguments.Values.FirstOrDefault();

            if (idVal == null)
            {
                await next.Invoke();
                return;
            }
            var id = (int)idVal;
            var anyEntity = await _service.AnyAsync(x=> x.Id == id);
            if (anyEntity)
            {
                await next.Invoke();
            }

            
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail($"{typeof(T).Name} not found",404));
        }
    }
}
