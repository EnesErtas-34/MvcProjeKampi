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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void TDelete(Heading t)
        {
            _headingDal.Update(t);
        }

        public Heading TGetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> TGetList()
        {
           return _headingDal.List();
        }

        public void TInsert(Heading t)
        {
            _headingDal.Insert(t);
        }

        public void TUpdate(Heading t)
        {
            _headingDal.Update(t);
        }
    }
}
