using System.Threading.Tasks;
using KejaHUnt_PropertiesAPI.Data;
using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;
using KejaHUnt_PropertiesAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KejaHUnt_PropertiesAPI.Controllers
{
    [Route("api/feature")]
    [ApiController]
    public class GeneralFeaturesController : ControllerBase
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public GeneralFeaturesController(IFeatureRepository featureRepository,ApplicationDbContext applicationDbContext)
        {
            _featureRepository = featureRepository;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        [Route("policy")]
        public async Task<IActionResult> CreatePolicyDescription([FromBody] CreatePolicyDto request)
        {
            return Ok( await _featureRepository.CreatePolicyDescriptionAsync(request));
        }

        [HttpGet]
        [Route("general")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _featureRepository.GetAllGeneralFeaturesAsync());
        }

        [HttpGet]
        [Route("indoor")]
        public async Task<IActionResult> GetAllIndoor()
        {
            return Ok(await _featureRepository.GetAllIndoorFeaturesAsync());
        }

        [HttpGet]
        [Route("outdoor")]
        public async Task<IActionResult> GetAllOutdoor()
        {
            return Ok(await _featureRepository.GetAllOutdoorFeaturesAsync());
        }

        [HttpGet]
        [Route("amenities")]
        public async Task<IActionResult> GetAllPolicy()
        {
            return Ok(await _featureRepository.GetAllPoliciessAsync());
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetPolicyById(long id)
        {
           return Ok(await _featureRepository.GetPolicyByIdAsync(id));
        }
    }
}
