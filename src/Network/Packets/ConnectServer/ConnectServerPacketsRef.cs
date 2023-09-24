﻿// <copyright file="ConnectServerPacketsRef.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

//------------------------------------------------------------------------------
// <auto-generated>
//     This source code was auto-generated by an XSL transformation.
//     Do not change this file. Instead, change the XML data which contains
//     the packet definitions and re-run the transformation (rebuild this project).
// </auto-generated>
//------------------------------------------------------------------------------

namespace MUnique.OpenMU.Network.Packets.ConnectServer;

using System;
using static System.Buffers.Binary.BinaryPrimitives;

/// <summary>
/// Is sent by the client when: This packet is sent by the client after the user clicked on an entry of the server list.
/// Causes reaction on server side: The server will send a ConnectionInfo back to the client.
/// </summary>
public readonly ref struct ConnectionInfoRequest075Ref
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionInfoRequest075Ref"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public ConnectionInfoRequest075Ref(Span<byte> data)
        : this(data, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionInfoRequest075Ref"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    /// <param name="initialize">If set to <c>true</c>, the header data is automatically initialized and written to the underlying span.</param>
    private ConnectionInfoRequest075Ref(Span<byte> data, bool initialize)
    {
        this._data = data;
        if (initialize)
        {
            var header = this.Header;
            header.Type = HeaderType;
            header.Code = Code;
            header.Length = (byte)Math.Min(data.Length, Length);
            header.SubCode = SubCode;
        }
    }

    /// <summary>
    /// Gets the header type of this data packet.
    /// </summary>
    public static byte HeaderType => 0xC1;

    /// <summary>
    /// Gets the operation code of this data packet.
    /// </summary>
    public static byte Code => 0xF4;

    /// <summary>
    /// Gets the operation sub-code of this data packet.
    /// The <see cref="Code" /> is used as a grouping key.
    /// </summary>
    public static byte SubCode => 0x03;

    /// <summary>
    /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
    /// </summary>
    public static int Length => 5;

    /// <summary>
    /// Gets the header of this packet.
    /// </summary>
    public C1HeaderWithSubCodeRef Header => new (this._data);

    /// <summary>
    /// Gets or sets the server id.
    /// </summary>
    public byte ServerId
    {
        get => this._data[4];
        set => this._data[4] = value;
    }

    /// <summary>
    /// Performs an implicit conversion from a Span of bytes to a <see cref="ConnectionInfoRequest075"/>.
    /// </summary>
    /// <param name="packet">The packet as span.</param>
    /// <returns>The packet as struct.</returns>
    public static implicit operator ConnectionInfoRequest075Ref(Span<byte> packet) => new (packet, false);

    /// <summary>
    /// Performs an implicit conversion from <see cref="ConnectionInfoRequest075"/> to a Span of bytes.
    /// </summary>
    /// <param name="packet">The packet as struct.</param>
    /// <returns>The packet as byte span.</returns>
    public static implicit operator Span<byte>(ConnectionInfoRequest075Ref packet) => packet._data; 
}


