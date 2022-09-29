using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using userApp.models;
using userApp.DAL;
using userApp.DAL.Entities;

namespace userApp.services
{
    public class GroupServiceImp : GroupServices
    {

        private readonly UserAppContex _db;

        public GroupServiceImp(UserAppContex db)
        {
            _db = db;
        }

        public ResponseModel CreateGroup(GroupModel groupModel)
        {
            ResponseModel response = new();

            if (_db.groups.Any(context => context.groupName == groupModel.groupName))
            {
                response.Succes = false;
                response.Errors.Add("ya existe el nombre del grupo");
                return response;
            }
            //validar

            if(string.IsNullOrEmpty(groupModel.groupName))
            {
                response.Succes = false;
                response.Errors.Add("El campo nombre de grupo es requerido");
            } 
            
            if (!response.Succes) return response;

            var newGroups = new GroupContext
            {
                groupName = groupModel.groupName,
                Inactive = groupModel.Inactive == "Active",
                LastUpdateBy = "",
                LastUpdateDate = DateTime.Now
            };

            _db.groups.Add(newGroups);
            _db.SaveChanges();
            
            return response;
        }

        public  ResponseModel DeleteGroup(int id)
        {
            var response = new ResponseModel();

            if(!_db.groups.Any(g => g.groupId == id)){
            
                response.Succes=false;
                response.Errors.Add("No existe el grupo que quiere borrar");

                return response;
            }

            var group = _db.groups.FirstOrDefault(g => g.groupId == id);

            _db.groups.Remove(group);
            _db.SaveChanges();

            return response;

        }

        public ResponseModel<GroupModel> GetGroup(int id)
        {

            var response = new ResponseModel<GroupModel>();
            
            var group = _db.groups.FirstOrDefault(context => context.groupId == id);

            if(group == null)
            {
                response.Succes = false;
                response.Errors.Add("El grupo no existe");

            }

            if (!response.Succes)
            {
                return response;
            }


            response.result = new GroupModel
            {
                groupId = group.groupId,
                groupName = group.groupName,

            };

            return response;
        }

        public List<GroupModel> GetGroups()
        {

          var groups = _db.groups.ToList();

          var response = new List<GroupModel>();

            groups.ForEach(group => {

                if (group.Inactive)
                {
                    response.Add((new GroupModel()
                    {
                        groupId = group.groupId,
                        groupName = group.groupName,
                        Inactive = group.Inactive ? "Active" : "Inactive",
                        LastUpdateBy = group.LastUpdateBy,
                        LastUpdateDate = group.LastUpdateDate
                    }));
                }
            });

            return response;
        }

        public ResponseModel UpdateGroup(int id, GroupModel groupModel)
        {
            var response = new ResponseModel();
            
            var group = _db.groups.FirstOrDefault(context => context.groupId == id);
 
            if(group == null)
            {
                response.Succes = false;
                response.Errors.Add("El grupo no existe");

            }
            if (!response.Succes)
            {
                return response;
            }
            
            if (_db.groups.Any(context => context.groupName == groupModel.groupName))
            {
                response.Succes = false;
                response.Errors.Add("ya existe el nombre del grupo");
                return response;
            }
            
            //validar

            if(string.IsNullOrEmpty(groupModel.groupName))
            {
                response.Succes = false;
                response.Errors.Add("El campo nombre de grupo es requerido para actualizar");
            }
            
            if (!response.Succes) return response;
            

            
                group.groupName = groupModel.groupName;
                group.Inactive = groupModel.Inactive == "Active";
                group.LastUpdateBy = "";
                group.LastUpdateDate = DateTime.Now;
                _db.groups.Update(group);
                _db.SaveChanges();
                
                return response;
        }
    }
}
