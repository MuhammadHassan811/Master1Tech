using Master1Tech.Client.Shared;
using Master1Tech.DTOs.Company;
using Master1Tech.Models;
using Master1Tech.Services;
using Master1Tech.Shared.Data;

public class CompanyService : ICompanyService
{

    private readonly IHttpService _httpService;
    private readonly ILogger<CompanyService> _logger;
    public CompanyService(IHttpService httpService, ILogger<CompanyService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<PagedResult<CompanyDto>> GenerateSampleCompanies(CompanyFilter filter, int page, int pageSize)
    {
        try
        {
            // The ideal way is to use a helper that builds the query string.
            // For example, using System.Net.Http.HttpClient and a helper method:
            var queryParams = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "pageSize", pageSize.ToString() },
                { "SortBy", filter.SortBy }
            };

            // This is a simplified representation of how you'd add list parameters.
            // A real implementation would need a more robust query string builder.
            string servicesQuery = filter.Services != null ? string.Join("&", filter.Services.Select(s => $"Services={s}")) : "";
            string technologiesQuery = filter.Technologies != null ? string.Join("&", filter.Technologies.Select(t => $"Technologies={t}")) : "";
            string industriesQuery = filter.Industries != null ? string.Join("&", filter.Industries.Select(i => $"Industries={i}")) : "";
            string yearsQuery = filter.Year != null ? string.Join("&", filter.Year.Select(y => $"Year={y}")) : "";

            string finalQuery = string.Join("&", new[] { servicesQuery, technologiesQuery, industriesQuery, yearsQuery }.Where(s => !string.IsNullOrEmpty(s)));
            string fullUrl = string.Empty;
            if (!string.IsNullOrEmpty(finalQuery))
            {
                fullUrl = $"api/company/search?page={page}&pageSize={pageSize}&SortBy={filter.SortBy}&{finalQuery}";
            }
            else
            {
                fullUrl = $"api/company/search?page={page}&pageSize={pageSize}&SortBy={filter.SortBy}";
            }


            // Assuming your httpService has a Get method.
            var result = await _httpService.Get<PagedResult<CompanyDto>>(fullUrl);

            return result ?? new PagedResult<CompanyDto>();
        }
        catch (Exception ex)
        {
            // Optionally log the error
            _logger.LogError(ex, "Error fetching companies from API");
            return new PagedResult<CompanyDto>(); // Return empty if it fails
        }
    }

    public async Task<Company?> GetCompanyByIdAsync(int id)
    {
        var companies = await _httpService.Get<Company>("api/company/" + id);
        return companies ?? null;
    }

    private List<Company> GenerateCompanies()
    {


        return new List<Company>
            {
                new() {
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
                new() {
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
                new() {
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
                new() {
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
                new() {
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
                new() {
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
                new() {
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
                new() {
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
                new() {
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
                new() {
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
                new() {
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

    public async Task<Company?> GetCompanyBySlugAsync(string slug)
    {
        var companies = await _httpService.Get<Company>("api/company/get/" + slug);
        return companies ?? null;
    }


    public async Task AddCompany(Company company)
    {
        await _httpService.Post($"api/company/add", company);
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