/// <summary>
/// Is sent by the client when: This packet is sent by the client after the user clicked on an entry of the server list.
/// Causes reaction on server side: The server will send a ConnectionInfo back to the client.
/// </summary>
public readonly ref struct ConnectionInfoRequestRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionInfoRequestRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public ConnectionInfoRequestRef(Span<byte> data)
        : this(data, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionInfoRequestRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    /// <param name="initialize">If set to <c>true</c>, the header data is automatically initialized and written to the underlying span.</param>
    private ConnectionInfoRequestRef(Span<byte> data, bool initialize)
    {
        this._data = data;
        if (initialize)
        {
            var header = this.Header;
            header.Type = HeaderType;
            header.Code = Code;
            header.Length = (byte)Math.Min(data.Length, Length);
            header.SubCode = SubCode;
        }
    }

    /// <summary>
    /// Gets the header type of this data packet.
    /// </summary>
    public static byte HeaderType => 0xC1;

    /// <summary>
    /// Gets the operation code of this data packet.
    /// </summary>
    public static byte Code => 0xF4;

    /// <summary>
    /// Gets the operation sub-code of this data packet.
    /// The <see cref="Code" /> is used as a grouping key.
    /// </summary>
    public static byte SubCode => 0x03;

    /// <summary>
    /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
    /// </summary>
    public static int Length => 6;

    /// <summary>
    /// Gets the header of this packet.
    /// </summary>
    public C1HeaderWithSubCodeRef Header => new (this._data);

    /// <summary>
    /// Gets or sets the server id.
    /// </summary>
    public ushort ServerId
    {
        get => ReadUInt16LittleEndian(this._data[4..]);
        set => WriteUInt16LittleEndian(this._data[4..], value);
    }

    /// <summary>
    /// Performs an implicit conversion from a Span of bytes to a <see cref="ConnectionInfoRequest"/>.
    /// </summary>
    /// <param name="packet">The packet as span.</param>
    /// <returns>The packet as struct.</returns>
    public static implicit operator ConnectionInfoRequestRef(Span<byte> packet) => new (packet, false);

    /// <summary>
    /// Performs an implicit conversion from <see cref="ConnectionInfoRequest"/> to a Span of bytes.
    /// </summary>
    /// <param name="packet">The packet as struct.</param>
    /// <returns>The packet as byte span.</returns>
    public static implicit operator Span<byte>(ConnectionInfoRequestRef packet) => packet._data; 
}


/// <summary>
/// Is sent by the server when: This packet is sent by the server after the client requested the connection information of a server. This happens after the user clicked on a server.
/// Causes reaction on client side: The client will try to connect to the server with the specified information.
/// </summary>
public readonly ref struct ConnectionInfoRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionInfoRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public ConnectionInfoRef(Span<byte> data)
        : this(data, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionInfoRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    /// <param name="initialize">If set to <c>true</c>, the header data is automatically initialized and written to the underlying span.</param>
    private ConnectionInfoRef(Span<byte> data, bool initialize)
    {
        this._data = data;
        if (initialize)
        {
            var header = this.Header;
            header.Type = HeaderType;
            header.Code = Code;
            header.Length = (byte)Math.Min(data.Length, Length);
            header.SubCode = SubCode;
        }
    }

    /// <summary>
    /// Gets the header type of this data packet.
    /// </summary>
    public static byte HeaderType => 0xC1;

    /// <summary>
    /// Gets the operation code of this data packet.
    /// </summary>
    public static byte Code => 0xF4;

    /// <summary>
    /// Gets the operation sub-code of this data packet.
    /// The <see cref="Code" /> is used as a grouping key.
    /// </summary>
    public static byte SubCode => 0x03;

    /// <summary>
    /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
    /// </summary>
    public static int Length => 22;

    /// <summary>
    /// Gets the header of this packet.
    /// </summary>
    public C1HeaderWithSubCodeRef Header => new (this._data);

    /// <summary>
    /// Gets or sets the ip address.
    /// </summary>
    public string IpAddress
    {
        get => this._data.ExtractString(4, 16, System.Text.Encoding.UTF8);
        set => this._data.Slice(4, 16).WriteString(value, System.Text.Encoding.UTF8);
    }

    /// <summary>
    /// Gets or sets the port.
    /// </summary>
    public ushort Port
    {
        get => ReadUInt16LittleEndian(this._data[20..]);
        set => WriteUInt16LittleEndian(this._data[20..], value);
    }

    /// <summary>
    /// Performs an implicit conversion from a Span of bytes to a <see cref="ConnectionInfo"/>.
    /// </summary>
    /// <param name="packet">The packet as span.</param>
    /// <returns>The packet as struct.</returns>
    public static implicit operator ConnectionInfoRef(Span<byte> packet) => new (packet, false);

    /// <summary>
    /// Performs an implicit conversion from <see cref="ConnectionInfo"/> to a Span of bytes.
    /// </summary>
    /// <param name="packet">The packet as struct.</param>
    /// <returns>The packet as byte span.</returns>
    public static implicit operator Span<byte>(ConnectionInfoRef packet) => packet._data; 
}


