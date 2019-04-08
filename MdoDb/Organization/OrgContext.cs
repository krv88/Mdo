using MdoDb.Organization.Model;
using System.Data.Entity;

namespace MdoDb.Organization
{
    public class OrgContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public OrgContext()
            : base("MdoConnection")
        { }

        static OrgContext()
        {
            Database.SetInitializer<OrgContext>(new OrgDbInitializer());
        }
    }

    public class OrgDbInitializer : DropCreateDatabaseIfModelChanges<OrgContext>
    {
        protected override void Seed(OrgContext context)
        {
            context.Employees.Add(new Employee()
            {
                FirstName = "Иван",
                MiddleName = "Иванович",
                LastName = "Иванов",
                BirthYear = 1968,
                Title = "Директор"
            });

            context.Employees.Add(new Employee()
            {
                FirstName = "Петр",
                MiddleName = "Петрович",
                LastName = "Петров",
                BirthYear = 1971,
                Title = "Бухгалтер"
            });

            context.Employees.Add(new Employee()
            {
                FirstName = "Алексей",
                MiddleName = "Алексеевич",
                LastName = "Алексеев",
                BirthYear = 1975,
                Title = "Водитель"
            });

            base.Seed(context);
        }
    }
}
