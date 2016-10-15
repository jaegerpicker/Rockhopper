using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rockhopper.Models
{
    interface IApp
    {
        void Add(AppModel app);
        IEnumerable<AppModel> GetAll();
        AppModel Find(string Id);
        bool Remove(string Id);
        bool Update(string Id);
    }
}
