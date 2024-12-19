//-----------------------------------------------------------------
//    <copyright file="CreateAstronautRequest.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>12:30</time>
//    <version>1.0</version>
//    <author>Rodrigo Moura</author>
//-----------------------------------------------------------------

using SpaceSystemv2.Domain;
using System.ComponentModel.DataAnnotations;

namespace SpaceSystemv2.API.DTO
{
    /// <summary>
    /// Request object for creating a new astronaut.
    /// </summary>
    public class CreateAstronautRequest
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
