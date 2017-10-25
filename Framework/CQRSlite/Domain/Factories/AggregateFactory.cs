using CQRSlite.Domain.Exception;
using System;

namespace CQRSlite.Domain.Factories
{
    internal static class AggregateFactory
    {
        public static T CreateAggregate<T>()
        {
            try
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            catch (MissingMethodException)
            {
                throw new MissingParameterLessConstructorException(typeof(T));
            }
        }
    }
}