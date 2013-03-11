using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionaryAlgorithm.Miscellaneous
{
    class Pair<Left, Right>
    {
        public Left left { get; set; }
        public Right right { get; set; }

        public Pair(Left left, Right Right);

    }
    class PairList<Left, Right> : List<Pair<Left, Right>>
    {
        public PairList(Left left, Right right);

        public void Add(Left left, Right right)
        {
            Add(new Pair<Left, Right>(left, right));
        }
    }
}
