//-----------------------------------------------------------------
//    <copyright file="Astronaut.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>10:30</time>
//    <version>1.0</version>
//    <author>Rodrigo Moura</author>
//-----------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace SpaceSystemv2.Domain
{
    /// <summary>
    /// Represents an Astronaut in the space system.
    /// </summary>
    public class Astronaut
    {
        #region Properties

        /// <summary>
        /// Unique identifier for the astronaut.
        /// </summary>
        [Key]
        public Guid ID_Astronaut { get; set; }

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

        #endregion

        #region Foreign Keys

        /// <summary>
        /// Identifier for the role of the astronaut.
        /// </summary>
        public Guid ID_AstronautRole { get; set; }

        /// <summary>
        /// Identifier for the associated space station.
        /// </summary>
        public Guid ID_SpaceStation { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Role assigned to the astronaut.
        /// </summary>
        public AstronautRole AstronautRole { get; set; }

        /// <summary>
        /// Space station where the astronaut is assigned.
        /// </summary>
        public SpaceStation SpaceStation { get; set; }

        #endregion
    }
}
