using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_job.Models
{
    public class job
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
