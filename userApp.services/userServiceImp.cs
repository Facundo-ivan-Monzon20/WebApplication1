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

        public ResponseModel CreateUser(UserModel userModel)
        {

            ResponseModel response = new();
            
            //validar

            if (string.IsNullOrEmpty(userModel.UserName))
            {
                response.Succes = false;
                response.Errors.Add("El campo nombre de usuario es requerido");
            } 
            
            if (string.IsNullOrEmpty(userModel.FirstName))
            {
                response.Succes = false;
                response.Errors.Add("El campo primer nombre de usuario es requerido");
            }
            if (string.IsNullOrEmpty(userModel.lastName))
            {
                response.Succes = false;
                response.Errors.Add("El campo apellido de usuario es requerido");
            }
            if (string.IsNullOrEmpty(userModel.Password))
            {
                response.Succes = false;
                response.Errors.Add("El campo contraseña de usuario es requerido");
            }
            if (string.IsNullOrEmpty(userModel.Email))
            {
                response.Succes = false;
                response.Errors.Add("El campo Email de usuario es requerido");
            }
            if (string.IsNullOrEmpty(userModel.DNI))
            {
                response.Succes = false;
                response.Errors.Add("El campo DNI de usuario es requerido");
            }

            if (!response.Succes) return response;


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


            return response;
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
            List<UserContext> users = _db.users.ToList();
            List<UserModel> usersModels = new List<UserModel>();
            users.ForEach(user =>
                usersModels.Add(new UserModel
                {
                    userId = user.userId,
                    UserName = user.UserName,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    lastName = user.lastName,
                    Email = user.Email,
                    PhoneNumber = user.Phone,
                    DNI = user.DNI,
                    BirthDay = user.BirthDay,
                    Inactive = user.Inactive ? "Active" : "Inactive",
                    LastUpdateDate = user.LastUpdateDate,
                    LastUpdateBy = user.LastUpdateBy
                }));
            return usersModels;
        }

        public void UpdateUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
