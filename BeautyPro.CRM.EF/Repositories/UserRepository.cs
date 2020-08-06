﻿using BeautyPro.CRM.EF.DomainModel;
using BeautyPro.CRM.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyPro.CRM.EF.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IContextFactory contextFactory)
            :base(contextFactory)
        {

        }

        IUserRepository ud = new IUserRepository();
    }
}
