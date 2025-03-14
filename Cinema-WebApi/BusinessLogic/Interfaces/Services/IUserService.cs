using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces.Services
{
    public interface IUserService : IBaseCRUD<UserDTO>
    {
        UserDTO GetById(int id);
        UserDTO GetByName(string name);
        UserDTO GetByEmail(string email);
        List<UserDTO> GetByIds(int[] ids);
        UserDTO Authenticate(string username, string password);
        UserDTO GetByRole(string role);
        List<UserDTO> GetByRoles(string[] role);
    }
}
