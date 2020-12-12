﻿// <copyright file="ChatServerListener.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.ChatServer
{
    using System;
    using System.ComponentModel;
    using System.IO.Pipelines;
    using Microsoft.Extensions.Logging;
    using MUnique.OpenMU.Network;
    using MUnique.OpenMU.Network.PlugIns;
    using MUnique.OpenMU.PlugIns;

    /// <summary>
    /// A listener which listens to the specified endpoint and provides the initialized <see cref="IConnection"/> by the event <see cref="ClientAccepted"/>.
    /// </summary>
    public class ChatServerListener
    {
        private readonly ChatServerEndpoint endpoint;
        private readonly PlugInManager plugInManager;
        private readonly ILoggerFactory loggerFactory;
        private Listener? chatClientListener;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatServerListener" /> class.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="plugInManager">The plug in manager.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public ChatServerListener(ChatServerEndpoint endpoint, PlugInManager plugInManager, ILoggerFactory loggerFactory)
        {
            this.endpoint = endpoint;
            this.plugInManager = plugInManager;
            this.loggerFactory = loggerFactory;
        }

        /// <summary>
        /// Occurs when a new client was accepted.
        /// </summary>
        public event EventHandler<ClientAcceptEventArgs>? ClientAccepted;

        /// <summary>
        /// Occurs when a client has been accepted by the tcp listener, but before a <see cref="Connection"/> is created.
        /// </summary>
        public event EventHandler<CancelEventArgs>? ClientAccepting;

        /// <summary>
        /// Starts the tcp listener of this instance.
        /// </summary>
        public void Start()
        {
            this.chatClientListener = new Listener(this.endpoint.NetworkPort, this.CreateDecryptor, writer => null, this.loggerFactory);
            this.chatClientListener.ClientAccepted += (sender, args) => this.ClientAccepted?.Invoke(sender, args);
            this.chatClientListener.ClientAccepting += (sender, args) => this.ClientAccepting?.Invoke(sender, args);
            this.chatClientListener.Start();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            this.chatClientListener?.Stop();
        }

        private IPipelinedDecryptor? CreateDecryptor(PipeReader pipeReader)
        {
            var encryptionFactoryPlugIn = this.plugInManager.GetStrategy<ClientVersion, INetworkEncryptionFactoryPlugIn>(this.endpoint.ClientVersion)
                                          ?? this.plugInManager.GetStrategy<ClientVersion, INetworkEncryptionFactoryPlugIn>(default);
            return encryptionFactoryPlugIn?.CreateDecryptor(pipeReader, DataDirection.ClientToServer);
        }
    }
}
