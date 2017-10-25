using System;
using System.Threading.Tasks;
using CQRSlite.Domain;
using CQRSlite.Domain.Exception;
using CQRSlite.Tests.Substitutes;
using Xunit;

namespace CQRSlite.Tests.Domain
{
    public class WhenGettingEventsOutOfOrder
    {
	    private readonly ISession _session;

        public WhenGettingEventsOutOfOrder()
        {
            var eventStore = new TestEventStoreWithBugs();
            _session = new Session(new Repository(eventStore));
        }

        [Fact]
        public async Task Should_throw_concurrency_exception()
        {
            var id = Guid.NewGuid();
            await Assert.ThrowsAsync<EventsOutOfOrderException>(async () => await _session.Get<TestAggregate>(id, 3));
        }
    }
}