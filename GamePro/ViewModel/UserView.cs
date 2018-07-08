using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GamePro.ViewModel
{
    public class UserView
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [DisplayName("用户ID")]
        public int? ID { get; set; }

        [DisplayName("微信ID")]
        public string OpenID { get; set; }

        [DisplayName("用户钻石数")]
        public int? NumberOfDiamonds { get; set; }

        [DisplayName("下注钻石")]
        public int? RingDiamonds { get; set; }

        /// <summary>
        /// 钻石总数
        /// </summary>
        [DisplayName("钻石总数")]
        public int? TotalRingDiamonds { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        [DisplayName("用户")]
        public string UserName { get; set; }

        [DisplayName("擂台")]
        public int? RingID { get; set; }

        [DisplayName("比赛模式")]
        public string Gamemode { get; set; }

        [DisplayName("输赢")]
        public string WinOrLose { get; set; }
    }
}