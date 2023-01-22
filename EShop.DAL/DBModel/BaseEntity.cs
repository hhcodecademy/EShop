using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.DBModel
{
   public class BaseEntity
    {
        public int Id { get; set; }
        public int Status { get; set; } = 1;
        public DateTime InsertDate { get; set ; }
        public DateTime? UpdateDate { get; set; }
    }
}
