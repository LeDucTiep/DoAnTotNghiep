using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.Common;
using ldtiep.be.DL;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Repository;

namespace ldtiep.be.BL.Service
{
    public class UserService : BaseService<User, UserDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        public UserService(
            IUserRepository userRepository,
           
            IMSDatabase msDatabase,
            IMapper mapper) : base(msDatabase, userRepository, mapper)
        {
           
        }

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Loại bản ghi </param>
        /// <returns>User</returns>
        /// Author: LeDucTiep (23/05/2023)
        public override async Task<UserDto> PostAsync(UserCreateDto entity)
        {
            _msDatabase.BeginTransaction();

            try
            {
                UserDto entityDto = _mapper.Map<UserDto>(entity);

                List<int> errorCodes = new();

                errorCodes.AddRange(Validate(entityDto));

                try
                {
                    List<int> ints = await PostValidate(entityDto);

                    errorCodes.AddRange(ints);
                }
                catch { }


                if (errorCodes.Any())
                    throw new BadRequestException(errorCodes);
                User entity1 = _mapper.Map<User>(entity);

                int changedCount = await _baseRepository.PostAsync(entity1, entity1.UserID);

                if (changedCount == 0)
                    throw new InternalException();

                UserDto entity2 = _mapper.Map<UserDto>(entity1);

                _msDatabase.Commit();

                return entity2;
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
