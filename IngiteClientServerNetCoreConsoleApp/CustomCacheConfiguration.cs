using Apache.Ignite.Core.Cache.Configuration;
using Apache.Ignite.Core.Cache.Eviction;
using IngiteClientServerNetCoreConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IngiteClientServerNetCoreConsoleApp
{
    struct QueryEntityIndexFields
    {
        public string[] PrimaryKeys;
        public Type ModelType;
    }

    public class CustomCacheConfiguration
    {
        private static readonly string[] indexFields = new[] { "EmpId" };
        private static readonly int queryIndex = 5;

        public CustomCacheConfiguration()
        {
        }

        public static async Task<CacheConfiguration> CreateTenantCacheConfigAsync(string cacheName)
        {
            CacheConfiguration cacheCfg = null;
            try
            {

                var models = new[] { new QueryEntityIndexFields() { PrimaryKeys = indexFields, ModelType = typeof(Employee) } };
                
                List<QueryEntity> queryList = new List<QueryEntity>();
                foreach (var modelObject in models)
                {
                    var query = new QueryEntity(typeof(string), modelObject.ModelType)
                    {
                        Indexes = new List<QueryIndex>(queryIndex)
                    {
                        new QueryIndex(modelObject.PrimaryKeys)
                    }
                    };

                    queryList.Add(query);
                }

                cacheCfg = new CacheConfiguration
                {
                    Name = cacheName,
                    KeepBinaryInStore = false,  // Cache store works with deserialized data.
                    //ReadThrough = true,
                    //WriteThrough = true,
                    //WriteBehindEnabled = true,
                    QueryEntities = queryList,
                    EvictionPolicy = new LruEvictionPolicy
                    {
                        MaxSize = 1000000
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cacheCfg;
        }
    }
}
