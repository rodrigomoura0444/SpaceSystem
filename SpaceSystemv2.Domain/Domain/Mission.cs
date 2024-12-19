//-----------------------------------------------------------------
//    <copyright file="Mission.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>11:00</time>
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
    /// Represents a mission in the space system.
    /// </summary>
    public class Mission
    {
        #region Properties

        /// <summary>
        /// Unique identifier for the mission.
        /// </summary>
        [Key]
        public Guid ID_Mission { get; set; }

        /// <summary>
        /// Name of the mission.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Mission_Name { get; set; }

        /// <summary>
        /// Optional description of the mission.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Duration of the mission.
        /// </summary>
        public string MissionDuration { get; set; }

        /// <summary>
        /// Current status of the mission.
        /// </summary>
        public string MissionStatus { get; set; }

        /// <summary>
        /// Scheduled date of the mission.
        /// </summary>
        public string MissionDate { get; set; }

        #endregion

        #region Foreign Keys

        /// <summary>
        /// Identifier for the type of mission.
        /// </summary>
        public Guid ID_MissionType { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Type of mission associated with this mission.
        /// </summary>
        public MissionType MissionType { get; set; }

        #endregion
    }
}
