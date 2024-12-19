//-----------------------------------------------------------------
//    <copyright file="SpaceStation.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>11:30</time>
//    <version>1.0</version>
//    <author>Rodrigo Moura</author>
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSystemv2.Domain
{
    /// <summary>
    /// Represents a space station in the space system.
    /// </summary>
    public class SpaceStation
    {
        #region Properties

        /// <summary>
        /// Unique identifier for the space station.
        /// </summary>
        [Key]
        public Guid ID_SpaceStation { get; set; }

        /// <summary>
        /// Name of the space station.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string SpaceStation_Name { get; set; }

        /// <summary>
        /// Crew capacity of the space station.
        /// </summary>
        public string CrewCapacity { get; set; }

        /// <summary>
        /// Inauguration date of the space station.
        /// </summary>
        public string InaugurationDate { get; set; }

        #endregion

        #region Foreign Keys

        // Placeholder for future foreign key properties

        #endregion
    }
}
