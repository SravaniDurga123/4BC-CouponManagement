using System;
using System.Collections.Generic;
using System.Text;

namespace CouponManagementTestCase.DATA
{
    class CouponData
    {
        public int CouponId { get; set; }
        public string CouponNumber { get; set; }
        public string CouponStatus { get; set; }
        public DateTime CouponStartDate { get; set; }
        public DateTime CouponExpiredDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UserId { get; set; }

    }
}
