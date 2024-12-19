//-----------------------------------------------------------------
//    <copyright file="AstronautController.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>12:15</time>
//    <version>1.0</version>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpaceSystemv2.API.DTO;
using SpaceSystemv2.Domain;
using SpaceSystemv2.Infraestrutura.Repository.Interfaces;

namespace SpaceSystemv2.API.Controllers
{
    /// <summary>
    /// Controller for managing astronauts in the space system API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AstronautController : Controller
    {
        #region Fields

        /// <summary>
        /// Repository for handling astronaut data operations.
        /// </summary>
        private readonly IGenericRepository<Astronaut, Guid> astronautRepository;

        /// <summary>
        /// Mapper for converting between domain models and DTOs.
        /// </summary>
        private readonly IMapper mapper;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AstronautController"/> class.
        /// </summary>
        /// <param name="astronautRepository">The astronaut repository.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public AstronautController(IGenericRepository<Astronaut, Guid> astronautRepository, IMapper mapper)
        {
            this.astronautRepository = astronautRepository;
            this.mapper = mapper;
        }

        #endregion

        #region POST

        /// <summary>
        /// Creates a new astronaut.
        /// </summary>
        /// <param name="astronautRequest">The request containing astronaut data.</param>
        /// <returns>The created astronaut data.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAstronautRequest astronautRequest)
        {
            if (ModelState.IsValid)
            {
                Astronaut astronautDomain = mapper.Map<CreateAstronautRequest, Astronaut>(astronautRequest);
                await astronautRepository.CreateAsync(astronautDomain);
                AstronautDto astronautDto = mapper.Map<Astronaut, AstronautDto>(astronautDomain);
                return CreatedAtAction(nameof(GetbyId), new { id = astronautDto.ID_Astronaut }, astronautDto);
            }
            return BadRequest();
        }

        #endregion

        #region GET

        /// <summary>
        /// Retrieves all astronauts.
        /// </summary>
        /// <returns>A list of all astronauts.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Astronaut> astronautsDomain = await astronautRepository.GetAllAsync();
            return Ok(astronautsDomain);
        }

        #endregion

        #region GET by ID

        /// <summary>
        /// Retrieves an astronaut by ID.
        /// </summary>
        /// <param name="id">The astronaut's identifier.</param>
        /// <returns>The astronaut data, or a 404 if not found.</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetbyId([FromRoute] Guid id)
        {
            Astronaut? astronaut = await astronautRepository.GetbyIDAsync(id);
            if (astronaut == null)
            {
                return NotFound();
            }
            return Ok(astronaut);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Deletes an astronaut by ID.
        /// </summary>
        /// <param name="id">The astronaut's identifier.</param>
        /// <returns>The deleted astronaut data, or a 404 if not found.</returns>
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Astronaut? astronaut = await astronautRepository.DeleteAsync(id);
            if (astronaut == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Astronaut, AstronautDto>(astronaut));
        }

        #endregion

        #region UPDATE

        /// <summary>
        /// Updates an astronaut by ID.
        /// </summary>
        /// <param name="id">The astronaut's identifier.</param>
        /// <param name="updateAstronaut">The updated astronaut data.</param>
        /// <returns>The updated astronaut data, or a 404 if not found.</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAstronautDto updateAstronaut)
        {
            Astronaut astronautDomain = mapper.Map<UpdateAstronautDto, Astronaut>(updateAstronaut);
            await astronautRepository.UpdateAsync(id, astronautDomain);
            return Ok(mapper.Map<Astronaut, AstronautDto>(astronautDomain));
        }

        #endregion
    }
}
