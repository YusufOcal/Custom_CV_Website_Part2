using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SocialManager : ISocialService
    {
        ISocialDal _socialDal;
        public SocialManager(ISocialDal socialDal)
        {
            _socialDal = socialDal;
        }

        public void TAdd(Social t)
        {
            _socialDal.Insert(t);
        }

        public List<Social> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public Social TGetByID(int id)
        {
            return _socialDal.GetByID(id);
        }

        public List<Social> TGetList()
        {
            return _socialDal.GetList();
        }

        public void TRemove(Social t)
        {
            _socialDal.Delete(t);
        }

        public void TUpdate(Social t)
        {
            _socialDal.Update(t);
        }
    }
}
