using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly01.Models;

namespace Vidly01.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembeshipType { get; set; }
        public Customer customer { get; set; }
    }
}