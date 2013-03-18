namespace EvolutionaryAlgorithm.Miscellaneous
{
    public class Node
    {
        public PairList<Node, double> UpstreamConnections { get; set; }
        public string Name { get; private set; }
        public double Gain { get; set; }
        public double TimeConstant { get; set; }
        public double ActivationLevel { get; set; }
        public double Output { get; set; }

        public Node(string name)
        {
            Name = name;
            UpstreamConnections = new PairList<Node, double>();
        }
        


        public void addConnections(params Node[] connections)
        {
            for (int i = 0; i < connections.Length; i++)
                UpstreamConnections.Add(connections[i], -1);
        }
    }
}