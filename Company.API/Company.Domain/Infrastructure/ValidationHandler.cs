﻿using FluentValidation;
using MediatR;
using System.Linq;

namespace Company.Domain.Infrastructure
{
    public class ValidatorHandler<TAsyncRequest, TResponse>
        : IAsyncRequestHandler<TAsyncRequest, TResponse> 
        where TAsyncRequest : IRequest<TResponse>
    {

        private readonly IAsyncRequestHandler<TAsyncRequest, TResponse> _inner;
        private readonly IValidator<TAsyncRequest>[] _validators;

        public ValidatorHandler(
            IAsyncRequestHandler<TAsyncRequest, TResponse> inner,
            IValidator<TAsyncRequest>[] validators
            )
        {
            _inner = inner;
            _validators = validators;
        }

        public TResponse Handle(TAsyncRequest request)
        {
            var context = new ValidationContext(message);

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