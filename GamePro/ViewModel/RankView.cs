using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GamePro.ViewModel
{
    public class RankView
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [DisplayName("用户ID")]
        public int? ID { get; set; }


        [DisplayName("钻石")]
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

   
    }
}