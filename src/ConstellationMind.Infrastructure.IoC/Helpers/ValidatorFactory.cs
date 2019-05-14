using System;
using Autofac;
using FluentValidation;

namespace ConstellationMind.Infrastructure.IoC.Helpers
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private readonly IComponentContext _context;

        public ValidatorFactory(IComponentContext context) 
            => _context = context;

        public override IValidator CreateInstance(Type validator)
        {
            if (!_context.TryResolve(validator, out object instance))
            {
                return null;
            }

            return instance as IValidator;
        }
    }
}
