using CGA_WEB.Models;
using Domain.Entities;
using RestSharp;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGA_WEB.Controllers
{
    public class CommentaireController : Controller
    {
        UserService us = null;
        CommentaireService cmS = null;
        public CommentaireController()
        {
            cmS = new CommentaireService();
            us = new UserService();
        }


        // GET: Commentaire
        public ActionResult Index1(CommentaireModels cm )
        {
           
            ViewData["nbre"]= cmS.nbreCommentaireByPolicy((int)Session["id"]);
            ViewData["nbreC"] = cmS.nbreCommentaireNonVu();
            cm.users = cmS.UserWithCommentaireNonVu();
          cm.commentaires   = cmS.sortById((int)Session["id"]);

            return View(cm);
        }

        // GET: Commentaire/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Commentaire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Commentaire/Create
        [HttpPost]
        public ActionResult Create(String txt)
        {
            Session["msg"] ="false";
            List<String> verif = new List<String>();
            

            commentaire com = new commentaire()
            
            {
             
                user_id=2,
                status = 0,
                like = 0,
                policy_id = (int)Session["id"],
                text = txt,
                
                date= DateTime.Now.ToString("MM/dd/yyyy"),

            };

            {
                
                Char delimiter = ' ';
                String[] substrings = txt.Split(delimiter);
                foreach (var substring in substrings)
                    verif.Add(substring);
            }
            if (verif.Contains("sexe")|| verif.Contains("bad") || verif.Contains("chet") || verif.Contains("chet up "))
            {
                Session["msg"] ="true";
                return RedirectToAction("Index1");
            }
            else
            {
                Session["msg"] = "false";
                cmS.Add(com);
                cmS.Commit();
                ViewBag.err = "this commentaire contais bad word";

                return RedirectToAction("Index1");
            }
        }

        // GET: Commentaire/Edit/5
        public ActionResult Edit(int id)
        {
            commentaire com = cmS.GetById(id);
            
            CommentaireModels CM = new CommentaireModels()
            {
                text = com.text,
                id=com.id,


            };

            return View(CM);
        }

        // POST: Commentaire/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CommentaireModels CM)
        {
            Session["msg"] = "false";
            commentaire com = cmS.GetById(id);


            com.text = CM.text;
           
               cmS.Update(com);
                UpdateModel(CM);

               cmS.Commit();
                return RedirectToAction("Index1");


           
           

            
        }

        // GET: Commentaire/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    commentaire com = cmS.GetById(id);
        //    if (com == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    CommentaireModels CM= new CommentaireModels()
        //    {
        //        text =com.text,
               


        //    };

        //    return View(CM);
        //}

        // POST: Commentaire/Delete/5
       
        public ActionResult Delete(int id)
        {
            Session["msg"] = "false";
            commentaire com = cmS.GetById(id);
            cmS.Delete(com);
            cmS.Commit();
          
            return RedirectToAction("Index1");
        }

        public ActionResult nbreCommentaire()
        {
            int x = cmS.nbreCommentaireByPolicy(1);

            return View(x);
        }
        public ActionResult Like(int id)
        {
            commentaire com = cmS.GetById(id);


            com.like += 1;

            cmS.Update(com);
            

            cmS.Commit();


            return RedirectToAction("Index1");
        }
        public ActionResult DisLike(int id)
        {
            commentaire com = cmS.GetById(id);
            Session["msg"] = "false";

            com.like -= 1;

            cmS.Update(com);


            cmS.Commit();


            return RedirectToAction("Index1");
        }

        public ActionResult Policy()
        {
            Session["msg"] = "false";
            var contrats = new RestClient("http://localhost:8080/cga-web/pidev/CgaPolicy/");
            var request = new RestRequest("getPolicy", Method.GET);
            request.AddHeader("Content-type", "application/json");
            IRestResponse<List<policy>> contrat = contrats.Execute<List<policy>>(request);
            return View(contrat.Data);
        }
        public ActionResult Index2(CommentaireModels cm, int id=2 )
        {
            Session["id"] = id;
            ViewData["nbre"] = cmS.nbreCommentaireByPolicy((int)Session["id"]);
            ViewData["nbreC"] = cmS.nbreCommentaireNonVu();
            cm.users = cmS.UserWithCommentaireNonVu();
            cm.commentaires = cmS.sortById((int)Session["id"]);

            return View(cm);
        }
    }
}
