using System.Runtime.InteropServices;
using CandidateManagementSystem.Domain.Constants;
using CandidateManagementSystem.Domain.Entities;
using CandidateManagementSystem.Domain.Entities.Candidates;
using CandidateManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CandidateManagementSystem.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        // Default data
        // Seed, if necessary
        if (!_context.Candidates.Any())
        {
            string email = "john.doe@example.com";
            string firstName = "John";
            string lastName = "Doe";
            string? phoneNumber = "+1234567890";
            TimeSlot? bestTimeToCall = TimeSlot.Create(new DateTime(2022, 9, 30), new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0));
            string? linkedInProfileUrl = "https://www.linkedin.com/in/johndoe/";
            string? gitHubProfileUrl = "https://github.com/johndoe";
            string comment = "Experienced software developer";

            Candidate candidate = Candidate.CreateCandidate(email,
                firstName,
                lastName,
                phoneNumber,
                bestTimeToCall,
                linkedInProfileUrl,
                gitHubProfileUrl,
                comment);
            
            _context.Candidates.Add(candidate);

            await _context.SaveChangesAsync();
        }
    }
}
