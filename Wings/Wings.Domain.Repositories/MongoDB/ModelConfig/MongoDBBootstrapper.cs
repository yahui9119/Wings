using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wings.Domain.Model;

namespace Wings.Domain.Repositories.MongoDB
{
    public static class MongoDBBootstrapper
    {
        public static void Bootstrap()
        {
            MongoDBRepositoryContext.RegisterConventions();

            BsonClassMap.RegisterClassMap<Group>(s =>
            {
                s.AutoMap();
                s.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<Module>(s =>
            {
                s.AutoMap();
                s.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<User>(s =>
            {
                s.AutoMap();
                s.SetIgnoreExtraElements(true);
                s.UnmapProperty("HaveGroups");
                s.UnmapProperty("HaveRoles");
                 s.UnmapProperty("HaveWebs");
                 s.UnmapProperty("WebIDS");
                 s.UnmapProperty("GroupIDS");
                s.UnmapProperty("RoleIDS");
            });

            BsonClassMap.RegisterClassMap<Role>(s =>
            {
                s.AutoMap();
                s.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<UserOnline>(s =>
            {
                s.AutoMap();
                s.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<Web>(s =>
            {
                s.AutoMap();
                s.SetIgnoreExtraElements(true);
              
            });

        }
    }
}
