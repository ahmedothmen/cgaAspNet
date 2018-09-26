using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Service.Patern;
using Data.Infrastructure;
using Data;
using System.Data.SqlClient;
using System.Activities.Expressions;

namespace Services
{
  public  class CommentaireService : Service<commentaire>, IcommentaireService
    {
       
        private CGAContext dataContext= new CGAContext();
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork ut = new UnitOfWork(dbf);

        public CommentaireService() : base(ut)
        {

            //dbf = new DatabaseFactory();
            //ut = new UnitOfWork(dbf);
        }

        public IEnumerable<commentaire> sortById(int id)
        {
           
            return ut.GetRepository<commentaire>().GetMany(x => x.id != null).Where(x => x.policy_id.Equals(id)).OrderByDescending(x => x.id);
        }

public int nbreCommentaireByPolicy(int id)
        {
            return ut.GetRepository<commentaire>().GetMany(x => x.id != null).Where(x => x.policy_id.Equals(id)).Count();

        }

        public int nbreCommentaireByUser(int id)
        {
            return ut.GetRepository<commentaire>().GetMany(x => x.id != null).Where(x => x.user_id.Equals(id)).Count();

        }


        //public int suggestUser()
        //    {
        //        return ut.GetRepository<commentaire>().GetMany(x => x.id != null).OrderByDescending(nbreCommentaireByUser(x => x.id));

        //    }

        public IEnumerable<user> UserWithCommentaireNonVu()
        {
            var infoQuery =
        from c in dataContext.commentaire
        from u in dataContext.user
        where u.id == c.user_id && c.status == 0

        select u;

            return infoQuery;


        }
        public int nbreCommentaireNonVu()
        {
            return ut.GetRepository<commentaire>().GetMany(x => x != null).Where(x => x.status.Equals(0)).Count();

        }





    }
}
