using infra.eventbus.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.eventbus.commands
{
    public abstract class Command : Message
    {
        public DateTime TimesStamp { get; protected set; }

        protected Command()
        {

            TimesStamp = DateTime.Now;
        }
    }
}
