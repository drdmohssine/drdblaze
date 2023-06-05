using VisNetwork.Blazor;
using VisNetwork.Blazor.Models;
using static drdblaze.Data.SNData;

namespace drdblaze.Data
{
    
    public class SharedData
    {
        public event Action OnChange;

        public Project MainProject = new Project()
        {

            ProjectID = 1,
            Name = "sNotes Project",
            Packets = new List<Packet>(),
            NotesCollection = new List<NotesCollection>(),
        };

        public Network network;
        public NetworkData data;
        public List<Node> nodes = new List<Node>();
        public List<Edge> edges = new List<Edge>();
        public string layoutDirection = "LR";
        public string canvasColor = "#e8c6c8";
        public string nodeColor = "#D2E5FF";
        public string fontColor = "#000000";


       

        public NetworkOptions EditorConstructionOptions(Network network)
        {

            return new NetworkOptions
            {

                Layout = new LayoutOptions()
                {
                    Hierarchical = new HierarchicalOptions()
                    {
                        Direction = layoutDirection,
                        SortMethod = "directed",
                        ShakeTowards = "leaves",

                        LevelSeparation = 300
                    }
                },

                Physics = new PhysicsOptions()
                {
                    //Enabled = false
                    BarnesHut = new BarnesHutOption()
                    {

                        AvoidOverlap = 1,
                        Damping = 1,
                    }
                },
                Nodes = new NodeOption()
                {
                    NodeHeightConstraint = new NodeHeightConstraint()
                    {
                        Minimum = 20,
                       
                    },
                    
                }

                

            };
        }



      


        public void NotifyStateChanged() => OnChange?.Invoke();

    }


}
