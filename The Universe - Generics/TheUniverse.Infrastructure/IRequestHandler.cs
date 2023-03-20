namespace RemoteLearning.TheUniverse.Infrastructure
{
    public interface IRequestHandler<TRequest, TResponse> where TRequest : notnull
    {
        TResponse Execute(TRequest request);
    }
}