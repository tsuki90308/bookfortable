using Bookfortable.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookfortable.ViewModels
{
    public class BlogViewModel
    {
        public Blog Blog { get; set; }
        public BlogImage BlogImage { get; set; }
    }
}
