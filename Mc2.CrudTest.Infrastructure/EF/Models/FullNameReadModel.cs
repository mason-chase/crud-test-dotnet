namespace Mc2.CrudTest.Infrastructure.EF.Models
{
    internal class FullNameReadModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public static FullNameReadModel Create(string value)
        {
            var splitted = value.Split(',');
            var first = splitted.First();
            var last = splitted.Last();
            return new FullNameReadModel {FirstName= splitted.First(), LastName= splitted.Last() };
        }
        public override string ToString() => $"{FirstName},{LastName}";
    }
}
