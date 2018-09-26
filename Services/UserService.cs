using Data.Infrastructure;
using Domain.Entities;
using Service.Patern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public  class UserService : Service<user>
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork ut = new UnitOfWork(dbf);

        public UserService() : base(ut)
        {

        }


        //public IEnumerable<user> UserWithCommentaireNonVu()
        //{
        //    var infoQuery =
        //from c in dataContext.commentaire
        //from u in dataContext.user
        //where u.id == c.user_id && c.status == 0

        //select u;

        //    return infoQuery;


        //}



    }
}
