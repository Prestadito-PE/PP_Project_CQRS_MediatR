namespace Prestadito.Menu.API.Features.Behavior
{
    using MediatR;
    using FluentValidation;

    public class ValidationBehavior<TRequest, TResponse>: IPipelineBehavior<TRequest,TResponse>
        where TRequest: IRequest<TResponse>
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationBehavior(IValidator<TRequest> validator)
        {
            this._validator = validator;
        }
        
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await this._validator.ValidateAndThrowAsync(request, cancellationToken);
            var response = await next();
            return response;
        }
    }
}

