using System;

namespace FunctionalExtension
{
    public class Maybe<T>
        where T : class
    {
        public T Value { get; private set; }

        public Maybe(T someValue)
        {
            if(someValue == null)
            {
                throw new ArgumentNullException(nameof(someValue));
            }

            Value = someValue;
        }

        public Maybe() { }

        public static Maybe<T> None => new Maybe<T>();
    }
}
