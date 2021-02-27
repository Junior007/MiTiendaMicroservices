using System;

namespace infra.eventbus.events
{
    public abstract class Event
    {

        public DateTime TimesStamp;

        protected Event()
        {
            TimesStamp = DateTime.Now;
        }
    }
}
