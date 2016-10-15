using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Rockhopper.Models
{
    public class AppRepository : IApp
    {
        private static ConcurrentDictionary<string, AppModel> _apps = new ConcurrentDictionary<string, AppModel>();
        public void Add(AppModel app)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = "/k " + app.Name + " " + string.Join(" ", app.Arguements),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            var a = proc.Start();
            app.Started = DateTime.Now;
            app.LastUpdate = DateTime.Now;
            app.Id = proc.Id.ToString();
            _apps[app.Id] = app;
        }

        public AppModel Find(string Id)
        {
            return _apps[Id];
        }

        public IEnumerable<AppModel> GetAll()
        {
            return _apps.Values;
        }

        public bool Remove(string Id)
        {
            try
            {
                var k = Process.GetProcessById(int.Parse(Id));
                k.Kill();
                AppModel ao;
                return _apps.TryRemove(Id, out ao);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool Update(string Id)
        {
            try
            {
                var k = Process.GetProcessById(int.Parse(Id));
                var a = Find(Id);
                k.Kill();
                Add(a);
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
