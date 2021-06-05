using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncAwaitPractice.Models;

namespace AsyncAwaitPractice.ViewModels
{
    public class ApiViewModel
    {
        public string RandomNumber { get; set; }
        public Punchline Punchline { get; set; }
        public SeleucidList SeleucidList { get; set; }

    }
}
