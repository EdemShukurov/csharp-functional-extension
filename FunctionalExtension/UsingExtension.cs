using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalExtension
{
    public static class UsingExtension
    {
        public static TOut Using<TIn, TOut>(this TIn self, Func<TIn, TOut> map)
            where TIn : IDisposable
        {
            var result = map(self);
            self.Dispose();
            return result;
        }
    }
}
