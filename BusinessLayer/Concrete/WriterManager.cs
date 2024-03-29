﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void TAdd(WriterUser t)
        {
            _writerDal.Insert(t);
        }

        public List<WriterUser> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public WriterUser TGetByID(int id)
        {
            return _writerDal.GetByID(id);
        }

        public List<WriterUser> TGetList()
        {
            return _writerDal.GetList();
        }

        public void TRemove(WriterUser t)
        {
            _writerDal.Delete(t);
        }

        public void TUpdate(WriterUser t)
        {
            _writerDal.Update(t);
        }
    }
}
