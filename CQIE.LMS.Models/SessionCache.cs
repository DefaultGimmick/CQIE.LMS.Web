using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQIE.LMS.Models
{
    [Table("TB_SessionCache")]
    public class SessionCache
    {
        public int nid { get; set; }
        public string Id { get; set; }
        public byte[] Value { get; set; }
        public DateTime ExpiresAtTime { get; set; }
        public long? SlidingExpirationSeconds { get; set; }
        public DateTime? AbsoluteExpiration { get; set; }

    }
}
