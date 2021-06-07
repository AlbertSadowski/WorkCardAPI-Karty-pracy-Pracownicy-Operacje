namespace WorkCardAPI.Entities
{
    public class Operation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public int TimePrice { get; set; }
        public int WorkCardId { get; set; }
        public virtual WorkCard WorkCard { get; set; }

    }
}