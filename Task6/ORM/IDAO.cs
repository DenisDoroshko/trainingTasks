using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public interface IDAO
    {
        void Insert<T>(T element);
        void Update<T>(T element);
        void Delete<T>(T element);
        List<T> Get<T>();
    }
}
