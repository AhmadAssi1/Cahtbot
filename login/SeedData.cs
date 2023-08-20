using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using login.models;
using login.Data;

namespace Login.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                if (context.Users.Any())
                {
                    // Database has been seeded
                    return;
                }

                await SeedUsers(context);
                await SeedAgents(context);
                await SeedClients(context);
            }
        }

        private static async Task SeedUsers(DataContext context)
        {
            // Seed users here
            var users = new user[]
            {
                new user { FirstName = "John", LastName = "Doe", Email = "john@example.com", Password = "password123", BarthDate = new DateTime(1990, 1, 15) },
                // Add more users as needed
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAgents(DataContext context)
        {
            // Seed agents here
            var agents = new Agents[]
            {
                new Agents { FirstName = "Agent", LastName = "Smith", Email = "agent@example.com", Password = "agentpass", BarthDate = new DateTime(1985, 5, 20), EmployeeId = 123, OnDutyStatus = true, WorkingHours = 8 },
                // Add more agents as needed
            };

            await context.Agents.AddRangeAsync(agents);
            await context.SaveChangesAsync();
        }

        private static async Task SeedClients(DataContext context)
        {
            // Seed clients here
            var clients = new clients[]
            {
                new clients { FirstName = "Client", LastName = "Johnson", Email = "client@example.com", Password = "clientpass", BarthDate = new DateTime(1995, 10, 8), OrderId = 456 },
                // Add more clients as needed
            };

            await context.Clients.AddRangeAsync(clients);
            await context.SaveChangesAsync();
        }

        
    }
}