/// <summary>
/// Is sent by the client when: This packet is sent by the client after it connected and received the 'Hello' message.
/// Causes reaction on server side: The server will send a ServerListResponse back to the client.
/// </summary>
public readonly ref struct ServerListRequestRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServerListRequestRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public ServerListRequestRef(Span<byte> data)
        : this(data, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServerListRequestRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    /// <param name="initialize">If set to <c>true</c>, the header data is automatically initialized and written to the underlying span.</param>
    private ServerListRequestRef(Span<byte> data, bool initialize)
    {
        this._data = data;
        if (initialize)
        {
            var header = this.Header;
            header.Type = HeaderType;
            header.Code = Code;
            header.Length = (byte)Math.Min(data.Length, Length);
            header.SubCode = SubCode;
        }
    }

    /// <summary>
    /// Gets the header type of this data packet.
    /// </summary>
    public static byte HeaderType => 0xC1;

    /// <summary>
    /// Gets the operation code of this data packet.
    /// </summary>
    public static byte Code => 0xF4;

    /// <summary>
    /// Gets the operation sub-code of this data packet.
    /// The <see cref="Code" /> is used as a grouping key.
    /// </summary>
    public static byte SubCode => 0x06;

    /// <summary>
    /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
    /// </summary>
    public static int Length => 4;

    /// <summary>
    /// Gets the header of this packet.
    /// </summary>
    public C1HeaderWithSubCodeRef Header => new (this._data);

    /// <summary>
    /// Performs an implicit conversion from a Span of bytes to a <see cref="ServerListRequest"/>.
    /// </summary>
    /// <param name="packet">The packet as span.</param>
    /// <returns>The packet as struct.</returns>
    public static implicit operator ServerListRequestRef(Span<byte> packet) => new (packet, false);

    /// <summary>
    /// Performs an implicit conversion from <see cref="ServerListRequest"/> to a Span of bytes.
    /// </summary>
    /// <param name="packet">The packet as struct.</param>
    /// <returns>The packet as byte span.</returns>
    public static implicit operator Span<byte>(ServerListRequestRef packet) => packet._data; 
}


/// <summary>
/// Is sent by the server when: This packet is sent by the server after the client requested the current server list.
/// Causes reaction on client side: The client shows the available servers with their load information.
/// </summary>
public readonly ref struct ServerListResponseRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServerListResponseRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public ServerListResponseRef(Span<byte> data)
        : this(data, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServerListResponseRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    /// <param name="initialize">If set to <c>true</c>, the header data is automatically initialized and written to the underlying span.</param>
    private ServerListResponseRef(Span<byte> data, bool initialize)
    {
        this._data = data;
        if (initialize)
        {
            var header = this.Header;
            header.Type = HeaderType;
            header.Code = Code;
            header.Length = (ushort)data.Length;
            header.SubCode = SubCode;
        }
    }

    /// <summary>
    /// Gets the header type of this data packet.
    /// </summary>
    public static byte HeaderType => 0xC2;

    /// <summary>
    /// Gets the operation code of this data packet.
    /// </summary>
    public static byte Code => 0xF4;

    /// <summary>
    /// Gets the operation sub-code of this data packet.
    /// The <see cref="Code" /> is used as a grouping key.
    /// </summary>
    public static byte SubCode => 0x06;

    /// <summary>
    /// Gets the header of this packet.
    /// </summary>
    public C2HeaderWithSubCodeRef Header => new (this._data);

    /// <summary>
    /// Gets or sets the server count.
    /// </summary>
    public ushort ServerCount
    {
        get => ReadUInt16BigEndian(this._data[5..]);
        set => WriteUInt16BigEndian(this._data[5..], value);
    }

    /// <summary>
    /// Gets the <see cref="ServerLoadInfoRef"/> of the specified index.
    /// </summary>
        public ServerLoadInfoRef this[int index] => new (this._data[(7 + index * ServerLoadInfoRef.Length)..]);

    /// <summary>
    /// Performs an implicit conversion from a Span of bytes to a <see cref="ServerListResponse"/>.
    /// </summary>
    /// <param name="packet">The packet as span.</param>
    /// <returns>The packet as struct.</returns>
    public static implicit operator ServerListResponseRef(Span<byte> packet) => new (packet, false);

    /// <summary>
    /// Performs an implicit conversion from <see cref="ServerListResponse"/> to a Span of bytes.
    /// </summary>
    /// <param name="packet">The packet as struct.</param>
    /// <returns>The packet as byte span.</returns>
    public static implicit operator Span<byte>(ServerListResponseRef packet) => packet._data; 

    /// <summary>
    /// Calculates the size of the packet for the specified count of <see cref="ServerLoadInfoRef"/>.
    /// </summary>
    /// <param name="serversCount">The count of <see cref="ServerLoadInfoRef"/> from which the size will be calculated.</param>
        
    public static int GetRequiredSize(int serversCount) => serversCount * ServerLoadInfoRef.Length + 7;


/// <summary>
/// Contains the id and the load of a server..
/// </summary>
public readonly ref struct ServerLoadInfoRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServerLoadInfoRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public ServerLoadInfoRef(Span<byte> data)
    {
        this._data = data;
    }

    /// <summary>
    /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
    /// </summary>
    public static int Length => 4;

    /// <summary>
    /// Gets or sets the server id.
    /// </summary>
    public ushort ServerId
    {
        get => ReadUInt16LittleEndian(this._data);
        set => WriteUInt16LittleEndian(this._data, value);
    }

    /// <summary>
    /// Gets or sets the load percentage.
    /// </summary>
    public byte LoadPercentage
    {
        get => this._data[2];
        set => this._data[2] = value;
    }
}
}


