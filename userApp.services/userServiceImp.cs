using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using userApp.models;
using userApp.DAL;
using userApp.DAL.Entities;


namespace userApp.services
{
    public class UserServiceImp : UserServices
    {
        private readonly UserAppContex _db;
        

        public UserServiceImp(UserAppContex db)
        {
            _db = db;
        }

        public void CreateUser(UserModel userModel)
        {
            var newUser = new DAL.Entities.UserContext
            {
                UserName = userModel.UserName,
                Password = userModel.Password,
                FirstName = userModel.FirstName,
                lastName = userModel.lastName,
                Email = userModel.Email,
                Phone = userModel.PhoneNumber,
                DNI = userModel.DNI,
                BirthDay = userModel.BirthDay,
                Inactive = userModel.Inactive == "Active",
                LastUpdateDate = DateTime.Now,
                LastUpdateBy = ""
            };
            _db.users.Add(newUser);
            _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetUsers()
        {

            List<DAL.Entities.UserContext> users = _db.users.ToList();
            List<UserModel> usersModels = new List<UserModel>();

            foreach (var userContext in users)
            {

                var user = new UserModel
                {
                    userId = userContext.userId,
                    UserName = userContext.UserName,
                    Password = userContext.Password,
                    FirstName = userContext.FirstName,
                    lastName = userContext.lastName,
                    Email = userContext.Email,
                    PhoneNumber = userContext.Phone,
                    DNI = userContext.DNI,
                    BirthDay = userContext.BirthDay,
                    Inactive = userContext.Inactive ? "Active" : "Inactive",
                    LastUpdateDate = userContext.LastUpdateDate,
                    LastUpdateBy = userContext.LastUpdateBy
                };
                usersModels.Add(user); 
            }

            return usersModels;
        }

        public void UpdateUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
