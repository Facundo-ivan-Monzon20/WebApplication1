using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using userApp.models;
using userApp.DAL;

namespace userApp.services
{
    public class GroupServiceImp : GroupServices
    {

        private readonly UserAppContex _db;

        public GroupServiceImp(UserAppContex db)
        {
            _db = db;
        }

        public void CreateGroup(GroupModel groupModel)
        {

            var newGroups = new DAL.Entities.GroupContext
            {
                groupName = groupModel.groupName,
                Inactive = groupModel.Inactive == "Activate" ? true : false,
                LastUpdateBy = "",
                LastUpdateDate = DateTime.Now
            };

            _db.groups.Add(newGroups);
            _db.SaveChanges();

        }

        public void DeleteGroup(int id)
        {
            throw new NotImplementedException();
        }

        public GroupModel GetGroup(int id)
        {
            return new GroupModel() { groupId = 2, groupName = "Cantantes" };
        }

        public List<GroupModel> GetGroups()
        {
            throw new NotImplementedException();
        }

        public void UpdateGroup(GroupModel groupModel)
        {
            throw new NotImplementedException();
        }
    }
}
