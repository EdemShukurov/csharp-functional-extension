using System;

namespace FunctionalExtension
{
    public static class BindExtension
    {
        public static R Bind<T,R>(Func<T, R> nextFunction, T input)
        {
            if(input == null)
            {
                return default(R);
            }

            return nextFunction(input);
        }
    }
}
