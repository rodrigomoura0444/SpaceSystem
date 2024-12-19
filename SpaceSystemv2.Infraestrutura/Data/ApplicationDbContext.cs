//-----------------------------------------------------------------
//    <copyright file="ApplicationDbContext.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>11:50</time>
//    <version>1.0</version>
//    <author>Rodrigo Moura</author>
//-----------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using SpaceSystemv2.Domain;

namespace SpaceSystemv2.Infraestrutura.Data
{
    /// <summary>
    /// Represents the database context for the Space System application.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to configure the database context.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region DbSets

        /// <summary>
        /// Gets or sets the astronauts.
        /// </summary>
        public DbSet<Astronaut> Astronauts { get; set; }

        /// <summary>
        /// Gets or sets the astronaut roles.
        /// </summary>
        public DbSet<AstronautRole> AstronautRoles { get; set; }

        /// <summary>
        /// Gets or sets the deployments.
        /// </summary>
        public DbSet<Deploy> Deploys { get; set; }

        /// <summary>
        /// Gets or sets the missions.
        /// </summary>
        public DbSet<Mission> Missions { get; set; }

        /// <summary>
        /// Gets or sets the mission types.
        /// </summary>
        public DbSet<MissionType> MissionTypes { get; set; }

        /// <summary>
        /// Gets or sets the rockets.
        /// </summary>
        public DbSet<Rocket> Rocket { get; set; }

        /// <summary>
        /// Gets or sets the space stations.
        /// </summary>
        public DbSet<SpaceStation> SpaceStations { get; set; }

        /// <summary>
        /// Gets or sets the space tourism stations.
        /// </summary>
        public DbSet<SpaceTourismStation> SpaceTourismStations { get; set; }

        #endregion

        #region Model Configuration

        /// <summary>
        /// Configures the model relationships and properties.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the database schema.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Astronaut relationships
            modelBuilder.Entity<Astronaut>()
                .HasOne(a => a.AstronautRole)
                .WithMany()
                .HasForeignKey(a => a.ID_AstronautRole);

            modelBuilder.Entity<Astronaut>()
                .HasOne(a => a.SpaceStation)
                .WithMany()
                .HasForeignKey(a => a.ID_SpaceStation);

            // Configure Deploy relationships
            modelBuilder.Entity<Deploy>()
                .HasOne(d => d.Rocket)
                .WithMany()
                .HasForeignKey(d => d.ID_Rocket);

            modelBuilder.Entity<Deploy>()
                .HasOne(d => d.Mission)
                .WithMany()
                .HasForeignKey(d => d.ID_Mission);

            modelBuilder.Entity<Deploy>()
                .HasOne(d => d.Astronaut)
                .WithMany()
                .HasForeignKey(d => d.ID_Astronaut);

            // Configure Mission relationships
            modelBuilder.Entity<Mission>()
                .HasOne(m => m.MissionType)
                .WithMany()
                .HasForeignKey(m => m.ID_MissionType);

            // Seed initial data for AstronautRoles
            modelBuilder.Entity<AstronautRole>().HasData(
                new AstronautRole { ID_AstronautRole = Guid.NewGuid(), AstronautRole_Name = "Commander" },
                new AstronautRole { ID_AstronautRole = Guid.NewGuid(), AstronautRole_Name = "Engineer" },
                new AstronautRole { ID_AstronautRole = Guid.NewGuid(), AstronautRole_Name = "MissionSpecialist" },
                new AstronautRole { ID_AstronautRole = Guid.NewGuid(), AstronautRole_Name = "Pilot" }
            );

            // Seed initial data for SpaceStations
            modelBuilder.Entity<SpaceStation>().HasData(
                new SpaceStation { ID_SpaceStation = Guid.NewGuid(), SpaceStation_Name = "ISS", CrewCapacity = "255", InaugurationDate = "11/12/2024" }
            );
        }

        #endregion
    }
}
