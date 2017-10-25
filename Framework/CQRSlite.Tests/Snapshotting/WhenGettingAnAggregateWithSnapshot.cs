using System;
using CQRSlite.Domain;
using CQRSlite.Snapshotting;
using CQRSlite.Tests.Substitutes;
using Xunit;

namespace CQRSlite.Tests.Snapshotting
{
    public class WhenGettingAnAggregateWithSnapshot
    {
        private readonly TestSnapshotAggregate _aggregate;

        public WhenGettingAnAggregateWithSnapshot()
        {
            var eventStore = new TestInMemoryEventStore();
            var snapshotStore = new TestSnapshotStore();
            var snapshotStrategy = new DefaultSnapshotStrategy();
            var snapshotRepository = new SnapshotRepository(snapshotStore, snapshotStrategy, new Repository(eventStore), eventStore);
            var session = new Session(snapshotRepository);

            _aggregate = session.Get<TestSnapshotAggregate>(Guid.NewGuid()).Result;
        }

        [Fact]
        public void Should_restore()
        {
            Assert.True(_aggregate.Restored);
        }
    }
}
