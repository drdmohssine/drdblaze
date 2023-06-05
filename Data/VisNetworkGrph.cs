namespace drdblaze.Data
{
    public class VisNetworkGrph
    {
    }

    public class VisNetworkData
    {
        public List<VisNetworkNode> Nodes { get; set; }
        public List<VisNetworkEdge> Edges { get; set; }
    }

    public class VisNetworkNode
    {
        public string Id { get; set; }
        public string Label { get; set; }
        // other properties as needed
    }

    public class VisNetworkEdge
    {
        public string From { get; set; }
        public string To { get; set; }
        // other properties as needed
    }

    public class VisNetworkOptions
    {
        public LayoutOptions Layout { get; set; }
        public PhysicsOptions Physics { get; set; }
        public VisNodeOptions Nodes { get; set; }
        // other properties as needed

        public class LayoutOptions
        {
            public HierarchicalOptions Hierarchical { get; set; }
            // other layout options as needed
        }

        public class HierarchicalOptions
        {
            public string Direction { get; set; }
            public string SortMethod { get; set; }
            public string ShakeTowards { get; set; }
            public int LevelSeparation { get; set; }
            // other hierarchical options as needed
        }

        public class PhysicsOptions
        {
            public BarnesHutOption BarnesHut { get; set; }
            // other physics options as needed
        }

        public class BarnesHutOption
        {
            public int AvoidOverlap { get; set; }
            public int Damping { get; set; }
            // other BarnesHut options as needed
        }

        public class VisNodeOptions
        {
            public int Width { get; set; }
            public int Height { get; set; }
            // other node options as needed
        }
    }


}
