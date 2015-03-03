using Blueprint.Core.BaseBusiness;
using Blueprint.Core.BaseDataAccess;
using Blueprint.UAS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueprint.UAS.BLL
{
    public class UASBaseService<T> : BaseService<T> where T : class, new()
    {
        public UASBaseService()
        {
            var baseRepository = new BaseRepository<T>() { DbContext = new UASEntityContainer() };
            base.CurrentRepository = baseRepository;
        }
    }
}
