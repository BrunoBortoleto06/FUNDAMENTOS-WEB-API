using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {

        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMailService _mailService;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;


        //container de injeção de dependencia
        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, 
            IMailService mailService,
            ICityInfoRepository cityInfoRepository,
            IMapper mapper
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDTO>>> GetPointsOfInterest (int cityId)
        {

            if(!await _cityInfoRepository.CityExistsAsync(cityId))
            {
                _logger.LogInformation(
                    $"City with id {cityId} wasn't found when accessing points of interest.");
                return NotFound();
            }

            var pointsOfInterest = await _cityInfoRepository.GetPointsOfInterestForCityAsync(cityId);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDTO>>(pointsOfInterest));
        }


        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]

        public async Task<IActionResult> GetPointOfInterest(int cityId, int pointofinterestid)
        {

            if (!await _cityInfoRepository.CityExistsAsync(cityId)) return NotFound();

            var pointOfInterest = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointofinterestid);

            if (pointOfInterest == null) return NotFound();

            return Ok(_mapper.Map<PointOfInterestDTO>(pointOfInterest));

        }

        //[HttpPost]
        //public ActionResult<PointOfInterestDTO> CreatePointOfInterest(int cityId, PointOfInterestForCreationDTO pointOfInterest)
        //{

        //    CityDTO? city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

        //    if (city == null) return NotFound();

        //    int maxPointOfInterest = _citiesDataStore.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

        //    PointOfInterestDTO finalPointOfInterest = new PointOfInterestDTO
        //    {
        //        Id = ++maxPointOfInterest,
        //        Name = pointOfInterest.Name,
        //        Description = pointOfInterest.Description
        //    };

        //    city.PointsOfInterest.Add(finalPointOfInterest);

        //    return CreatedAtRoute("GetPointOfInterest", 
        //        new
        //        {
        //            cityId = cityId,
        //            pointOfInterestId = finalPointOfInterest.Id
        //        },
        //        finalPointOfInterest);
        //}


        //[HttpPut("{pointOfInterestId}")]
        //public ActionResult<PointOfInterestDTO> UpdatePointOfInterest (int cityId, int pointOfInterestId, PointOfInterestForUpdateDTO pointOfInterest)
        //{
        //    CityDTO? city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

        //    if (city == null) return NotFound();

        //    PointOfInterestDTO? pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);

        //    if (pointOfInterestFromStore == null) return NotFound();

        //    pointOfInterestFromStore.Name = pointOfInterest.Name;
        //    pointOfInterestFromStore.Description = pointOfInterest.Description;

        //    return NoContent();

        //}

        //[HttpPatch("{pointOfInterestId}")]
        //public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId, JsonPatchDocument<PointOfInterestForUpdateDTO> patchDocument)
        //{
        //    CityDTO? city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

        //    if (city == null) return NotFound();

        //    PointOfInterestDTO? pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);

        //    if (pointOfInterestFromStore == null) return NotFound();

        //    PointOfInterestForUpdateDTO pointOfInterestToPatch =
        //        new PointOfInterestForUpdateDTO
        //        {
        //            Name = pointOfInterestFromStore.Name,
        //            Description = pointOfInterestFromStore.Description
        //        };

        //    patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

        //    if (!ModelState.IsValid) return BadRequest();


        //    if (!TryValidateModel(pointOfInterestToPatch)) return BadRequest(ModelState);

        //    pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
        //    pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

        //    return NoContent();
        //}

        //[HttpDelete("{pointOfInterestId}")]
        //public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
        //{
        //    CityDTO? city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

        //    if (city == null) return NotFound();

        //    PointOfInterestDTO? pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);

        //    if (pointOfInterestFromStore == null) return NotFound();

        //    city.PointsOfInterest.Remove(pointOfInterestFromStore);

        //    _mailService.Send("Point of inrest deleted.", $"Point of interest {pointOfInterestFromStore.Name} with id {pointOfInterestFromStore.Id} was deleted.");

        //    return NoContent();
        //}

    }
}
