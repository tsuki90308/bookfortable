using bookfortable.Models;
using System.ComponentModel;

namespace bookfortable.ViewModels
{
    public class CRelationViewModel
    {
         public Relation relation { get; set; }
        [DisplayName("書名")]
        public string productName { get; set; }
        [DisplayName("書的類別")]
        public string bookTagName { get; set; }
        public List<string> productNameList {  get; set; }
        public List<string> bookTagNameList { get; set; }

    }
}
