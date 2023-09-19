using FristApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FristApp.Controllers;
public class CityController : Controller
{
    private readonly HttpClient _httpClient;
    public CityController(IHttpClientFactory httpClientFactory) => _httpClient = httpClientFactory.CreateClient("EmployeeApi");
    private async Task<List<City>> GetAllCity()
    {
        var data = await _httpClient.GetFromJsonAsync<List<City>>("City");
        return data is not null ? data : new List<City>();
    }

    public async Task<IActionResult> Index() => View(await GetAllCity());
    public async Task<IActionResult> AddOrEdit(int id)
    {
        var stateResponse = await _httpClient.GetAsync("State");
        if (stateResponse.IsSuccessStatusCode)
        {
            var content = await stateResponse.Content.ReadAsStringAsync();
            var countryList = JsonConvert.DeserializeObject<List<State>>(content);
            ViewData["stateId"] = new SelectList(countryList, "Id", "StateName");
        }
        if (id is 0) return View(new City());
        else
        {
            var data = await _httpClient.GetAsync($"City/{id}");
            var city = await data.Content.ReadFromJsonAsync<City>();
            return View(city);
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddOrEdit(int id, City city)
    {
        if(id is 0)
        {
            // saving Data
          var data=  await _httpClient.PostAsJsonAsync("City", city);
            if (data.IsSuccessStatusCode) 
                return RedirectToAction("Index");
        }
        else
        {
            // editing data
            var data = await _httpClient.PutAsJsonAsync($"City/{id}", city);
            if(data.IsSuccessStatusCode) 
                return RedirectToAction("Index");
        }
        return View(new City());
    }
    public async  Task<IActionResult> Delete(int id)
    {
        await _httpClient.DeleteAsync($"City/{id},");
        return RedirectToAction("Index");
    }
}
