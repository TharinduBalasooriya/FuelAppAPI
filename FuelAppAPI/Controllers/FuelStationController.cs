using FuelAppAPI.models;
using FuelAppAPI.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuelAppAPI.Controllers
{
    [Route("api/fuelstation")]
    [ApiController]
    public class FuelStationController : Controller
    {
        private readonly FuelStationService _fuelStationService;

        public FuelStationController(FuelStationService fuelStationService) {
            _fuelStationService = fuelStationService;
        }

        [HttpGet]
        public async Task<List<FuelStation>> Get()
        {
            return await _fuelStationService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<FuelStation>> Get(string id)
        {
            var fuelStation = await _fuelStationService.GetAsync(id);

            if (fuelStation is null)
            {
                return NotFound();
            }

            return fuelStation;
        }

        [HttpPost]
        public async Task<ActionResult> CreateFuelStation([FromBody] FuelStation fuelStation) {

            await _fuelStationService.createAsync(fuelStation);

            return CreatedAtAction(nameof(Get), new { id = fuelStation.Id }, fuelStation);

        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, FuelStation updatedFuelStation)
        {
            var fuelStation = await _fuelStationService.GetAsync(id);

            if (fuelStation is null)
            {
                return NotFound();
            }

            updatedFuelStation.Id = fuelStation.Id;

            await _fuelStationService.UpdateAsync(id, updatedFuelStation);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var fuel = await _fuelStationService.GetAsync(id);

            if (fuel is null)
            {
                return NotFound();
            }

            await _fuelStationService.RemoveAsync(id);

            return NoContent();
        }


    }
}