/// <summary>
/// Is sent by the client when: This packet is sent by the client (below season 1) after it connected and received the 'Hello' message.
/// Causes reaction on server side: The server will send a ServerListResponseOld back to the client.
/// </summary>
public readonly ref struct ServerListRequestOldRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServerListRequestOldRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public ServerListRequestOldRef(Span<byte> data)
        : this(data, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServerListRequestOldRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    /// <param name="initialize">If set to <c>true</c>, the header data is automatically initialized and written to the underlying span.</param>
    private ServerListRequestOldRef(Span<byte> data, bool initialize)
    {
        this._data = data;
        if (initialize)
        {
            var header = this.Header;
            header.Type = HeaderType;
            header.Code = Code;
            header.Length = (byte)Math.Min(data.Length, Length);
            header.SubCode = SubCode;
        }
    }

    /// <summary>
    /// Gets the header type of this data packet.
    /// </summary>
    public static byte HeaderType => 0xC1;

    /// <summary>
    /// Gets the operation code of this data packet.
    /// </summary>
    public static byte Code => 0xF4;

    /// <summary>
    /// Gets the operation sub-code of this data packet.
    /// The <see cref="Code" /> is used as a grouping key.
    /// </summary>
    public static byte SubCode => 0x02;

    /// <summary>
    /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
    /// </summary>
    public static int Length => 4;

    /// <summary>
    /// Gets the header of this packet.
    /// </summary>
    public C1HeaderWithSubCodeRef Header => new (this._data);

    /// <summary>
    /// Performs an implicit conversion from a Span of bytes to a <see cref="ServerListRequestOld"/>.
    /// </summary>
    /// <param name="packet">The packet as span.</param>
    /// <returns>The packet as struct.</returns>
    public static implicit operator ServerListRequestOldRef(Span<byte> packet) => new (packet, false);

    /// <summary>
    /// Performs an implicit conversion from <see cref="ServerListRequestOld"/> to a Span of bytes.
    /// </summary>
    /// <param name="packet">The packet as struct.</param>
    /// <returns>The packet as byte span.</returns>
    public static implicit operator Span<byte>(ServerListRequestOldRef packet) => packet._data; 
}


