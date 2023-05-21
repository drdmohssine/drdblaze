using static drdblaze.Data.SNData;

namespace drdblaze.Data
{
    
    public class SharedData
    {
        public Project MainProject = new Project()
        {

            ProjectID = 1,
            Name = "sNotes Project",
            Packets = new List<Packet>(),
            NotesCollection = new List<NotesCollection>(),
        };
    }


}
