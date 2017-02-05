using System;
using SalesApp.Model.Extensions;

namespace SalesApp.Model.Model
{
    public class BaseModel : NotifyModelChanged
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