/// <summary>
/// Is sent by the server when: This packet is sent by the server (below season 1) after the client requested the current server list.
/// Causes reaction on client side: The client shows the available servers with their load information.
/// </summary>
public readonly ref struct ServerListResponseOldRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServerListResponseOldRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public ServerListResponseOldRef(Span<byte> data)
        : this(data, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ServerListResponseOldRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    /// <param name="initialize">If set to <c>true</c>, the header data is automatically initialized and written to the underlying span.</param>
    private ServerListResponseOldRef(Span<byte> data, bool initialize)
    {
        this._data = data;
        if (initialize)
        {
            var header = this.Header;
            header.Type = HeaderType;
            header.Code = Code;
            header.Length = (ushort)data.Length;
            header.SubCode = SubCode;
        }
    }

    /// <summary>
    /// Gets the header type of this data packet.
    /// </summary>
    public static byte HeaderType => 0xC2;

    /// <summary>
    /// Gets the operation code of this data packet.
    /// </summary>
    public static byte Code => 0xF4;

    /// <summary>
    /// Gets the operation sub-code of this data packet.
    /// The <see cref="Code" /> is used as a grouping key.
    /// </summary>
    public static byte SubCode => 0x02;

    /// <summary>
    /// Gets the header of this packet.
    /// </summary>
    public C2HeaderWithSubCodeRef Header => new (this._data);

    /// <summary>
    /// Gets or sets the server count.
    /// </summary>
    public byte ServerCount
    {
        get => this._data[5];
        set => this._data[5] = value;
    }

    /// <summary>
    /// Gets the <see cref="ServerLoadInfoRef"/> of the specified index.
    /// </summary>
        public ServerLoadInfoRef this[int index] => new (this._data[(6 + index * ServerLoadInfoRef.Length)..]);

    /// <summary>
    /// Performs an implicit conversion from a Span of bytes to a <see cref="ServerListResponseOld"/>.
    /// </summary>
    /// <param name="packet">The packet as span.</param>
    /// <returns>The packet as struct.</returns>
    public static implicit operator ServerListResponseOldRef(Span<byte> packet) => new (packet, false);

    /// <summary>
    /// Performs an implicit conversion from <see cref="ServerListResponseOld"/> to a Span of bytes.
    /// </summary>
    /// <param name="packet">The packet as struct.</param>
    /// <returns>The packet as byte span.</returns>
    public static implicit operator Span<byte>(ServerListResponseOldRef packet) => packet._data; 

    /// <summary>
    /// Calculates the size of the packet for the specified count of <see cref="ServerLoadInfoRef"/>.
    /// </summary>
    /// <param name="serversCount">The count of <see cref="ServerLoadInfoRef"/> from which the size will be calculated.</param>
        
    public static int GetRequiredSize(int serversCount) => serversCount * ServerLoadInfoRef.Length + 6;


/// <summary>
/// Contains the id and the load of a server..
/// </summary>
public readonly ref struct ServerLoadInfoRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="ServerLoadInfoRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public ServerLoadInfoRef(Span<byte> data)
    {
        this._data = data;
    }

    /// <summary>
    /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
    /// </summary>
    public static int Length => 2;

    /// <summary>
    /// Gets or sets the server id.
    /// </summary>
    public byte ServerId
    {
        get => this._data[0];
        set => this._data[0] = value;
    }

    /// <summary>
    /// Gets or sets the load percentage.
    /// </summary>
    public byte LoadPercentage
    {
        get => this._data[1];
        set => this._data[1] = value;
    }
}
}


/// <summary>
/// Is sent by the server when: This packet is sent by the server after the client connected to the server.
/// Causes reaction on client side: A game client will request the server list. The launcher would request the patch state.
/// </summary>
public readonly ref struct HelloRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="HelloRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public HelloRef(Span<byte> data)
        : this(data, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HelloRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    /// <param name="initialize">If set to <c>true</c>, the header data is automatically initialized and written to the underlying span.</param>
    private HelloRef(Span<byte> data, bool initialize)
    {
        this._data = data;
        if (initialize)
        {
            var header = this.Header;
            header.Type = HeaderType;
            header.Code = Code;
            header.Length = (byte)Math.Min(data.Length, Length);
            header.SubCode = SubCode;
        }
    }

    /// <summary>
    /// Gets the header type of this data packet.
    /// </summary>
    public static byte HeaderType => 0xC1;

    /// <summary>
    /// Gets the operation code of this data packet.
    /// </summary>
    public static byte Code => 0x00;

    /// <summary>
    /// Gets the operation sub-code of this data packet.
    /// The <see cref="Code" /> is used as a grouping key.
    /// </summary>
    public static byte SubCode => 0x01;

    /// <summary>
    /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
    /// </summary>
    public static int Length => 4;

    /// <summary>
    /// Gets the header of this packet.
    /// </summary>
    public C1HeaderWithSubCodeRef Header => new (this._data);

    /// <summary>
    /// Performs an implicit conversion from a Span of bytes to a <see cref="Hello"/>.
    /// </summary>
    /// <param name="packet">The packet as span.</param>
    /// <returns>The packet as struct.</returns>
    public static implicit operator HelloRef(Span<byte> packet) => new (packet, false);

    /// <summary>
    /// Performs an implicit conversion from <see cref="Hello"/> to a Span of bytes.
    /// </summary>
    /// <param name="packet">The packet as struct.</param>
    /// <returns>The packet as byte span.</returns>
    public static implicit operator Span<byte>(HelloRef packet) => packet._data; 
}


