using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.Common;
using ldtiep.be.DL;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Repository;
using static Dapper.SqlMapper;

namespace ldtiep.be.BL.Service
{
    public class CategoryService : BaseService<Category, CategoryDto, CategoryCreateDto, CategoryUpdateDto>, ICategoryService
    {
        public CategoryService(
            ICategoryRepository productRepository,
           
            IMSDatabase msDatabase,
            IMapper mapper) : base(msDatabase, productRepository, mapper)
        {
           
        }
        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Loại bản ghi </param>
        /// <returns>TEntity</returns>
        /// Author: LeDucTiep (23/05/2023)
        public override async Task<CategoryDto> PostAsync(CategoryCreateDto entity)
        {
            _msDatabase.BeginTransaction();

            try
            {
                Guid parentID = Guid.NewGuid();

                List<CategoryDto> entityDtos = new()
                {
                    new()
                    {
                        CategoryID = parentID,
                        CategoryName = entity.CategoryName,
                        CategoryType = entity.CategoryType,
                        SortOrder = entity.SortOrder,
                    }
                };

                foreach (var item in entity.Children)
                {
                    object name = item.GetValueOrDefault("CategoryName") ?? "";
                    object order = item.GetValueOrDefault("SortOrder") ?? "0";

                    entityDtos.Add(new()
                    {
                        CategoryID= Guid.NewGuid(),
                        ParentID = parentID,
                        CategoryName = name.ToString() ?? "",
                        SortOrder = int.Parse(order.ToString() ?? "0"),
                    });
                }
              
                foreach (var e in entityDtos)
                {
                    Category entity1 = _mapper.Map<Category>(e);

                    await _baseRepository.PostAsync(entity1, e.CategoryID);
                }

                _msDatabase.Commit();

                return new CategoryDto();
            }
            catch (Exception ex)
            {
                _msDatabase.Rollback();
                throw;
            }
            finally
            {
                await _msDatabase.CloseConnectionAsync();
            }
        }
    }
}
