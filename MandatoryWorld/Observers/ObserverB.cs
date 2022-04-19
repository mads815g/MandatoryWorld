using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.Observers
{
    public class ObserverB : IObserver
    {
        /// <summary>
        /// observer class where it sends an update if a creature has died
        /// </summary>
        /// <param name="creature">Creature that is dead</param>
        public void Update(Creature creature)
        {
            Console.WriteLine($"{creature.Name} is dead");
            Tracing.TraceWorker($"{creature.Name} is dead");
        }
    }
}
