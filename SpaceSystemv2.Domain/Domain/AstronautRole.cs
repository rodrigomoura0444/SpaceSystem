//-----------------------------------------------------------------
//    <copyright file="AstronautRole.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>10:40</time>
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
    /// Represents a role assigned to an astronaut.
    /// </summary>
    public class AstronautRole
    {
        #region Properties

        /// <summary>
        /// Unique identifier for the astronaut role.
        /// </summary>
        [Key]
        public Guid ID_AstronautRole { get; set; }

        /// <summary>
        /// Name of the astronaut role.
        /// </summary>
        [MaxLength(255)]
        public string AstronautRole_Name { get; set; }

        #endregion
    }
}
