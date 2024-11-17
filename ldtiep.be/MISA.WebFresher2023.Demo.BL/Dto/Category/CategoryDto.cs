
namespace ldtiep.be.BL.Dto
{
    public class CategoryDto
    {
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int SortOrder { get; set; }
        public Guid? ParentID { get; set; }
        public int CategoryType { get; set; }
        public List<CategoryDto> Children { get; set; }
    }
}
