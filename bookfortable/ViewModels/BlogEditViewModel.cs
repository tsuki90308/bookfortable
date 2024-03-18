using Bookfortable.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookfortable.ViewModels
{
    public class BlogEditViewModel
    {
        public Blog Blog { get; set; }
        public BlogImage BlogImage { get; set; }
    }
}