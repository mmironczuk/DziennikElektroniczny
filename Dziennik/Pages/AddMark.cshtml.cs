using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dziennik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Dziennik.Pages
{
    public class AddMarkModel : PageModel
    {
        public Ocena ocena { get; set; }
        public IConfiguration _configuration { get; }
        public AddMarkModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet(int _iducznia)
        {

        }
    }
}