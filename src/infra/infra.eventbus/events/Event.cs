using System;

namespace infra.eventbus.events
{
    public abstract class Event
    {

        public DateTime TimesStamp { get; }

        public Guid RequestId { get; }

        protected Event()
        {
            TimesStamp = DateTime.Now;
            RequestId = Guid.NewGuid();
        }
    }
}
