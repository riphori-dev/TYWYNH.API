using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tywynh.Features.Common
{
    public class AppMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public AppMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

            dynamic handler = _serviceProvider.GetService(handlerType);

            if (handler == null)
                throw new Exception($"Handler not found for {request.GetType().Name}");

            return await handler.Handle((dynamic)request);
        }
    }
}
