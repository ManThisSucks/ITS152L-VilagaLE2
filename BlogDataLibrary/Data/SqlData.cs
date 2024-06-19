﻿using BlogDataLibrary.Database;
using BlogDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDataLibrary.Data
{
    public class SqlData
    {
        private ISqlDataAccess _db;
        private const string connectionStringName = "BlogDb";

        public SqlData(ISqlDataAccess db) 
        {
            _db = db;
        }

        // added ? below to make IDE happy
        public UserModel? Authenticate(string username, string password)
        {
            UserModel? result = _db.LoadData<UserModel?, dynamic>("dbo.spUsers_Authenticate",
                                                                new {username, password},
                                                                connectionStringName, 
                                                                true).FirstOrDefault();

            return result;
        }
    }
}
