using LobbyApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.Services
{
    public interface IUserService
    {
        Task<UserDetailsDTO> Authenticate(string username, string password);
    }
}
