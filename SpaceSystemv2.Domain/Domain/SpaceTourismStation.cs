//-----------------------------------------------------------------
//    <copyright file="SpaceTourismStation.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>11:40</time>
//    <version>1.0</version>
//    <author>Rodrigo Moura</author>
//-----------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace SpaceSystemv2.Domain
{
    /// <summary>
    /// Represents a space tourism station in the space system.
    /// </summary>
    public class SpaceTourismStation
    {
        #region Properties

        /// <summary>
        /// Unique identifier for the space tourism station.
        /// </summary>
        [Key]
        public Guid ID_SpaceTourismStation { get; set; }

        /// <summary>
        /// Name of the space tourism station.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string SpaceTourismStation_Name { get; set; }

        /// <summary>
        /// Tourist capacity of the station.
        /// </summary>
        public string TouristCapacity { get; set; }

        /// <summary>
        /// Number of tourists currently present at the station.
        /// </summary>
        public string TouristsPresent { get; set; }

        #endregion
    }
}
