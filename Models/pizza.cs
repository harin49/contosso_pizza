
namespace pizza.models
{

    public class Pizza
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsAllergic { get; set; }
    }
}