using Bookfortable.Models;
using System.ComponentModel;

namespace Bookfortable.ViewModels
{
    public class CRelationViewModel
    {
         public Relation relation { get; set; }
        [DisplayName("書名")]
        public string productName { get; set; }
        [DisplayName("書的類別")]
        public string bookTagName { get; set; }
        public List<string> productNameList {  get; set; }  //將所有的標籤放進這個list
        public List<string> bookTagNameList { get; set; }

        public string  tagNameString { get; set; }
        public Product product { get; set; }

        public BookTag booktag { get; set; }
    }
}
