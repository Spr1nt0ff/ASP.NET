namespace homework.Models {
    public class Groups {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Students>? Students { get; set; } = new List<Students>();
    }
}
