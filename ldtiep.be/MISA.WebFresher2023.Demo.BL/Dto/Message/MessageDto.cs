
namespace ldtiep.be.BL.Dto
{
    public class MessageDto
    {
        public Guid MessageID { get; set; }
        public Guid UserID { get; set; }
        public Guid? EmployeeID { get; set; }
        public string MessageContent { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
