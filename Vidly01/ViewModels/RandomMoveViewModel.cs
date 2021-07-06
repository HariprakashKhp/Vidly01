using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly01.Models;

namespace Vidly01.ViewModels
{
    public class RandomMoveViewModel
    {
        public Movie movie { get; set; }
        public List<Customer> customers { get; set; }
    }
}