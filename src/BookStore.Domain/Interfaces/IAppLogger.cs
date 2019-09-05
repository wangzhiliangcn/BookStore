using System;

namespace BookStore.Domain.Interfaces
{
    public interface IAppLogger<T>
    {
        void Warn(string message, params object[] args);

        void Info(string message, params object[] args);

        void Error(string message, params object[] args);

        void Error(Type type, string message, params object[] args);
    }
}
