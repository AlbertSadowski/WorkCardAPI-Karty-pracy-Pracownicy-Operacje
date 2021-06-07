using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCardAPI.Entities;

namespace WorkCardAPI
{
    public class WorkCardSeeder
    {
        private readonly WorkCardDbContext _dbContext;

        public WorkCardSeeder(WorkCardDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.WorkCards.Any())
                {
                    var workCards = GetWorkCards();
                    _dbContext.WorkCards.AddRange(workCards);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {   new Role()
                {
                   Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }

        private IEnumerable<WorkCard> GetWorkCards()
        {
            var workCards = new List<WorkCard>()
            {
                new WorkCard()
                {

                    CardNumber = "WC-1",
                    Order = "ORD-001",
                    Technology = "Technology 001",
                    NumberOfOperations = 12,
                    StartPoint = new DateTime(2021, 5, 21, 12, 0, 0),
                    EndPoint = new DateTime(2021, 5, 21, 15, 0, 0),
                    Duration = 3,
                    Employee = new Employee()
                    {
                        Name = "John Smith",
                        Description = "Expert",
                        Category = "Production Worker",
                        IsAvailable = true,
                        ContactEmail = "john.smith@gmail.com",
                        ContactNumber = "600500400"
                    },
                    Operations = new List<Operation>()
                    {
                        new Operation()
                        {
                            Code = "OP-001",
                            Name = "Operation 001",
                            Description = "Description 001",
                            Number = 45,
                            Price = 3,
                            TimePrice = 22
                        },
                        new Operation()
                        {
                            Code = "OP-002",
                            Name = "Operation 002",
                            Description = "Description 002",
                            Number = 67,
                            Price = 4,
                            TimePrice = 23
                        }
                    }
                },

                new WorkCard()
                {

                    CardNumber = "WC-2",
                    Order = "ORD-002",
                    Technology = "Technology 002",
                    NumberOfOperations = 18,
                    StartPoint = new DateTime(2021, 5, 20, 11, 0, 0),
                    EndPoint = new DateTime(2021, 5, 20, 19, 0, 0),
                    Duration = 7,
                    Employee = new Employee()
                    {
                        Name = "James Brown",
                        Description = "Mid Lever Expert",
                        Category = "Production Worker",
                        IsAvailable = true,
                        ContactEmail = "jams.brown@gmail.com",
                        ContactNumber = "611522401"
                    },
                    Operations = new List<Operation>()
                    {
                        new Operation()
                        {
                            Code = "OP-003",
                            Name = "Operation 003",
                            Description = "Description 003",
                            Number = 65,
                            Price = 5,
                            TimePrice = 19
                        },
                        new Operation()
                        {
                            Code = "OP-004",
                            Name = "Operation 004",
                            Description = "Description 004",
                            Number = 88,
                            Price = 4,
                            TimePrice = 18
                        }
                    }
                }
            };

            return workCards;
        }
    }
}
