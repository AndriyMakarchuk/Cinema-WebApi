using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Services.Base;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Specifications;
using Microsoft.EntityFrameworkCore;
using static DataAccess.Specifications.UserSpecification;

namespace BusinessLogic.Services
{
    public class UserServise : BaseServiceClass<User, UserDTO>, IUserService
    {
        public UserServise(IMapper mapper, IRepository<User> repository) : base(mapper, repository)
        {
        }

        public UserDTO Authenticate(string email, string password)
        {
            var user = Repository.GetFirstBySpec(new UserSpecification.ByEmail(email));

            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role
            };
        }
        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return (enteredPassword == storedHash);
        }
        public UserDTO GetByEmail(string email)
        {
            var result = Repository.GetFirstBySpec(new UserSpecification.ByEmail(email));
            return Mapper.Map<UserDTO>(result);
        }

        public UserDTO GetById(int id)
        {
            var result = Repository.GetFirstBySpec(new UserSpecification.ById(id));
            return Mapper.Map<UserDTO>(result);
        }

        public List<UserDTO> GetByIds(int[] ids)
        {
            var result = Repository.GetListBySpec(new UserSpecification.ByIds(ids));
            return Mapper.Map<List<UserDTO>>(result);
        }

        public UserDTO GetByName(string name)
        {
            var result = Repository.GetFirstBySpec(new UserSpecification.ByUserName(name));
            return Mapper.Map<UserDTO>(result);
        }

        public UserDTO GetByRole(string role)
        {
            var result = Repository.GetFirstBySpec(new UserSpecification.ByRole(role));
            return Mapper.Map<UserDTO>(result);
        }
        public List<UserDTO> GetByRoles(string[] role)
        {
            var result = Repository.GetListBySpec(new UserSpecification.ByRoles(role));
            return Mapper.Map<List<UserDTO>>(result);
        }
    }
}
