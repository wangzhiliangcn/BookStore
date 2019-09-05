using BookStore.Core.Interfaces;
using BookStore.Core.SharedKernel;

namespace BookStore.UnitTests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public void Dispatch(BaseDomainEvent domainEvent) { }
    }
}
