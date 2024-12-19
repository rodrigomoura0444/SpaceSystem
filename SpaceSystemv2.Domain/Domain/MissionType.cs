//-----------------------------------------------------------------
//    <copyright file="MissionType.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>11:10</time>
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
    /// Represents a type of mission in the space system.
    /// </summary>
    public class MissionType
    {
        #region Properties

        /// <summary>
        /// Unique identifier for the mission type.
        /// </summary>
        [Key]
        public Guid ID_MissionType { get; set; }

        /// <summary>
        /// Name of the mission type.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string MissionType_Name { get; set; }

        #endregion
    }
}
