using System;
using System.Collections.Generic;

namespace RemoteLearning.TheUniverse.Infrastructure
{
    public class RequestBus
    {
        private readonly Dictionary<Type, Type> handlers = new Dictionary<Type, Type>();

        public void RegisterHandler<TRequest, TResponse, TRequestHandler>()
            where TRequest : notnull
            where TRequestHandler : IRequestHandler<TRequest, TResponse>
        {
            Type requestType = typeof(TRequest);
            Type requestHandlerType = typeof(TRequestHandler);

            if (handlers.ContainsKey(requestType))
                throw new ArgumentException("requestType is already registered.", nameof(requestType));

            handlers.Add(requestType, requestHandlerType);
        }

        public TResponse Send<TRequest, TResponse>(TRequest request) where TRequest : notnull
        {
            Type requestType = typeof(TRequest);

            if (!handlers.ContainsKey(requestType))
                throw new Exception("Request handler not registered for the specified request.");

            Type requestHandlerType = handlers[requestType];

            IRequestHandler<TRequest, TResponse> requestHandler = (IRequestHandler<TRequest, TResponse>)Activator.CreateInstance(requestHandlerType);

            return requestHandler.Execute(request);
        }
    }

}