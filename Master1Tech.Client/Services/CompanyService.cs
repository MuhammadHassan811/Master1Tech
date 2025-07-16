using Master1Tech.Client.Pages.Company;
using Master1Tech.Client.Shared;
using Master1Tech.Models;
using Master1Tech.Services;
using Master1Tech.Shared.Data;
using Master1Tech.Shared.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

public class CompanyService : ICompanyService
{
    private readonly List<Company> _companies;
    private IHttpService _httpService;
    private bool _isInitialized;
    public CompanyService(IHttpService httpService)
    {
        _httpService = httpService;
    }
    
    public async Task<PagedResult<Company>> GetCompaniesAsync(string name, string page)
    {
        await Task.Delay(100); // Simulate API call
       
         return await _httpService.Get<PagedResult<Company>>("api/company/" + "?page=" + page + "&name=" + name);
        //var companies =
        //var query = companies.AsQueryable();

        //if (!string.IsNullOrEmpty(filter.Name))
        //    query = query.Where(c => c.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));

        //if (!string.IsNullOrEmpty(filter.Headquarters))
        //    query = query.Where(c => c.Headquarters.Contains(filter.Headquarters, StringComparison.OrdinalIgnoreCase));

        //if (filter.FoundedYear.HasValue)
        //    query = query.Where(c => c.FoundedYear == filter.FoundedYear);

        //if (filter.EmployeesCount.HasValue)
        //    query = query.Where(c => c.EmployeesCount >= filter.EmployeesCount);

        //if (filter.IsVerified.HasValue)
        //    query = query.Where(c => c.IsVerified == filter.IsVerified);

        //return query.ToList();
    }

    public async Task<int> GetCompanyCountAsync(string name, string page)
    {
        var companies = await GetCompaniesAsync(name, page);
        return companies.RowCount;
    }

    public async Task<List<Company>> GenerateSampleCompanies()
    {
        try
        {
            var companies = await _httpService.Get<List<Company>>("api/company/");

            if (companies == null)
            {
                return GenerateFakeSampleCompanies(); // Return empty list if null
            }

            return companies;
        }
        catch (Exception ex)
        {
            // Log error if you have logging configured
            // _logger.LogError(ex, "Error fetching companies from API");
            return GenerateFakeSampleCompanies();
        }
    }

    private List<Company> GenerateFakeSampleCompanies()
    {
        return new List<Company>
        {
            new Company
            {
                CompanyID = 1,
                Name = "ZAPTA Technologies",
                Description = "ZAPTA Technologies is a software design and development company known for its customized and innovative solutions.",
                FoundedYear = 2015,
                EmployeesCount = 200,
                Headquarters = "Lahore, Pakistan",
                WebsiteURL = "https://www.zapta.com",
                LogoURL = "/images/zapta-logo.png",
                IsVerified = true,
                DateAdded = DateTime.Now.AddYears(-5),
                LastUpdated = DateTime.Now.AddDays(-10),
                CompanyServices = new List<CompaniesService>
                {
                    new CompaniesService { Service = new Service { ServiceID = 1, Name = "Custom Software Development" } },
                    new CompaniesService { Service = new Service { ServiceID = 2, Name = "Web Development" } }
                },
                CompanyCategories = new List<CompaniesCategory>
                {
                    new CompaniesCategory { Category = new Category { Id = 1, Name = "Software Development" } }
                },
                Technologies = new List<CompanyTechnology>
                {
                    new CompanyTechnology
                    {
                        Technology = new Technology { TechnologyID = 1, Name = "C#", Category = "Programming Language" },
                        ProficiencyLevel = "Expert"
                    }
                },
                Reviews = new List<Review>
                {
                    new Review
                    {
                        ReviewID = 1,
                        ReviewerName = "Client A",
                        Rating = 4.5m,
                        Title = "Excellent Service",
                        Comment = "ZAPTA delivered outstanding results for our project.",
                        IsApproved = true
                    }
                }
            },
            new Company
            {
                CompanyID = 2,
                Name = "Eagle Alliance Technology Pvt. Ltd",
                Description = "Eagle Alliance Technology: Igniting Success Through Innovative Tech Solutions.",
                FoundedYear = 2018,
                EmployeesCount = 30,
                Headquarters = "Rawalpindi, Pakistan",
                WebsiteURL = "https://www.eaglealliance.com",
                LogoURL = "/images/eagle-logo.png",
                IsVerified = true,
                DateAdded = DateTime.Now.AddYears(-3),
                LastUpdated = DateTime.Now.AddDays(-5),
                CompanyServices = new List<CompaniesService>
                {
                    new CompaniesService { Service = new Service { ServiceID = 2, Name = "Web Development" } },
                    new CompaniesService { Service = new Service { ServiceID = 3, Name = "E-Commerce Development" } }
                },
                Technologies = new List<CompanyTechnology>
                {
                    new CompanyTechnology
                    {
                        Technology = new Technology { TechnologyID = 2, Name = "JavaScript", Category = "Programming Language" },
                        ProficiencyLevel = "Expert"
                    }
                }
            },
            new Company
            {
                CompanyID = 3,
                Name = "AppNation",
                Description = "Apps Nation LLC delivers rapid, cost-effective software solutions.",
                FoundedYear = 2014,
                EmployeesCount = 150,
                Headquarters = "Karachi, Pakistan",
                WebsiteURL = "https://www.appnation.com",
                LogoURL = "/images/appnation-logo.png",
                IsVerified = true,
                DateAdded = DateTime.Now.AddYears(-7),
                LastUpdated = DateTime.Now.AddDays(-3),
                CompanyServices = new List<CompaniesService>
                {
                    new CompaniesService { Service = new Service { ServiceID = 4, Name = "Mobile App Development" } }
                },
                Technologies = new List<CompanyTechnology>
                {
                    new CompanyTechnology
                    {
                        Technology = new Technology { TechnologyID = 3, Name = "React Native", Category = "Framework" },
                        ProficiencyLevel = "Expert"
                    }
                }
            }
        };
    }
}

//public class CompanyFilter
//{
//    public string Name { get; set; }
//    public string Headquarters { get; set; }
//    public int? FoundedYear { get; set; }
//    public int? EmployeesCount { get; set; }
//    public bool? IsVerified { get; set; }
//}