using BO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Pizza.Models;

namespace TP_Pizza.Controllers
{
    public class PizzaController : Controller
    {
        private static List<Pizza> pizzas;
        private static List<Pate> patesDisponibles;
        private static List<Ingredient> ingredientsDisponibles;

        public PizzaController()
        {
            // Lors de l'appel à la toute première action du controleur, les propriétés statiques seront chargées une et une seule fois pour toute la durée d'exécution du site       
            if (pizzas == null)
            {
                pizzas = new List<Pizza>();
            }

            if (patesDisponibles == null)
            {
                patesDisponibles = Pizza.PatesDisponibles;
            }

            if (ingredientsDisponibles == null)
            {
                ingredientsDisponibles = Pizza.IngredientsDisponibles;
            }
        }



        /// <summary>
        /// Renvoi un Viewmodel construit pour la modification d'une pizza
        /// </summary>
        /// <param name="id">l'id de la pizza à modifier</param>
        /// <returns></returns>
        private PizzaCreateEditVM GetPizzaCreateEditVM(int id)
        {
            // Nous avons beoin d'un viewModel pour porter l'objet pizza à modifier, plus la liste de tous les ingrédients et la liste des pâtes disponibles
            var vm = new PizzaCreateEditVM();

            // On récupère la pizza portant l'Id désiré dans la lsite des pizzas porté par le controller
            vm.Pizza = pizzas.FirstOrDefault(p => p.Id == id);

            // On créé directement l'objet attendu par la méthode ListBoxFor du HtmlHelper, qui nous permettra de choisir plusieurs ingrédients
            vm.Ingredients = ingredientsDisponibles.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();

            // On créer directement l'objet attendu par la méthode DropDownListFor du HtmlHelper, qui nous permettra de choisir une pâte
            vm.Pates = patesDisponibles.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();

            // Si la pizza avait déja une pâte, elle sera selectionnée sur la vue
            if (vm.Pizza.Pate != null)
            {
                vm.IdSelectedPate = vm.Pizza.Pate.Id;
            }

            // Si la pizza avait déja des ingrédients, ils seront pré selectionnés sur la vue de modification
            if (vm.Pizza.Ingredients.Any())
            {
                vm.IdSelectedIngredients = vm.Pizza.Ingredients.Select(i => i.Id).ToList();
            }
            return vm;
        }

        private bool CheckRules(PizzaCreateEditVM vm)
        {
            var brokenRules = 0;

            if (vm.Pizza.Nom.Length > 20 || vm.Pizza.Nom.Length < 5)
            {
                ModelState.AddModelError("", "Le nom d'une pizza doit avoir entre 5 et 20 caractères");
                brokenRules++;
            }


            if (vm.IdSelectedPate == 0)
            {
                ModelState.AddModelError("", "Une pizza doit avoir une pâte");
                brokenRules++;
            }

            if (pizzas.Any(p => p.Nom.ToUpper() == vm.Pizza.Nom.ToUpper() && p.Id != vm.Pizza.Id))
            {
                ModelState.AddModelError("", "Il existe déjà une pizza portant ce nom");
                brokenRules++;
            }

            if (vm.IdSelectedIngredients.Count < 2 || vm.IdSelectedIngredients.Count > 5)
            {
                ModelState.AddModelError("", "Une pizza doit avoir entre 2 et 5 ingrédients");
                brokenRules++;
            }

            var pizzasSameNumberIngredient = pizzas.Where(p => p.Ingredients.Count == vm.IdSelectedIngredients.Count && vm.Pizza.Id != p.Id);


            foreach (var pizza in pizzasSameNumberIngredient)
            {
                var sameIngredients = true;
                for (int i = 0; i < pizza.Ingredients.Count; i++)
                {
                    if (!vm.IdSelectedIngredients.Contains(pizza.Ingredients[i].Id))
                    {
                        sameIngredients = false;
                        break;
                    }
                }
                if (sameIngredients)
                {
                    ModelState.AddModelError("", "Il existe déjà une pizza avec ces ingrédients");
                    brokenRules++;
                    break;
                }
            }

            return brokenRules == 0;
        }

        // GET: Pizza
        public ActionResult Index()
        {
            // On appel la vue Index en lui passant la liste des pizzas attendu
            return View(pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            var vm = new PizzaCreateEditVM();
            vm.Ingredients = ingredientsDisponibles.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();
            vm.Pates = patesDisponibles.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaCreateEditVM pizzaCreateEditVM)
        {
            try
            {
                if (!CheckRules(pizzaCreateEditVM))
                {
                    throw new Exception("Une ou plusieurs rêgles métiers ne sont pas respectées sur une création de pizza");
                }

                var pizza = pizzaCreateEditVM.Pizza;

                // On récupère les objets ingrédients de la liste ingredientsDisponibles du controller à partir des ids choisis portés par le ViewModel, puis on les affecte à notre objet pizza
                pizza.Ingredients = ingredientsDisponibles.Where(i => pizzaCreateEditVM.IdSelectedIngredients.Contains(i.Id)).ToList();

                // On récupère l'objet pâte de la liste patesDisponibles du controller à partir de l'id porté par le ViewModel, puis on l'affecte à notre objet pizza
                if (pizzaCreateEditVM.IdSelectedPate != 0)
                {
                    pizza.Pate = patesDisponibles.FirstOrDefault(p => p.Id == pizzaCreateEditVM.IdSelectedPate);
                }


                // on affecte l'Id à partir de l'id max de notre liste de pizzas plus un.
                // si notre lsite est vide, on affecte la valeur 1.
                pizza.Id = pizzas.Any() ? pizzas.Max(p => p.Id) + 1 : 1;

                // On ajoute la nouvelle pizza à notre liste statique
                pizzas.Add(pizza);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                // Si nous avons rencontré une erreur, il faut recharger la page de création, de ce fait il nous faut ré-alimenter le Viewmodel avant de le passer à la vue

                pizzaCreateEditVM.Ingredients = ingredientsDisponibles.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();
                pizzaCreateEditVM.Pates = patesDisponibles.Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();
                return View(pizzaCreateEditVM);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetPizzaCreateEditVM(id));
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaCreateEditVM pizzaCreateEditVM)
        {
            try
            {
                if (!CheckRules(pizzaCreateEditVM))
                {
                    throw new Exception("Une ou plusieurs rêgles métiers ne sont pas respectées sur une modification de pizza");
                }

                var pizza = pizzas.FirstOrDefault(p => p.Id == pizzaCreateEditVM.Pizza.Id);
                pizza.Nom = pizzaCreateEditVM.Pizza.Nom;
                pizza.Ingredients = ingredientsDisponibles.Where(i => pizzaCreateEditVM.IdSelectedIngredients.Contains(i.Id)).ToList();

                if (pizzaCreateEditVM.IdSelectedPate != 0)
                {
                    pizza.Pate = patesDisponibles.FirstOrDefault(p => p.Id == pizzaCreateEditVM.IdSelectedPate);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View(GetPizzaCreateEditVM(pizzaCreateEditVM.Pizza.Id));
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                // on récupère l'objet pizza dans notre liste correspondant à l'id passé en paramètre, puis on le supprime.
                var pizza = pizzas.FirstOrDefault(p => p.Id == id);
                pizzas.Remove(pizza);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
