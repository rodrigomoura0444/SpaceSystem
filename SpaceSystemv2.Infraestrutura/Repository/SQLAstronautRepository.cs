//-----------------------------------------------------------------
//    <copyright file="SQLAstronautRepository.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>12:00</time>
//    <version>1.0</version>
//    <author>Rodrigo Moura</author>
//-----------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using SpaceSystemv2.Domain;
using SpaceSystemv2.Infraestrutura.Data;
using SpaceSystemv2.Infraestrutura.Repository.Interfaces;

namespace SpaceSystemv2.Infraestrutura.Repository
{
    /// <summary>
    /// SQL implementation of the generic repository for managing Astronaut entities.
    /// </summary>
    public class SQLAstronautRepository : IGenericRepository<Astronaut, Guid>
    {
        #region Fields

        /// <summary>
        /// The database context used by the repository.
        /// </summary>
        private readonly ApplicationDbContext dbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLAstronautRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context to be used by the repository.</param>
        public SQLAstronautRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        #region Create

        /// <summary>
        /// Asynchronously creates a new astronaut in the database.
        /// </summary>
        /// <param name="astronaut">The astronaut entity to be created.</param>
        /// <returns>The created astronaut entity.</returns>
        public async Task<Astronaut> CreateAsync(Astronaut astronaut)
        {
            await dbContext.Astronauts.AddAsync(astronaut);
            await dbContext.SaveChangesAsync();
            return astronaut;
        }

        #endregion

        #region Delete

        /// <summary>
        /// Asynchronously deletes an astronaut by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the astronaut to delete.</param>
        /// <returns>The deleted astronaut entity, or null if not found.</returns>
        public async Task<Astronaut?> DeleteAsync(Guid id)
        {
            var astronaut = await dbContext.Astronauts.FirstOrDefaultAsync(r => r.ID_Astronaut == id);
            if (astronaut == null) return null;

            dbContext.Astronauts.Remove(astronaut);
            await dbContext.SaveChangesAsync();

            return astronaut;
        }

        #endregion

        #region Get All

        /// <summary>
        /// Asynchronously retrieves all astronauts from the database.
        /// </summary>
        /// <returns>A list of astronaut entities.</returns>
        public async Task<List<Astronaut>> GetAllAsync()
        {
            return await dbContext.Astronauts.ToListAsync();
        }

        #endregion

        #region Get By ID

        /// <summary>
        /// Asynchronously retrieves an astronaut by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the astronaut.</param>
        /// <returns>The astronaut entity, or null if not found.</returns>
        public async Task<Astronaut?> GetbyIDAsync(Guid id)
        {
            return await dbContext.Astronauts
                .Include("AstronautRoles")
                .Include("SpaceStations")
                .FirstOrDefaultAsync(r => r.ID_Astronaut == id);
        }

        #endregion

        #region Update

        /// <summary>
        /// Asynchronously updates an existing astronaut entity.
        /// </summary>
        /// <param name="id">The identifier of the astronaut to update.</param>
        /// <param name="updatedEntity">The updated astronaut entity.</param>
        /// <returns>The updated astronaut entity, or null if not found.</returns>
        public async Task<Astronaut?> UpdateAsync(Guid id, Astronaut updatedEntity)
        {
            Astronaut existing = await dbContext.Astronauts.FirstOrDefaultAsync(r => r.ID_Astronaut == id);
            if (existing == null) return null;

            existing.Astronaut_Name = updatedEntity.Astronaut_Name;
            existing.Rank = updatedEntity.Rank;
            existing.IsReadyforLaunch = updatedEntity.IsReadyforLaunch;
            existing.ID_AstronautRole = updatedEntity.ID_AstronautRole;
            existing.ID_SpaceStation = updatedEntity.ID_SpaceStation;

            await dbContext.SaveChangesAsync();

            return existing;
        }

        #endregion
    }
}
