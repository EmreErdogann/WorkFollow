using WorkFollow.Entities.Abstract;

namespace WorkFollow.Entities.Concrete
{
    public class Report : BaseEntity
    {

        public string Definition { get; set; }
        public string Detail { get; set; }
        public int TaskId { get; set; }
        public Taskk Task { get; set; }
    }
}
