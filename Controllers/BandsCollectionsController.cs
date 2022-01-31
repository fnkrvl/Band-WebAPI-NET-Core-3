using AutoMapper;
using BandAPI.Helpers;
using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Controllers
{
    [ApiController]                                           // api/bandscollection/
    [Route("api/bandscollections")] // En Postman no va la última barra '/' because tira 404 Not Found
    public class BandsCollectionsController : ControllerBase
    {

        private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IMapper _mapper;

        public BandsCollectionsController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        {
            _bandAlbumRepository = bandAlbumRepository ??
                throw new ArgumentNullException(nameof(bandAlbumRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{ids}", Name = "GetBandCollection")]
        public IActionResult GetBandCollection([FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
                return BadRequest();

            var bandEntities = _bandAlbumRepository.GetBands(ids);

            if (ids.Count() != bandEntities.Count())
                return NotFound();

            var bandsToReturn = _mapper.Map<IEnumerable<BandDto>>(bandEntities);

            return Ok(bandsToReturn);
        }


        [HttpPost]
        public ActionResult<IEnumerable<BandDto>> CreateBandCollection([FromBody] IEnumerable<BandForCreatingDto> bandCollection)
        {
            var bandEntities = _mapper.Map<IEnumerable<Entities.Band>>(bandCollection);

            foreach (var band in bandEntities)
            {
                _bandAlbumRepository.AddBand(band);
            }

            _bandAlbumRepository.Save();
            var bandCollectionToReturn = _mapper.Map<IEnumerable<BandDto>>(bandEntities);
            var IdString = string.Join(",", bandCollectionToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetBandCollection", new { ids = IdString}, bandCollectionToReturn);
        }



    }
}
