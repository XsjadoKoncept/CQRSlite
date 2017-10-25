using System;
using System.Threading.Tasks;
using CQRSlite.Domain;
using CQRSlite.Domain.Exception;
using CQRSlite.Tests.Substitutes;
using Xunit;

namespace CQRSlite.Tests.Domain
{
    public class WhenSavingEventsWithoutId
    {
        private readonly TestInMemoryEventStore _eventStore;
        private readonly TestAggregate _aggregate;
        private readonly Repository _rep;

        public WhenSavingEventsWithoutId()
        {
            _eventStore = new TestInMemoryEventStore();
            _rep = new Repository(_eventStore);

            _aggregate = new TestAggregate(Guid.Empty);
        }

        [Fact]
        public async Task Should_throw_aggregate_or_event_missing_id_exception_from_repository()
        {
            await Assert.ThrowsAsync<AggregateOrEventMissingIdException>(async () => await _rep.Save(_aggregate, 0));
        }
    }
}