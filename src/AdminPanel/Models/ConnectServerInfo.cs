﻿// <copyright file="ConnectServerInfo.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.AdminPanel.Models
{
    using Mapster;
    using MUnique.OpenMU.Interfaces;
    using Newtonsoft.Json;

    /// <summary>
    /// A wrapper class for the connect server information.
    /// </summary>
    public class ConnectServerInfo : ServerInfo
    {
        private readonly IConnectServer server;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectServerInfo"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        public ConnectServerInfo(IConnectServer server)
            : base(server)
        {
            this.server = server;
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        [JsonProperty("settings")]
        public ConnectServerDefinitionDto Settings => this.server.Settings?.Adapt<ConnectServerDefinitionDto>();
    }
}