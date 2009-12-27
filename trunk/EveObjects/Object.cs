namespace EveObjects
{
    public class Object
    {
        public double Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
