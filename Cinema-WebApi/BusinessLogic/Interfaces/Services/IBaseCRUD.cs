namespace BusinessLogic.Interfaces.Services
{
    public interface IBaseCRUD <T_DTO> 
        where T_DTO : class
    {
        void Create(T_DTO dto);
        List<T_DTO> GetAll();
        void Update(T_DTO dto);
        void Delete(T_DTO dto);
    }
}
