
namespace ldtiep.be.BL.Dto
{
    public class PictureDto
    {
        public Guid PictureID { get; set; }
        public string PictureType { get; set; }
        public byte[]? PictureData { get; set; }
    }
}
