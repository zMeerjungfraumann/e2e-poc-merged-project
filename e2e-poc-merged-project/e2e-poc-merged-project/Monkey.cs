namespace e2e_poc_merged_project
{
    public class Monkey
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }

        public Monkey(string Name, string Location, string Details, string ImageUrl)
        {
            this.Name = Name;
            this.Location = Location;
            this.Details = Details;
            this.ImageUrl = ImageUrl;
        }
    }
}