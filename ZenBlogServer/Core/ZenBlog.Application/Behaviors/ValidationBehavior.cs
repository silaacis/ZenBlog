using FluentValidation;
using MediatR;

namespace ZenBlog.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                    validators.Select(x => x.ValidateAsync(context, cancellationToken)));

                var failures = validationResults.Where(result => result is not null)
                    .SelectMany(x=>x.Errors)
                    .ToList();

                if(failures.Any())
                {
                    var errorDetails = failures
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(x => x.Key, x => x.Select(v => v.ErrorMessage).ToArray())
                        .ToList();
                    throw new ValidationException(failures);
                }
            }

            return await next(cancellationToken);
        }
    }
}
