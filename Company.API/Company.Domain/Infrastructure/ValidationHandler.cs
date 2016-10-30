using FluentValidation;
using MediatR;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Company.Domain.Infrastructure
{
    public class ValidationHandler<TAsyncRequest, TResponse>
        : IAsyncRequestHandler<TAsyncRequest, TResponse>
        where TAsyncRequest : IAsyncRequest<TResponse>
    {

        private readonly IAsyncRequestHandler<TAsyncRequest, TResponse> _inner;
        private readonly IValidator<TAsyncRequest>[] _validators;

        public ValidationHandler(
            IAsyncRequestHandler<TAsyncRequest, TResponse> inner,
            IValidator<TAsyncRequest>[] validators
            )
        {
            _inner = inner;
            _validators = validators;
        }


        Task<TResponse> IAsyncRequestHandler<TAsyncRequest, TResponse>.Handle(TAsyncRequest request)
        {
            var context = new ValidationContext(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
                throw new ValidationException(failures);

            return _inner.Handle(request);
        }

    }

}
