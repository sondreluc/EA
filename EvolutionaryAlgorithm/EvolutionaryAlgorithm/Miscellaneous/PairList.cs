using System.Collections.Generic;

namespace EvolutionaryAlgorithm.Miscellaneous
{
    public class Pair<Left, Right>
    {
        public Pair(Left left, Right Right)
        {
            this.left = left;
            right = right;
        }

        public Left left { get; set; }
        public Right right { get; set; }
    }

    public class PairList<Left, Right> : List<Pair<Left, Right>>
    {
        public void Add(Left left, Right right)
        {
            Add(new Pair<Left, Right>(left, right));
        }
    }
}