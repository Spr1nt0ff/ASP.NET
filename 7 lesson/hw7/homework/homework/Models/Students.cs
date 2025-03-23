namespace homework.Models {
    public class Students {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }

        public int GroupId { get; set; }
        public Groups? Group { get; set; }
    }
}
