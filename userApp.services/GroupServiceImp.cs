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

        public void CreateGroup(GroupModel groupModel)
        {

            var newGroups = new DAL.Entities.GroupContext
            {
                groupName = groupModel.groupName,
                Inactive = groupModel.Inactive == "Active",
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

        public async Task<List<GroupModel>> GetGroups()
        {
          var groupContexts = await _db.groups.ToArrayAsync();
          List<GroupModel> groupModels = new List<GroupModel>();

          foreach (GroupContext groupContext in groupContexts)
          {
              var group = new GroupModel()
              {
                  groupId = groupContext.groupId,
                  groupName = groupContext.groupName,
                  Inactive = groupContext.Inactive ? "Active" : "Inactive",
                  LastUpdateBy = groupContext.LastUpdateBy,
                  LastUpdateDate = groupContext.LastUpdateDate
              };
              groupModels.Add(group);
          }

          return groupModels;
        }

        public void UpdateGroup(GroupModel groupModel)
        {
            throw new NotImplementedException();
        }
    }
}
