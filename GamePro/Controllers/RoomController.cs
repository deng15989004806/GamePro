using GamePro.BaseFunction;
using GamePro.Models;
using GamePro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamePro.Controllers
{
    public class RoomController : BaseController
    {
        GameWZEntities db = new GameWZEntities();
        // GET: Room
        //擂台
        public ActionResult Room()
        {
            try
            {
                Response.Write(Session["OpenID"]);
                //weixinService.AutoLogin(OpenID);
                //if (string.IsNullOrEmpty(Convert.ToString(Session["OpenID"])) || string.IsNullOrEmpty(Convert.ToString(Session["ID"])))
                //    weixinService.AutoLogin(Convert.ToString(Session["OpenID"]), Convert.ToInt32(Session["ID"]));
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
                Response.Write(Session["OpenID"]);
                //if (string.IsNullOrEmpty(Convert.ToString(HttpContext.Session["OpenID"])) || string.IsNullOrEmpty(Convert.ToString(HttpContext.Session["ID"])))
                //    weixinService.AutoLogin(Convert.ToString(HttpContext.Session["OpenID"]), Convert.ToInt32(HttpContext.Session["ID"]));
                weixinService.AutoLogin(Session["OpenID"].ToString());
                string OpenID = HttpContext.Session["OpenID"].ToString();
                var user = (
                    from a in db.User.Where(x => x.OpenID == OpenID) select a
                    ).FirstOrDefault();
                ViewBag.NumberOfDiamonds = user.NumberOfDiamonds;
                return View();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return View();
                //return Json(ex.Message);
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

        public ActionResult Rank()
        {
            try
            {
                Response.Write(Session["OpenID"]);
                weixinService.AutoLogin(OpenID);
                //钻石排行
                var rank = (
                    from a in
                        (
                        from a in db.Ring.Where(x => x.WinOrLose.Trim() == "赢")
                        group a by a.ID into g
                        select new { ID = g.Key, total = g.Sum(s => s.RingDiamonds) }
                        )
                    join b in db.User on a.ID equals b.ID

                    select new RankView
                    {
                        ID = b.ID,
                        UserName = b.nickname,
                        TotalRingDiamonds = a.total
                    }
                    ).ToList().OrderByDescending(x => x.TotalRingDiamonds);
                return View();
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
    }
}