/// <summary>
/// Is sent by the client when: This packet is sent by the client (launcher) to check if the patch version is high enough to be able to connect to the server.
/// Causes reaction on server side: The connect server will check the version and sends a 'PatchVersionOkay' or a 'ClientNeedsPatch' message.
/// </summary>
public readonly ref struct PatchCheckRequestRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="PatchCheckRequestRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public PatchCheckRequestRef(Span<byte> data)
        : this(data, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PatchCheckRequestRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    /// <param name="initialize">If set to <c>true</c>, the header data is automatically initialized and written to the underlying span.</param>
    private PatchCheckRequestRef(Span<byte> data, bool initialize)
    {
        this._data = data;
        if (initialize)
        {
            var header = this.Header;
            header.Type = HeaderType;
            header.Code = Code;
            header.Length = (byte)Math.Min(data.Length, Length);
        }
    }

    /// <summary>
    /// Gets the header type of this data packet.
    /// </summary>
    public static byte HeaderType => 0xC1;

    /// <summary>
    /// Gets the operation code of this data packet.
    /// </summary>
    public static byte Code => 0x02;

    /// <summary>
    /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
    /// </summary>
    public static int Length => 6;

    /// <summary>
    /// Gets the header of this packet.
    /// </summary>
    public C1HeaderRef Header => new (this._data);

    /// <summary>
    /// Gets or sets the major version.
    /// </summary>
    public byte MajorVersion
    {
        get => this._data[3];
        set => this._data[3] = value;
    }

    /// <summary>
    /// Gets or sets the minor version.
    /// </summary>
    public byte MinorVersion
    {
        get => this._data[4];
        set => this._data[4] = value;
    }

    /// <summary>
    /// Gets or sets the patch version.
    /// </summary>
    public byte PatchVersion
    {
        get => this._data[5];
        set => this._data[5] = value;
    }

    /// <summary>
    /// Performs an implicit conversion from a Span of bytes to a <see cref="PatchCheckRequest"/>.
    /// </summary>
    /// <param name="packet">The packet as span.</param>
    /// <returns>The packet as struct.</returns>
    public static implicit operator PatchCheckRequestRef(Span<byte> packet) => new (packet, false);

    /// <summary>
    /// Performs an implicit conversion from <see cref="PatchCheckRequest"/> to a Span of bytes.
    /// </summary>
    /// <param name="packet">The packet as struct.</param>
    /// <returns>The packet as byte span.</returns>
    public static implicit operator Span<byte>(PatchCheckRequestRef packet) => packet._data; 
}


/// <summary>
/// Is sent by the server when: This packet is sent by the server after the client (launcher) requested the to check the patch version and it was high enough.
/// Causes reaction on client side: The launcher will activate its start button.
/// </summary>
public readonly ref struct PatchVersionOkayRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="PatchVersionOkayRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public PatchVersionOkayRef(Span<byte> data)
        : this(data, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PatchVersionOkayRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    /// <param name="initialize">If set to <c>true</c>, the header data is automatically initialized and written to the underlying span.</param>
    private PatchVersionOkayRef(Span<byte> data, bool initialize)
    {
        this._data = data;
        if (initialize)
        {
            var header = this.Header;
            header.Type = HeaderType;
            header.Code = Code;
            header.Length = (byte)Math.Min(data.Length, Length);
        }
    }

    /// <summary>
    /// Gets the header type of this data packet.
    /// </summary>
    public static byte HeaderType => 0xC1;

    /// <summary>
    /// Gets the operation code of this data packet.
    /// </summary>
    public static byte Code => 0x02;

    /// <summary>
    /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
    /// </summary>
    public static int Length => 4;

    /// <summary>
    /// Gets the header of this packet.
    /// </summary>
    public C1HeaderRef Header => new (this._data);

    /// <summary>
    /// Performs an implicit conversion from a Span of bytes to a <see cref="PatchVersionOkay"/>.
    /// </summary>
    /// <param name="packet">The packet as span.</param>
    /// <returns>The packet as struct.</returns>
    public static implicit operator PatchVersionOkayRef(Span<byte> packet) => new (packet, false);

    /// <summary>
    /// Performs an implicit conversion from <see cref="PatchVersionOkay"/> to a Span of bytes.
    /// </summary>
    /// <param name="packet">The packet as struct.</param>
    /// <returns>The packet as byte span.</returns>
    public static implicit operator Span<byte>(PatchVersionOkayRef packet) => packet._data; 
}


