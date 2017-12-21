using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bobo.IService;
using bobo.entity;

namespace bobo.web.Pages
{
    public class IndexModel : PageModel
    {
        public ICategoryService cate { set; get; }
        public void OnGet()
        {
            Category cateModel = new Category();
            cateModel.Title = "前端";
            cateModel.CallIndex = "fe";
            cate.Add(cateModel);
        }
    }
}
