//-----------------------------------------------------------------
//    <copyright file="UpdateAstronautDto.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>12:40</time>
//    <version>1.0</version>
//    <author>Rodrigo Moura</author>
//-----------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace SpaceSystemv2.API.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for updating an astronaut.
    /// </summary>
    public class UpdateAstronautDto
    {
        #region Properties

        /// <summary>
        /// Name of the astronaut.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Astronaut_Name { get; set; }

        /// <summary>
        /// Rank of the astronaut.
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Indicates if the astronaut is ready for launch.
        /// Default value is false.
        /// </summary>
        public bool IsReadyforLaunch { get; set; } = false;

        /// <summary>
        /// Identifier for the astronaut's role.
        /// </summary>
        public Guid ID_AstronautRole { get; set; }

        /// <summary>
        /// Identifier for the associated space station.
        /// </summary>
        public Guid ID_SpaceStation { get; set; }

        #endregion
    }
}
