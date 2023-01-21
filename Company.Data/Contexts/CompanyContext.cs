
using Company.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.Data.Contexts;

public class CompanyContext : DbContext
{
    public DbSet<CompanyTable> Companies => Set<CompanyTable>();
    public DbSet<Division> Divisions => Set<Division>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<EmployeePosition> EmployeePositions =>
     Set<EmployeePosition>();
    public DbSet<Position> Positions => Set<Position>();


    public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<EmployeePosition>().HasKey(ep => new
        {
            ep.EmployeeId,
            ep.PositionId
        });

        SeedData(builder);
    }

    private void SeedData(ModelBuilder builder)
    {
        var companies = new List<CompanyTable> {
        new CompanyTable
        {
            Id = 1,
            Name = "IKEASWE",
            OrgNumber = "1"
        },
         new CompanyTable
         {
             Id = 2,
             Name = "IKEANOR",
             OrgNumber = "2"
         },

         new CompanyTable
         {
             Id=3,
             Name = "IKEADEN",
             OrgNumber = "3"
         }
         };
        builder.Entity<CompanyTable>().HasData(companies);

        var divisions = new List<Division>
        {
            new Division
            {
                Id = 1,
                Name = "SWESales",
                CompanyId = 1,
            },

            new Division
            {
                Id = 2,
                Name = "NORLegal",
                CompanyId = 2,
            },

            new Division
            {
                Id = 3,
                Name = "NORStore",
                CompanyId = 2,
            },

            new Division
            {
                Id = 4,
                Name = "DENSales",
                CompanyId = 3,
            }
        };

        builder.Entity<Division>().HasData(divisions);

        var employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "Brandon",
                LastName = "Rojas",
                DivisionId = 4,
                Salary = 400000,
                TradeUnion = false
            },
               new Employee
            {
                Id = 2,
                FirstName = "Paula",
                LastName = "Harrison",
                DivisionId = 2,
                Salary = 550000,
                TradeUnion = true
            },
                new Employee
            {
                Id = 3,
                FirstName = "Kasper",
                LastName = "Fuller",
                DivisionId = 2,
                Salary = 475000,
                TradeUnion = true
            },
                new Employee
                {
                Id = 4,
                FirstName = "Wiktor",
                LastName = "Prince",
                DivisionId = 4,
                Salary = 375000,
                TradeUnion = false
                }
        };
        builder.Entity<Employee>().HasData(employees);

        var positions = new List<Position>
        {
            new Position
            {
                Id = 1,
                Name = "CEO"
            },
            new Position
            {
                Id = 2,
                Name = "Developer"
            },
            new Position
            {
                Id = 3,
                Name = "Manager"
            },
            new Position
            {
                Id = 4,
                Name = "CTO"
            },
        };
        builder.Entity<Position>().HasData(positions);

        var employeePositions = new List<EmployeePosition>
        {
            new EmployeePosition
            {
                EmployeeId = 1,
                PositionId = 1
            },
              new EmployeePosition
            {
                EmployeeId = 2,
                PositionId = 2
            },
                new EmployeePosition
            {
                EmployeeId = 2,
                PositionId = 3
            },
                  new EmployeePosition
            {
                EmployeeId = 3,
                PositionId = 4
            },
                  new EmployeePosition
            {
                EmployeeId = 4,
                PositionId = 2
            }
        };
        builder.Entity<EmployeePosition>().HasData(employeePositions);

    }




}
