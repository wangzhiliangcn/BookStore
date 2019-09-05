using BookStore.Core.SharedKernel;

namespace BookStore.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}