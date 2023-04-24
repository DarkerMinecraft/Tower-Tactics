using System.Collections.Generic;

namespace Tactics.Stats
{
    interface IModifierProvider
    {

        IEnumerable<float> GetAdditiveModifers(Stat stat);
        IEnumerable<float> GetPercentageModifers(Stat stat);

    }
}