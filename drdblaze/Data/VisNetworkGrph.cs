using VisNetwork.Blazor.Models;

namespace drdblaze.Data
{
    public class VisNetworkGrph
    {
    }


    public class CustomNodeOption : NodeOption
    {

        public NodeWidthConstraint NodeWidthConstraint { get; set; }
    }

    public class NodeWidthConstraint
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }

}
