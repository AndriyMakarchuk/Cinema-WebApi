using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services
{
    internal interface ISessionService : IBaseCRUD<SessionDTO>
    {
        SessionDTO GetSessionById(int id);
        List<SessionDTO> GetSessionsByIds(int[] ids);
        List<SessionDTO> GetSessionsByCinemaHall(int id);
        List<SessionDTO> GetSessionsByMovie(int id);
    }
}
