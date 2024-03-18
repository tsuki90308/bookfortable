using bookfortable.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookfortable.ViewModels
{
    public class BlogEditViewModel
    {
        public Blog Blog { get; set; }
        public BlogImage BlogImage { get; set; }
    }
}