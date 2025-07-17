using AutoMapper;
using KejaHUnt_PropertiesAPI.Models.Domain;
using KejaHUnt_PropertiesAPI.Models.Dto;
using KejaHUnt_PropertiesAPI.Repositories.Implementation;
using KejaHUnt_PropertiesAPI.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace KejaHUnt_PropertiesAPI.Controllers
{
    [Route("api/property")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly ILogger<PropertyController> _logger;

        public PropertyController(IPropertyRepository propertyRepository, IMapper mapper, IImageRepository imageRepository, IUnitRepository unitRepository, ILogger<PropertyController> logger)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
            _imageRepository = imageRepository;
            _unitRepository = unitRepository;
            _logger = logger;
        }

        // POST: {apibaseurl}/api/property
        [HttpPost]
        public async Task<IActionResult> CreateProperty([FromForm] CreatePropertyRequestDto request)
        {
            _logger.LogInformation($"Creation of property {request.Name} started");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Upload image and get DocumentId
            Guid documentId = await _imageRepository.Upload(request.ImageFile);

            // Map base property (excluding GeneralFeatures)
            var property = _mapper.Map<Property>(request);
            property.DocumentId = documentId;
            property.Units = new List<Unit>();

            // Use feature IDs from request to load full GeneralFeatures in the repo
            await _propertyRepository.CreatePropertyAsync(property, request.GeneralFeatures, request.IndoorFeatures, request.OutdoorFeatures);

            return Ok(_mapper.Map<PropertyDto>(property));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var properties = await _propertyRepository.GetAllAsync();

            return Ok(_mapper.Map<List<PropertyDto>>(properties));
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetPropertyByIdAsync([FromRoute] long id)
        {
            var property = await _propertyRepository.GetPropertyByIdAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PropertyDto>(property));
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdatePropertyById([FromRoute] long id, [FromForm] UpdatePropertyRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Save property updates
            var updatedProperty = await _propertyRepository.UpdateAsync(id, request);

            return Ok(_mapper.Map<PropertyDto>(updatedProperty));
        }



        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteDiaryEntry([FromRoute] long id)
        {
            var deletedProperty = await _propertyRepository.DeleteAync(id);

            if (deletedProperty == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PropertyDto>(deletedProperty));

        }



    }
}
