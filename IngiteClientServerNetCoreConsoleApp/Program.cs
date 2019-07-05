using Apache.Ignite.Core;
using Apache.Ignite;
using Apache.Ignite.Core.Cluster;
using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json.Linq;
using IngiteClientServerNetCoreConsoleApp.Model;
using Newtonsoft.Json;
using System.Text;
using Apache.Ignite.Core.Cache;
using System.Threading.Tasks;
using Apache.Ignite.Core.Cache.Configuration;

namespace IngiteClientServerNetCoreConsoleApp
{
    class Program
    {
        public static IIgnite _ignite;
        public static readonly string cacheName = "myTenantCache";

        static void Main(string[] args)
        {
            ConnectServer("Config/server-config.xml");
            ConnectClient("Config/client-config.xml");
            var cacheConfig = Task.Run(async () =>
            {
                return await CustomCacheConfiguration.CreateTenantCacheConfigAsync(cacheName);
            }).Result;


            // Create cache with given name, if it does not exist.
           ICache<string, Employee> cache = _ignite.GetOrCreateCache<string, Employee>(cacheConfig);




            //Testing load data
            List<JObject> empRecordList = new List<JObject>();
            for (int i = 0; i < 10; i++)
            {
                Employee emp = new Employee()
                {
                    EmpId = new Guid().ToString(),
                    EmpDetails = "Engineer " + i,
                    JoinDate = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc)
                };

                var empString = JsonConvert.SerializeObject(emp);
                var jObject = JObject.Parse(empString);
                empRecordList.Add(jObject);
            }

            LoadData(empRecordList);


            Thread.Sleep(Timeout.Infinite);
        }

        private static void ConnectClient(string configPath) //IgniteConfiguration configuration
        {
            try
            {
                if (_ignite == null)
                {
                    Ignition.ClientMode = true;
                    //configuration.GridName = "ClientNode";

                    // Connect to the cluster.
                    _ignite = Ignition.Start(configPath);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void ConnectServer(string configPath)
        {
            try
            {
                if (_ignite == null)
                {
                    //configuration.GridName = "ServerNode";
                    // Connect to the cluster.
                    _ignite = Ignition.Start(configPath); //configuration
                    // Activate the cluster.
                    // This is required only if the cluster is still inactive.
                    _ignite.GetCluster().SetActive(true);

                    if (false)
                    {
                        IEnumerable<IClusterNode> nodes = _ignite.GetCluster().ForServers().GetNodes();
                        _ignite.GetCluster().SetBaselineTopology(nodes);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void LoadData(List<JObject> recordList)
        {
            //cache name
            Employee emp = new Employee();

            //query or primary key field
            var keyArray = new string[] { "EmpId" };

            using (var ldr = _ignite.GetDataStreamer<string, Employee>(cacheName))
            {
                ldr.AutoFlushFrequency = 0;
                foreach (var item in recordList)
                {
                    try
                    {
                        JObject keyObj = new JObject();
                        foreach (var keyName in keyArray)
                        {
                            keyObj[keyName.ToString()] = item[keyName.ToString()];
                        }

                        var serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

                        JsonConvert.PopulateObject(item.ToString(), emp, serializerSettings);

                        string json = JsonConvert.SerializeObject(keyObj, Formatting.None);

                        string base64EncodedKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

                        ldr.AddData(base64EncodedKey, emp);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }
    }
}
