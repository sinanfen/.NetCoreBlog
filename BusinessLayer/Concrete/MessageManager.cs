using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetList()
        {
            return _messageDal.GetListAll();
        }

        public List<Message> GetInboxListByWriter(string p)
        {
            return _messageDal.GetListAll(x=>x.Receiver == p);
        }

        public void TAdd(Message t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message t)
        {
            throw new NotImplementedException();
        }

        public Message TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetList(Expression<Func<Message, bool>> filter = null)
        {
            return _messageDal.GetListAll(filter);
        }

        public Message TGetByFilter(Expression<Func<Message, bool>> filter = null)
        {
            return _messageDal.GetByFilter(filter);
        }
    }
}
