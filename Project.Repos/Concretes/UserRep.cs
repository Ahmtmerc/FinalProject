using Project.Dto;
using Project.Core;
using Project.Dal;
using Project.Entity.Concretes;
using Project.Repos.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repos.Concretes
{
    public class UserRep<T> : BaseRepository<Users>, IUserRep where T : class
    {
        ProjectContext _db;
        Users _users;
        public UserRep(ProjectContext db, Users users) : base(db)
        {
            _db = db;
            _users = users; 
        }

        public Users CreateUser(Users user)
        {
            Users selectedUser = _db.Set<Users>().FirstOrDefault(x => x.Mail == user.Mail);

            if (selectedUser != null)
            {
                user.Error = true;
            }
            else
            {
                user.Error = false;
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Role = "User";
            return user;
        }

        public UserDTO Login(string Mail, string Password)
        {
            Users selectedUser = _db.Set<Users>().FirstOrDefault(x => x.Mail == Mail);

            UserDTO user = new UserDTO();
            user.Mail = Mail;

            if (selectedUser != null)
            {
                user.Error = false;
                bool verified = BCrypt.Net.BCrypt.Verify(Password, selectedUser.Password);
                if (verified == true)
                {
                    user.Role = selectedUser.Role;
                    user.Id = selectedUser.Id;
                    user.Error = false;
                }
                else user.Error = true;
            }
            else user.Error = true;

            return user;

        }

        public List<UserCRUDModel> UserCRUDModel()
        {
            return Set().Select(x => new UserCRUDModel  //x symbol represents products class in database
            {
                Id = x.Id,
                Mail = x.Mail,
                Password = x.Password,
                UserName=x.UserName,    
                Street=x.Street,
                Avenue=x.Avenue,
                No=x.No,
                CountyId=x.CountyId,
                Error=x.Error,
                Role=x.Role,
                Sex=x.Sex,
            }).ToList();
        }

        public List<UserDTO> UserDTO()
        {
            return Set().Select(x => new UserDTO //x symbol represents products class in database
            {
                Id = x.Id,
                Mail = x.Mail,
                Password=x.Password,    

            }).ToList();
        }
        public void Post(UserCRUDModel model)
        {
            _users.Id=model.Id; 
            _users.Mail=model.Mail;
            _users.Password = model.Password;
            _users.UserName=model.UserName;
            _users.Street=model.Street;
            _users.Avenue=model.Avenue; 
            _users.No=model.No;
            _users.CountyId=model.CountyId; 
            _users.Error=model.Error;   
            _users.Role=model.Role; 
            _users.Sex=model.Sex;   
 

            _db.Add(_users);
            _db.SaveChanges();
        }

    }
}
