using FristApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace FristApp.Controllers;

public class EmployeeController : Controller
{
    private readonly HttpClient _httpClient;

    public EmployeeController(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient("EmployeeApi");
    private async Task<List<Employee>> GetAllEmployee()
    {
        var employeeData = await _httpClient.GetFromJsonAsync<List<Employee>>("Employee");
        return employeeData is not null ? employeeData : new List<Employee>();
    }


    public async Task<IActionResult> Index() => View(await GetAllEmployee());

    [HttpGet]
    public async Task<IActionResult> AddOrEdit(int id)
    {
        var countryResponse = await _httpClient.GetAsync("Country");
        if (countryResponse.IsSuccessStatusCode)
        {
            var content = await countryResponse.Content.ReadAsStringAsync();
            var countrylist = JsonConvert.DeserializeObject<List<Country>>(content);
            ViewData["CountryId"] = new SelectList(countrylist, "Id", "CountryName");
        }
        var stateResponse = await _httpClient.GetAsync("State");
        if (stateResponse.IsSuccessStatusCode)
        {
            var content = await stateResponse.Content.ReadAsStringAsync();
            var stateList = JsonConvert.DeserializeObject<List<State>>(content);
            ViewData["StateId"] = new SelectList(stateList, "Id", "StateName");

        }
        var cityResponse = await _httpClient.GetAsync("City");
        if (cityResponse.IsSuccessStatusCode)
        {
            var content = await cityResponse.Content.ReadAsStringAsync();
            var cityList = JsonConvert.DeserializeObject<List<City>>(content);
            ViewData["CityId"] = new SelectList(cityList, "Id", "CityName");
        }
        if (id is 0)
        {
            return View(new Employee());
        }
        else
        {
            var employeeData = await _httpClient.GetAsync($"Employee/{id}");
            var employees = await employeeData.Content.ReadFromJsonAsync<Employee>();

            return View(employees);
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddOrEdit(int id, IFormFile pictureFile, Employee employee)
    {

        if (ModelState.IsValid)
        {
            //save
            if (id == 0)
            {

                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    employee.Picture = pictureFile.FileName;
                }
                var response = await _httpClient.PostAsJsonAsync("Employee", employee);
                if (response.IsSuccessStatusCode) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError("", "Faild to Create New Employee");
                    return View(employee);
                }
            }
            else
            {
                //update
                if (id != employee.Id)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {
                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureFile.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        employee.Picture = pictureFile.FileName;
                    }
                    var response = await _httpClient.PutAsJsonAsync($"Employee/{id}", employee);
                    if (response.IsSuccessStatusCode) return RedirectToAction("Index");

                    else
                    {
                        ModelState.AddModelError("", "Faild to Update employee");
                        return View(employee);
                    }
                }
            }
        }
        return View(employee);
    }
}

        
        

    

    



    





