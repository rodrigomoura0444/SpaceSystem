//-----------------------------------------------------------------
//    <copyright file="Rocket.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>11:20</time>
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
    /// Represents a rocket in the space system.
    /// </summary>
    public class Rocket
    {
        #region Properties

        /// <summary>
        /// Unique identifier for the rocket.
        /// </summary>
        [Key]
        public Guid ID_Rocket { get; set; }

        /// <summary>
        /// Name of the rocket.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Rocket_Name { get; set; }

        /// <summary>
        /// Weight of the rocket.
        /// </summary>
        public string Weight { get; set; }

        #endregion
    }
}
