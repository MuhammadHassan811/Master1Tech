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
    private bool _isInitialized;


    private readonly IHttpService _httpService;
    private PagedResult<Company> _companies;

    public CompanyService(IHttpService httpService)
    {
        _httpService = httpService;
        //_ = InitializeAsync(); // fire and forget (or better: call from a method in the component)
    }

    //private async Task InitializeAsync()
    //{
    //    _companies = await GenerateSampleCompanies();
    //}

    public async Task<PagedResult<Company>> GenerateSampleCompanies()
    {
        try
        {
            var companies = await _httpService.Get<PagedResult<Company>>("api/company/");
            return companies ?? new PagedResult<Company>();
        }
        catch (Exception ex)
        {
            // Optionally log the error
            // _logger.LogError(ex, "Error fetching companies from API");
            return new PagedResult<Company>(); // Return empty if it fails
        }
    }

    public async Task<CompanyDTO?> GetCompanyByIdAsync(int id)
    {
        var companies = await _httpService.Get<CompanyDTO>("api/company/" + id);
        return companies ?? null;
    }


    public PagedResult<Company> GetCompanies() => _companies ?? new PagedResult<Company>();
    //public CompanyService()
    //{
    //    _companies = GenerateSampleCompanies();
    //}
    //public CompanyService(IHttpService httpService)
    //{
    //    _httpService = httpService;

    //}

    //public async Task<PagedResult<Company>> GetCompaniesAsync(string name, string page)
    //{
    //    await Task.Delay(100); // Simulate API call

    //     return await _httpService.Get<PagedResult<Company>>("api/company/" + "?page=" + page + "&name=" + name);
    //    //var companies =
    //    //var query = companies.AsQueryable();

    //    //if (!string.IsNullOrEmpty(filter.Name))
    //    //    query = query.Where(c => c.Name.Contains(filter.Name, StringComparison.OrdinalIgnoreCase));

    //    //if (!string.IsNullOrEmpty(filter.Headquarters))
    //    //    query = query.Where(c => c.Headquarters.Contains(filter.Headquarters, StringComparison.OrdinalIgnoreCase));

    //    //if (filter.FoundedYear.HasValue)
    //    //    query = query.Where(c => c.FoundedYear == filter.FoundedYear);

    //    //if (filter.EmployeesCount.HasValue)
    //    //    query = query.Where(c => c.EmployeesCount >= filter.EmployeesCount);

    //    //if (filter.IsVerified.HasValue)
    //    //    query = query.Where(c => c.IsVerified == filter.IsVerified);

    //    //return query.ToList();
    //}

    //public async Task<int> GetCompanyCountAsync(string name, string page)
    //{
    //    var companies = await GetCompaniesAsync(name, page);
    //    return companies.RowCount;
    //}

    //public async Task<PagedResult<Company>> GetCompaniesAsync(CompanyFilter? filter = null, int page = 1, int pageSize = 9)
    //{
    //    await Task.Delay(100); // Simulate async operation

    //    var query = _companies.Results;

    //    if (filter != null)
    //    {
    //        if (!string.IsNullOrEmpty(filter.Location))
    //            query = query.Where(c => c.Location.Contains(filter.Location, StringComparison.OrdinalIgnoreCase));

    //        //if (!string.IsNullOrEmpty(filter.Services))
    //        //    query = query.Where(c => c.Services.Any(s => s.Contains(filter.Services, StringComparison.OrdinalIgnoreCase)));

    //        if (!string.IsNullOrEmpty(filter.TeamSize))
    //            query = query.Where(c => c.TeamSize == filter.TeamSize);

    //        if (!string.IsNullOrEmpty(filter.HourlyRate))
    //            query = query.Where(c => c.HourlyRate == filter.HourlyRate);

    //        // Apply sorting
    //        query = filter.SortBy switch
    //        {
    //            "rating" => query.OrderByDescending(c => c.Rating),
    //            "name" => query.OrderBy(c => c.Name),
    //            "location" => query.OrderBy(c => c.Location),
    //            _ => query.OrderBy(c => c.Id)
    //        };
    //    }

    //    return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    //}

    //public async Task<int> GetTotalCompaniesAsync(CompanyFilter? filter = null)
    //{
    //    await Task.Delay(50);

    //    var query = _companies.AsQueryable();

    //    if (filter != null)
    //    {
    //        if (!string.IsNullOrEmpty(filter.Location))
    //            query = query.Where(c => c.Location.Contains(filter.Location, StringComparison.OrdinalIgnoreCase));

    //        //if (!string.IsNullOrEmpty(filter.Services))
    //        //    query = query.Where(c => c.Services.Any(s => s.Contains(filter.Services, StringComparison.OrdinalIgnoreCase)));

    //        if (!string.IsNullOrEmpty(filter.TeamSize))
    //            query = query.Where(c => c.TeamSize == filter.TeamSize);

    //        if (!string.IsNullOrEmpty(filter.HourlyRate))
    //            query = query.Where(c => c.HourlyRate == filter.HourlyRate);
    //    }

    //    return query.Count();
    //}

    private List<Company> GenerateCompanies()
    {


        return new List<Company>
            {
                new Company
                {
                    Id = 1,
                    Name = "ZAPTA Technologies",
                    Location = "Lahore, Pakistan",
                    Description = "Customized Software Design and Development",
                    TeamSize = "50-249",
                    HourlyRate = "$25-49",
                    Rating = 4,
                    IsVerified = true,
                   // Services = new List<string> { "Custom Software Development", "Web Development", "IT Staff Augmentation" },
                    LogoText = "Z",
                    LogoColor = "#4a90e2"
                },
                new Company
                {
                    Id = 2,
                    Name = "Eagle Alliance Technology Pvt. Ltd",
                    Location = "Rawalpindi, Pakistan",
                    Description = "Eagle Alliance Technology: Igniting Success Through Innovative Tech Solutions.",
                    TeamSize = "10-49",
                    HourlyRate = "Not revealed",
                    Rating = 3,
                    IsVerified = true,
                    //Services = new List<string> { "Web Development", "E-Commerce Development", "Web Design" },
                    LogoText = "EA",
                    LogoColor = "#28a745"
                },
                new Company
                {
                    Id = 3,
                    Name = "AppsNation",
                    Location = "Karachi, Pakistan",
                    Description = "Apps Nation LLC, based in LA since 2016, delivers rapid, cost-effective software solutions, including mobile, web, AR/VR, and game development.",
                    TeamSize = "50-249",
                    HourlyRate = "$25-49",
                    Rating = 3,
                    IsVerified = true,
                    //Services = new List<string> { "Mobile App Development", "Custom Software Development", "Web Development" },
                    LogoText = "AN",
                    LogoColor = "#ff6b6b"
                },
                new Company
                {
                    Id = 4,
                    Name = "DeviceBee Technologies",
                    Location = "Lahore, Pakistan",
                    Description = "Best Mobile Apps Development Company in Dubai",
                    TeamSize = "10-49",
                    HourlyRate = "$25-49",
                    Rating = 5,
                    IsVerified = true,
                   // Services = new List<string> { "Mobile App Development", "Web Development", "UI/UX Design" },
                    LogoText = "DB",
                    LogoColor = "#9c27b0"
                },
                new Company
                {
                    Id = 5,
                    Name = "Zaavia",
                    Location = "Karachi, Pakistan",
                    Description = "Intuitive Apps, Custom Software, Websites & Cloud Services with captivating UI/UX—tailored to meet your business needs.",
                    TeamSize = "50-249",
                    HourlyRate = "Not revealed",
                    Rating = 3,
                    IsVerified = false,
                   // Services = new List<string> { "Custom Software Development", "Web Development", "Mobile App Development" },
                    LogoText = "Z",
                    LogoColor = "#f39c12"
                },
                new Company
                {
                    Id = 6,
                    Name = "Aptagon Technologies",
                    Location = "Okara, Pakistan",
                    Description = "Where Innovation Meets Excellence. Empowering Businesses through Custom Software Design & Development Services.",
                    TeamSize = "10-49",
                    HourlyRate = "$25-49",
                    Rating = 2,
                    IsVerified = true,
                   // Services = new List<string> { "Custom Software Development", "Web Development", "Mobile App Development" },
                    LogoText = "AT",
                    LogoColor = "#e74c3c"
                },
                new Company
                {
                    Id = 7,
                    Name = "Phaedra Solutions",
                    Location = "Karachi, Pakistan",
                    Description = "Custom Software Development, Mobile App Development, Website Design & Web Development | 250+ Global Clients",
                    TeamSize = "50-249",
                    HourlyRate = "$25-49",
                    Rating = 5,
                    IsVerified = true,
                    //Services = new List<string> { "Custom Software Development", "Mobile App Development", "Web Development" },
                    LogoText = "PS",
                    LogoColor = "#8e44ad"
                },
                new Company
                {
                    Id = 8,
                    Name = "Arbisoft",
                    Location = "Lahore, Pakistan",
                    Description = "If you can imagine it, we can build it. Leading software development company specializing in AI and machine learning solutions.",
                    TeamSize = "200+",
                    HourlyRate = "$50-99",
                    Rating = 4,
                    IsVerified = true,
                   // Services = new List<string> { "AI Development", "Custom Software Development", "Web Development" },
                    LogoText = "AS",
                    LogoColor = "#2c3e50"
                },
                new Company
                {
                    Id = 9,
                    Name = "Design Bub",
                    Location = "Islamabad, Pakistan",
                    Description = "Your hub for professional logo, web, and graphic design services, transforming ideas into stunning visuals.",
                    TeamSize = "10-49",
                    HourlyRate = "$10-24",
                    Rating = 5,
                    IsVerified = false,
                    //Services = new List<string> { "Graphic Design", "Web Design", "Logo Design" },
                    LogoText = "DB",
                    LogoColor = "#16a085"
                },
                new Company
        {
            Id = 10,
            Name = "Techlogix Pakistan",
            Location = "Karachi, Pakistan",
            Description = "Enterprise software solutions provider with global delivery capabilities.",
            TeamSize = "250-999",
            HourlyRate = "$50-99",
            Rating = 4,
            IsVerified = true,
            //Services = new List<string> { "Enterprise Solutions", "CRM Implementation", "Business Intelligence" },
            LogoText = "TL",
            LogoColor = "#3498db"
        },
                new Company
        {
            Id = 11,
            Name = "Cloudways",
            Location = "Lahore, Pakistan",
            Description = "Managed cloud hosting platform helping businesses focus on growth rather than server management.",
            TeamSize = "100-249",
            HourlyRate = "$25-49",
            Rating = 5,
            IsVerified = true,
            //Services = new List<string> { "Cloud Hosting", "Server Management", "Web Performance" },
            LogoText = "CW",
            LogoColor = "#1abc9c"
        }
            };
    }

    #region
    //public List<Company> GenerateSampleCompanies()
    //{
    //    try
    //    {
    //        var companies =  _httpService.Get<List<Company>>("api/company/");

    //        //if (companies == null)
    //        //{
    //        //    return GenerateFakeSampleCompanies(); // Return empty list if null
    //        //}

    //        return companies;
    //    }
    //    catch (Exception ex)
    //    {
    //        // Log error if you have logging configured
    //        // _logger.LogError(ex, "Error fetching companies from API");
    //        //return GenerateFakeSampleCompanies();
    //    }
    //}

    //private List<Company> GenerateFakeSampleCompanies()
    //{
    //    return new List<Company>
    //    {
    //        new Company
    //        {
    //            CompanyID = 1,
    //            Name = "ZAPTA Technologies",
    //            Description = "ZAPTA Technologies is a software design and development company known for its customized and innovative solutions.",
    //            FoundedYear = 2015,
    //            EmployeesCount = 200,
    //            Headquarters = "Lahore, Pakistan",
    //            WebsiteURL = "https://www.zapta.com",
    //            LogoURL = "/images/zapta-logo.png",
    //            IsVerified = true,
    //            DateAdded = DateTime.Now.AddYears(-5),
    //            LastUpdated = DateTime.Now.AddDays(-10),
    //            CompanyServices = new List<CompaniesService>
    //            {
    //                new CompaniesService { Service = new Service { ServiceID = 1, Name = "Custom Software Development" } },
    //                new CompaniesService { Service = new Service { ServiceID = 2, Name = "Web Development" } }
    //            },
    //            CompanyCategories = new List<CompaniesCategory>
    //            {
    //                new CompaniesCategory { Category = new Category { Id = 1, Name = "Software Development" } }
    //            },
    //            Technologies = new List<CompanyTechnology>
    //            {
    //                new CompanyTechnology
    //                {
    //                    Technology = new Technology { TechnologyID = 1, Name = "C#", Category = "Programming Language" },
    //                    ProficiencyLevel = "Expert"
    //                }
    //            },
    //            Reviews = new List<Review>
    //            {
    //                new Review
    //                {
    //                    ReviewID = 1,
    //                    ReviewerName = "Client A",
    //                    Rating = 4.5m,
    //                    Title = "Excellent Service",
    //                    Comment = "ZAPTA delivered outstanding results for our project.",
    //                    IsApproved = true
    //                }
    //            }
    //        },
    //        new Company
    //        {
    //            CompanyID = 2,
    //            Name = "Eagle Alliance Technology Pvt. Ltd",
    //            Description = "Eagle Alliance Technology: Igniting Success Through Innovative Tech Solutions.",
    //            FoundedYear = 2018,
    //            EmployeesCount = 30,
    //            Headquarters = "Rawalpindi, Pakistan",
    //            WebsiteURL = "https://www.eaglealliance.com",
    //            LogoURL = "/images/eagle-logo.png",
    //            IsVerified = true,
    //            DateAdded = DateTime.Now.AddYears(-3),
    //            LastUpdated = DateTime.Now.AddDays(-5),
    //            CompanyServices = new List<CompaniesService>
    //            {
    //                new CompaniesService { Service = new Service { ServiceID = 2, Name = "Web Development" } },
    //                new CompaniesService { Service = new Service { ServiceID = 3, Name = "E-Commerce Development" } }
    //            },
    //            Technologies = new List<CompanyTechnology>
    //            {
    //                new CompanyTechnology
    //                {
    //                    Technology = new Technology { TechnologyID = 2, Name = "JavaScript", Category = "Programming Language" },
    //                    ProficiencyLevel = "Expert"
    //                }
    //            }
    //        },
    //        new Company
    //        {
    //            CompanyID = 3,
    //            Name = "AppNation",
    //            Description = "Apps Nation LLC delivers rapid, cost-effective software solutions.",
    //            FoundedYear = 2014,
    //            EmployeesCount = 150,
    //            Headquarters = "Karachi, Pakistan",
    //            WebsiteURL = "https://www.appnation.com",
    //            LogoURL = "/images/appnation-logo.png",
    //            IsVerified = true,
    //            DateAdded = DateTime.Now.AddYears(-7),
    //            LastUpdated = DateTime.Now.AddDays(-3),
    //            CompanyServices = new List<CompaniesService>
    //            {
    //                new CompaniesService { Service = new Service { ServiceID = 4, Name = "Mobile App Development" } }
    //            },
    //            Technologies = new List<CompanyTechnology>
    //            {
    //                new CompanyTechnology
    //                {
    //                    Technology = new Technology { TechnologyID = 3, Name = "React Native", Category = "Framework" },
    //                    ProficiencyLevel = "Expert"
    //                }
    //            }
    //        }
    //    };
    //}
    #endregion
}

//public class CompanyFilter
//{
//    public string Name { get; set; }
//    public string Headquarters { get; set; }
//    public int? FoundedYear { get; set; }
//    public int? EmployeesCount { get; set; }
//    public bool? IsVerified { get; set; }
//}