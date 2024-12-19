//-----------------------------------------------------------------
//    <copyright file="Deploy.cs" company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>19-12-2024</date>
//    <time>10:50</time>
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
    /// Represents a deployment in the space system.
    /// </summary>
    public class Deploy
    {
        #region Properties

        /// <summary>
        /// Unique identifier for the deployment.
        /// </summary>
        [Key]
        public Guid ID_Deploy { get; set; }

        #endregion

        #region Foreign Keys

        /// <summary>
        /// Identifier for the associated rocket.
        /// </summary>
        public Guid ID_Rocket { get; set; }

        /// <summary>
        /// Identifier for the associated mission.
        /// </summary>
        public Guid ID_Mission { get; set; }

        /// <summary>
        /// Identifier for the associated astronaut.
        /// </summary>
        public Guid ID_Astronaut { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Rocket used in the deployment.
        /// </summary>
        public Rocket Rocket { get; set; }

        /// <summary>
        /// Mission associated with the deployment.
        /// </summary>
        public Mission Mission { get; set; }

        /// <summary>
        /// Astronaut involved in the deployment.
        /// </summary>
        public Astronaut Astronaut { get; set; }

        #endregion
    }
}
