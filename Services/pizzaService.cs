using pizza.models;
using System;

namespace pizza.services
{

    public static class PizzaService
    {
        static List<Pizza> PizzaList { get; }

        static PizzaService()
        {
            PizzaList = [
                new Pizza{ Id = Guid.NewGuid(),  Name="Margherita", IsAllergic=true},
                new Pizza{ Id = Guid.NewGuid(), Name="Peppy", IsAllergic=false}
            ];
        }

        public static List<Pizza> GetAllPizzas()
        {
            return PizzaList;
        }

        public static Pizza? GetPizzaByID(string id) => PizzaList.Find(pizza => pizza.Id == Guid.Parse(id));


        public static void RemovePizzaById(string id)
        {
            var p = GetPizzaByID(id);

            if (p is null)
            {
                return;
            }

            PizzaList.Remove(p);
        }


        public static void AddPizza(Pizza newPizzaItem)
        {

            newPizzaItem.Id = Guid.NewGuid();
            PizzaList.Add(newPizzaItem);
        }

        public static void UpdatePizza(Pizza newPizzaItem)
        {
            var pizzaIndex = PizzaList.FindIndex(p => p.Id == newPizzaItem.Id);

            if (pizzaIndex == -1)
            {
                return;
            }

            PizzaList[pizzaIndex] = newPizzaItem;
        }

    }

}