using System;
using System.Collections.Generic;
using System.Text;

namespace ITB.Business
{
    public class Project : BaseMongoId
    {
        // Client User Name
        public string UserName { get; set; }

        public List<string> InvitedContractors { get; set; } = new List<string>();
        public List<string> AppliedContractors { get; set; } = new List<string>();
        public string SelectedContractor;

        public string JobTitle { get; set; }
        public List<string> Skills { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public ContractType ContractType { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
