using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using userApp.models;


namespace userApp.services
{
    public interface GroupServices
    {
        public ResponseModel CreateGroup(GroupModel groupModel);

        public ResponseModel UpdateGroup(int id, GroupModel groupModel);

        public ResponseModel<GroupModel> GetGroup(int id);

        public List<GroupModel> GetGroups();

        public ResponseModel DeleteGroup(int id);

    }
}
