using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld.Observers
{
    /// <summary>
    /// small and focused interface like solid said.
    /// </summary>
    public interface IObserver
    {
        // Receive update from Creature
        void Update(Creature creature);
    }
}
