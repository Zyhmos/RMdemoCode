//RMA 20/12/20 TFS-[Practice Task] File Creation

using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class Type : IType
    {
        public int TypeID { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}