/// <summary>
/// Is sent by the server when: This packet is sent by the server after the client (launcher) requested to check the patch version and it requires an update.
/// Causes reaction on client side: The launcher will download the required patches and then activate the start button.
/// </summary>
public readonly ref struct ClientNeedsPatchRef
{
    private readonly Span<byte> _data;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientNeedsPatchRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    public ClientNeedsPatchRef(Span<byte> data)
        : this(data, true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientNeedsPatchRef"/> struct.
    /// </summary>
    /// <param name="data">The underlying data.</param>
    /// <param name="initialize">If set to <c>true</c>, the header data is automatically initialized and written to the underlying span.</param>
    private ClientNeedsPatchRef(Span<byte> data, bool initialize)
    {
        this._data = data;
        if (initialize)
        {
            var header = this.Header;
            header.Type = HeaderType;
            header.Code = Code;
            header.Length = (byte)Math.Min(data.Length, Length);
            header.SubCode = SubCode;
        }
    }

    /// <summary>
    /// Gets the header type of this data packet.
    /// </summary>
    public static byte HeaderType => 0xC1;

    /// <summary>
    /// Gets the operation code of this data packet.
    /// </summary>
    public static byte Code => 0x05;

    /// <summary>
    /// Gets the operation sub-code of this data packet.
    /// The <see cref="Code" /> is used as a grouping key.
    /// </summary>
    public static byte SubCode => 0x1;

    /// <summary>
    /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
    /// </summary>
    public static int Length => 138;

    /// <summary>
    /// Gets the header of this packet.
    /// </summary>
    public C1HeaderWithSubCodeRef Header => new (this._data);

    /// <summary>
    /// Gets or sets the patch version.
    /// </summary>
    public byte PatchVersion
    {
        get => this._data[4];
        set => this._data[4] = value;
    }

    /// <summary>
    /// Gets or sets the patch address, usually to a ftp server. The address is usually "encrypted" with the 3-byte XOR key (FC CF AB).
    /// </summary>
    public string PatchAddress
    {
        get => this._data.ExtractString(6, this._data.Length - 6, System.Text.Encoding.UTF8);
        set => this._data.Slice(6).WriteString(value, System.Text.Encoding.UTF8);
    }

    /// <summary>
    /// Performs an implicit conversion from a Span of bytes to a <see cref="ClientNeedsPatch"/>.
    /// </summary>
    /// <param name="packet">The packet as span.</param>
    /// <returns>The packet as struct.</returns>
    public static implicit operator ClientNeedsPatchRef(Span<byte> packet) => new (packet, false);

    /// <summary>
    /// Performs an implicit conversion from <see cref="ClientNeedsPatch"/> to a Span of bytes.
    /// </summary>
    /// <param name="packet">The packet as struct.</param>
    /// <returns>The packet as byte span.</returns>
    public static implicit operator Span<byte>(ClientNeedsPatchRef packet) => packet._data; 

    /// <summary>
    /// Calculates the size of the packet for the specified field content.
    /// </summary>
    /// <param name="content">The content of the variable 'PatchAddress' field from which the size will be calculated.</param>
    public static int GetRequiredSize(string content) => System.Text.Encoding.UTF8.GetByteCount(content) + 1 + 6;

    /// <summary>
    /// Calculates the size of the packet for the specified field content.
    /// </summary>
    /// <param name="contentLength">The content length in bytes of the variable 'PatchAddress' field from which the size will be calculated.</param>
    public static int GetRequiredSize(int contentLength) => contentLength + 1 + 6;
}
