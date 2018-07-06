using GamePro.BaseFunction;
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
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(Session["OpenID"])) || string.IsNullOrEmpty(Convert.ToString(Session["ID"])))
                    weixinService.AutoLogin(Convert.ToString(Session["OpenID"]), Convert.ToInt32(Session["ID"]));
                ViewBag.RingID = (from a in db.Ring.Select(x => x.RingID) select a).Max();  //擂台最大房间号
                return View();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        //摆擂
        public ActionResult Add()
        {
            try
            { 
                if (string.IsNullOrEmpty(Convert.ToString(Session["OpenID"])) || string.IsNullOrEmpty(Convert.ToString(Session["ID"])))
                    weixinService.AutoLogin(Convert.ToString(Session["OpenID"]), Convert.ToInt32(Session["ID"]));
                string OpenID = Session["OpenID"].ToString();
                var user = (
                    from a in db.User.Where(x => x.OpenID == OpenID) select a
                    ).FirstOrDefault();
                ViewBag.NumberOfDiamonds = user.NumberOfDiamonds;
                return View();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult Add(FormCollection f)
        {
            try
            {
                //Session["ID"] = "10006";
                var id = Convert.ToInt32(Session["ID"]);
                var integral = Request.Form["integral"];
                var model = Request.Form["model"];
                Ring ring = new Ring();
                ring.ID = id;
                ring.Gamemode = model;
                ring.RingDiamonds = Convert.ToInt32(integral);
                db.Ring.Add(ring);
                if (db.SaveChanges() > 0)
                {
                    return Json("摆擂成功，联系客服安排比赛");
                }
                else
                {
                    return Json("摆擂失败");
                }
            }
            catch (Exception ex)
            {
                return Json("摆擂失败" + ex.Message);
            }
        }
    }
}