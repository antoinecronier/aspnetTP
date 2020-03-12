using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP_Pizza.Models
{
    public class PizzaCreateEditVM
    {
        public Pizza Pizza { get; set; }
        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();

        public int IdSelectedPate { get; set; }
        public List<int> IdSelectedIngredients { get; set; } = new List<int>();
    }
}