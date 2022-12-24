using Project.Dto;
using Project.Core;
using Project.Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repos.Abstracts
{
    public interface IUserRep: IBaseRepository<Users>
    {
        Users CreateUser(Users user);
        UserDTO Login(string Mail, string Password);
        public List<UserDTO> UserDTO();
        public List<UserCRUDModel> UserCRUDModel();
        public void Post(UserCRUDModel model);

    }
}
