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

            //validar

            if(string.IsNullOrEmpty(groupModel.groupName))
            {
                response.Succes = false;
                response.Errors.Add("El campo nombre de grupo es requerido");
            }

            if (!response.Succes) return response;

            var newGroups = new DAL.Entities.GroupContext
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

        public void DeleteGroup(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseModel<GroupModel> GetGroup(int id)
        {

            var response = new ResponseModel<GroupModel>();
            

            var group = _db.groups.Where(g => g.groupId == id).FirstOrDefault();

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

        public void UpdateGroup(GroupModel groupModel)
        {
            throw new NotImplementedException();
        }
    }
}
