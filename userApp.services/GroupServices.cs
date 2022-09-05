﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using userApp.models;


namespace userApp.services
{
    public interface GroupServices
    {
        public void CreateGroup(GroupModel groupModel);

        public void UpdateGroup(GroupModel groupModel);

        public GroupModel GetGroup(int id);

        public List<GroupModel> GetGroups();

        public void DeleteGroup(int id);

    }
}