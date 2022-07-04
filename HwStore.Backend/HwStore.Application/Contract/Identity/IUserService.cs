
using HwStore.Identity.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwStore.Application.Contract.Identity
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers();

        Task<UserDto_Detail> CurrentUser();
    }
}
