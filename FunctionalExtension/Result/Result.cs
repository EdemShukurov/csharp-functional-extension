using System;

namespace FunctionalExtension.Common
{
    public struct Result<T>
    {
        private readonly T _value;

        private ResultType _resultType;

        /// <summary>
        /// Error
        /// </summary>
        public Exception Error { get; }

        /// <summary>
        /// True, if the result is faulted.
        /// </summary>
        public bool IsFaulted => _resultType == ResultType.Faulted;

        /// <summary>
        /// True, if the result is succeded.
        /// </summary>
        public bool IsSuccess => _resultType == ResultType.Success;

        public T Value
        {
            get
            {
                if (_resultType == ResultType.Faulted)
                {
                    throw Error;
                }

                return _value;
            }
        }

        public Result(T value)
        {
            _resultType = ResultType.Success;
            _value = value;
            Error = null;
        }

        public Result(Exception exception)
        {
            Error = exception;
            _value = default;
            _resultType = ResultType.Faulted;
        }

        /// <summary>
        /// Implicit conversion operator from A to Result<A>
        /// </summary>
        /// <param name="value">Value</param>
        public static implicit operator Result<T>(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Fail(Exception exception) => new Result<T>(exception);
    }
}
