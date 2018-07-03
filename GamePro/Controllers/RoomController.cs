using GamePro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamePro.Controllers
{
    public class RoomController : Controller
    {
        GameWZEntities db = new GameWZEntities();
        // GET: Room
        //擂台
        public ActionResult Room()
        {
            return View();
        }
        //摆擂
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(FormCollection f)
        {
            try
            {
                //Session["id"] = "10006";
                var id = Convert.ToInt32(Session["id"]);
                var integral = Request.Form["integral"];
                var model = Request.Form["model"];
                Ring ring = new Ring();
                ring.ID = id;
                ring.Gamemode = model;
                ring.RingDiamonds = Convert.ToInt32(integral);
                db.Ring.Add(ring);
                if (db.SaveChanges() > 0)
                {
                    return Json("摆擂成功");
                }
                else
                {
                    return Json("摆擂失败");
                }
            }
            catch (Exception ex)
            {
                return Json("摆擂失败"+ex.Message);
            }
            }
    }
}