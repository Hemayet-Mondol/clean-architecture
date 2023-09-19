using FristApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FristApp.Controllers
{
    public class StateController : Controller
    {

        private readonly HttpClient _httpClient;

        public StateController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7138/api/");
        }
        private async Task<List<State>> GetStateFromApi()
        {
            var response = await _httpClient.GetAsync("State");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var States = JsonConvert.DeserializeObject<List<State>>(content);
                return States;
            }
            return new List<State>();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await GetStateFromApi();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> AddorEdit(int id)
        {
            if (id == 0)
            {
                var countryresponse = await _httpClient.GetAsync("Country");
                if (countryresponse.IsSuccessStatusCode)
                {
                    var content = await countryresponse.Content.ReadAsStringAsync();
                    var countryList = JsonConvert.DeserializeObject<List<Country>>(content);
                    ViewData["CountryId"] = new SelectList(countryList, "Id", "CountryName");
                }

                return View(new State());
            }
            else
            {
                var countryresponse = await _httpClient.GetAsync("Country");
                if (countryresponse.IsSuccessStatusCode)
                {
                    var content = await countryresponse.Content.ReadAsStringAsync();
                    var countryList = JsonConvert.DeserializeObject<List<Country>>(content);
                    ViewData["CountryId"] = new SelectList(countryList, "Id", "CountryName");
                }

                var response = await _httpClient.GetAsync($"State/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var newData = await response.Content.ReadFromJsonAsync<State>();
                    return View(newData);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit(int id, State state)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    //save data
                    var response = await _httpClient.PostAsJsonAsync("State", state);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to create the State.");
                        return View(state);
                    }
                }
                else
                {
                    //update Data
                    if (id != state.Id)
                    {
                        return BadRequest();
                    }
                    if (ModelState.IsValid)
                    {
                        var response = await _httpClient.PutAsJsonAsync($"State/{id}", state);

                        if (response.IsSuccessStatusCode)
                        {

                            return RedirectToAction("Index");

                        }
                        else
                        {
                            ModelState.AddModelError("", "Failed to update the State.");
                            return View(state);
                        }
                    }
                    return View(state);
                }

            }

            return View(new State());
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"State/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
