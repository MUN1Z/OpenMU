﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:pd="http://www.munique.net/OpenMU/PacketDefinitions"
>
  <xsl:param name="resultFileName" />
  <xsl:param name="subNamespace" />
  <xsl:output method="text" indent="yes" />
    <xsl:variable name='newline'>
      <xsl:text xml:space='preserve'>
</xsl:text>
    </xsl:variable>
    <xsl:variable name="upperCaseLetters">ABCDEFGHIJKLMNOPQRSTUVWXYZ</xsl:variable>
    <xsl:variable name="lowerCaseLetters">abcdefghijklmnopqrstuvwxyz</xsl:variable>
    <xsl:variable name="digits">0123456789</xsl:variable>

  <xsl:template match="pd:PacketDefinitions">
    <xsl:text>// &lt;copyright file="</xsl:text><xsl:value-of select="$resultFileName"/><xsl:text>" company="MUnique"&gt;
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// &lt;/copyright&gt;

//------------------------------------------------------------------------------
// &lt;auto-generated&gt;
//     This source code was auto-generated by an XSL transformation.
//     Do not change this file. Instead, change the XML data which contains
//     the packet definitions and re-run the transformation (rebuild this project).
// &lt;/auto-generated&gt;
//------------------------------------------------------------------------------

namespace MUnique.OpenMU.Network.Packets</xsl:text>
    <xsl:if test="$subNamespace">
      <xsl:text>.</xsl:text>
      <xsl:value-of select="$subNamespace"/>
    </xsl:if>
<xsl:text>
{
    using System;</xsl:text>
<xsl:apply-templates />
<xsl:text>}</xsl:text>
  </xsl:template>
    
    <xsl:template match="pd:Structure/pd:Description">
      <xsl:text>
    /// &lt;summary&gt;
    /// </xsl:text><xsl:value-of select="."/><xsl:text>.</xsl:text>
  <xsl:text>
    /// &lt;/summary&gt;</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>
    <xsl:template match="pd:Structure">
      <xsl:value-of select="$newline" />
      <xsl:apply-templates select="pd:Description"/>
      <xsl:text>    public readonly ref struct </xsl:text>
      <xsl:apply-templates select="pd:Name" />
      <xsl:value-of select="$newline"/>
      <xsl:text>    {</xsl:text>
      <xsl:value-of select="$newline"/>
      <xsl:text>        private readonly Span&lt;byte&gt; data;</xsl:text>
      <xsl:value-of select="$newline"/>
      <xsl:call-template name="structConstructor">
        <xsl:with-param name="struct" select="." />
      </xsl:call-template>
      <xsl:apply-templates select="pd:Length"/>
      <xsl:apply-templates select="pd:Type"/>
      <xsl:apply-templates select="pd:Fields" />
      <xsl:call-template name="lengthCalculator">
        <xsl:with-param name="struct" select="." />
      </xsl:call-template>
      <xsl:text>    }</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>


    <xsl:template match="pd:Packet">
      <xsl:value-of select="$newline" />
      <xsl:if test="pd:SentWhen or pd:CausedReaction">
        <xsl:text>
    /// &lt;summary&gt;
    /// Is sent </xsl:text>
        <xsl:choose>
          <xsl:when test="pd:Direction = 'ClientToServer'"><xsl:text>by the client when: </xsl:text></xsl:when>
          <xsl:otherwise><xsl:text>by the server when: </xsl:text></xsl:otherwise>
        </xsl:choose>
        <xsl:value-of select="pd:SentWhen"/>
        <xsl:text>
    /// Causes reaction </xsl:text>
        <xsl:choose>
          <xsl:when test="pd:Direction = 'ClientToServer'"><xsl:text>on server side: </xsl:text></xsl:when>
          <xsl:otherwise><xsl:text>on client side: </xsl:text></xsl:otherwise>
        </xsl:choose>
        <xsl:value-of select="pd:CausedReaction"/>
          <xsl:text>
    /// &lt;/summary&gt;</xsl:text>
      <xsl:value-of select="$newline" />
      </xsl:if>
      <xsl:apply-templates select="pd:Description"/>
      <xsl:text>    public readonly ref struct </xsl:text>
      <xsl:apply-templates select="pd:Name" />
      <xsl:value-of select="$newline"/>
      <xsl:text>    {</xsl:text>
      <xsl:value-of select="$newline"/>
      <xsl:apply-templates select="pd:Enums" />
      <xsl:text>        private readonly Span&lt;byte&gt; data;</xsl:text>
      <xsl:value-of select="$newline"/>
      <xsl:call-template name="constructor">
        <xsl:with-param name="packet" select="." />
      </xsl:call-template>
      <xsl:apply-templates select="pd:HeaderType"/>
      <xsl:apply-templates select="pd:Code"/>
      <xsl:apply-templates select="pd:SubCode"/>
      <xsl:apply-templates select="pd:Length"/>
      <xsl:text>
        /// &lt;summary&gt;
        /// Gets the header of this packet.
        /// &lt;/summary&gt;
        public </xsl:text>
      <xsl:value-of select="pd:HeaderType"/>
      <xsl:text> Header => new </xsl:text><xsl:value-of select="pd:HeaderType"/><xsl:text>(this.data);</xsl:text>
      <xsl:value-of select="$newline"/>
      <xsl:apply-templates select="pd:Fields" />
      <xsl:call-template name="implicitConversions">
        <xsl:with-param name="packet" select="." />
      </xsl:call-template>
      <xsl:call-template name="lengthCalculator">
        <xsl:with-param name="struct" select="." />
      </xsl:call-template>
      <xsl:apply-templates select="pd:Structures" />
      <xsl:text>    }</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>

    <xsl:template match="pd:HeaderType">
      <xsl:text>
        /// &lt;summary&gt;
        /// Gets the header type of this data packet.
        /// &lt;/summary&gt;
        public static byte HeaderType => 0x</xsl:text>
      <xsl:value-of select="substring(., 1, 2)"/>
      <xsl:text>;</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>

    <xsl:template match="pd:Code">
      <xsl:text>
        /// &lt;summary&gt;
        /// Gets the operation code of this data packet.
        /// &lt;/summary&gt;
        public static byte Code => 0x</xsl:text>
      <xsl:value-of select="."/>
      <xsl:text>;</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>

    <xsl:template match="pd:SubCode">
      <xsl:text>
        /// &lt;summary&gt;
        /// Gets the operation sub-code of this data packet.
        /// The &lt;see cref="Code" /&gt; is used as a grouping key.
        /// &lt;/summary&gt;
        public static byte SubCode => 0x</xsl:text>
      <xsl:value-of select="."/>
      <xsl:text>;</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>

    <xsl:template match="pd:Length">
      <xsl:text>
        /// &lt;summary&gt;
        /// Gets the initial length of this data packet. When the size is dynamic, this value may be bigger than actually needed.
        /// &lt;/summary&gt;
        public static int Length => </xsl:text>
      <xsl:value-of select="."/>
      <xsl:text>;</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>

    <xsl:template name="constructor">
        <xsl:param name="packet" />
        <xsl:text>
        /// &lt;summary&gt;
        /// Initializes a new instance of the &lt;see cref="</xsl:text><xsl:apply-templates select="pd:Name" /><xsl:text>"/&gt; struct.
        /// &lt;/summary&gt;
        /// &lt;param name="data"&gt;The underlying data.&lt;/param&gt;
        public </xsl:text>
        <xsl:apply-templates select="pd:Name" />
        <xsl:text>(Span&lt;byte&gt; data)
            : this(data, true)</xsl:text>
        <xsl:value-of select="$newline"/>
        <xsl:text>        {</xsl:text>
        <xsl:value-of select="$newline"/>
        <xsl:text>        }</xsl:text>
        <xsl:value-of select="$newline"/>

        <xsl:text>
        /// &lt;summary&gt;
        /// Initializes a new instance of the &lt;see cref="</xsl:text><xsl:apply-templates select="pd:Name" /><xsl:text>"/&gt; struct.
        /// &lt;/summary&gt;
        /// &lt;param name="data"&gt;The underlying data.&lt;/param&gt;
        /// &lt;param name="initialize"&gt;If set to &lt;c&gt;true&lt;/c&gt;, the header data is automatically initialized and written to the underlying span.&lt;/param&gt;
        private </xsl:text>
        <xsl:apply-templates select="pd:Name" />
        <xsl:text>(Span&lt;byte&gt; data, bool initialize)</xsl:text>
        <xsl:value-of select="$newline"/>
        <xsl:text>        {</xsl:text>
        <xsl:value-of select="$newline"/>
        <xsl:text>            this.data = data;
            if (initialize)
            {
                var header = this.Header;
                header.Type = HeaderType;
                header.Code = Code;
                header.Length = </xsl:text>
      <xsl:call-template name="lengthDataType">
        <!--
          Depending on the header type, the length is either 1 or 2 bytes long. We assume that the remainder of two is enough to identify that.
          The following select is a small hack to make our life easier. We assume that the second character is a decimal number.
          Otherwise, we would need to convert a hex string to a number, which needs additional code.
        -->
        <xsl:with-param name="HeaderType" select="number(substring(pd:HeaderType,2,1))"/>
      </xsl:call-template>
        <xsl:choose>
          <xsl:when test="pd:Length">Math.Min(data.Length, Length);</xsl:when>
          <xsl:otherwise>data.Length;</xsl:otherwise>
        </xsl:choose>
        <xsl:if test="pd:SubCode">
          <xsl:text>
                header.SubCode = SubCode;</xsl:text>
        </xsl:if>
        <xsl:apply-templates select="pd:Fields" mode="init" />
        <xsl:text>
            }</xsl:text>
        <xsl:value-of select="$newline"/>
        <xsl:text>        }</xsl:text>
        <xsl:value-of select="$newline"/>
    </xsl:template>

    <xsl:template name="lengthDataType">
      <xsl:param name="HeaderType" />
      <xsl:variable name="isByte" select="$HeaderType mod 2 = 1" />
      <xsl:choose>
        <xsl:when test="$isByte = 1">(byte)</xsl:when>
        <xsl:when test="$isByte = 0">(ushort)</xsl:when>
      </xsl:choose>
    </xsl:template>

    <xsl:template name="structConstructor">
        <xsl:param name="struct" />
        <xsl:text>
        /// &lt;summary&gt;
        /// Initializes a new instance of the &lt;see cref="</xsl:text><xsl:apply-templates select="pd:Name" /><xsl:text>"/&gt; struct.
        /// &lt;/summary&gt;
        /// &lt;param name="data"&gt;The underlying data.&lt;/param&gt;
        public </xsl:text>
        <xsl:apply-templates select="pd:Name" />
        <xsl:text>(Span&lt;byte&gt; data)</xsl:text>
      <xsl:value-of select="$newline"/>
        <xsl:text>        {</xsl:text>
        <xsl:value-of select="$newline"/>
        <xsl:text>            this.data = data;</xsl:text>
        <xsl:value-of select="$newline"/>
        <xsl:text>        }</xsl:text>
        <xsl:value-of select="$newline"/>
    </xsl:template>

  <!-- If the last field is a string or a binary without a fixed length, we want to offer a static function to calculate the required size. -->
  <xsl:template name="lengthCalculator">
    <xsl:param name="struct" />
    <xsl:variable name="variableField" select="$struct/pd:Fields[last()]/pd:Field[(pd:Type = 'String' or pd:Type = 'Binary' or pd:Type = 'Structure[]') and not(pd:Length)]" />
    <xsl:if test="$variableField" >
      <xsl:variable name="paramName">
        <xsl:choose>
          <xsl:when test="$variableField/pd:Type = 'Structure[]'">
            <xsl:value-of select="concat(translate(substring($variableField/pd:Name, 1, 1), $upperCaseLetters, $lowerCaseLetters), substring($variableField/pd:Name, 2))"/>
            <xsl:text>Count</xsl:text>
          </xsl:when>
          <xsl:otherwise>
            <xsl:text>content</xsl:text>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      <xsl:variable name="paramTypeName">
        <xsl:choose>
          <xsl:when test="$variableField/pd:Type = 'Structure[]'">
            <xsl:text>int</xsl:text>
          </xsl:when>
          <xsl:otherwise>
            <xsl:apply-templates select="$variableField/pd:Type" mode="type"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      <xsl:choose>
        <xsl:when test="$variableField/pd:Type = 'Structure[]'">
          <xsl:text>
        /// &lt;summary&gt;
        /// Calculates the size of the packet for the specified count of &lt;see cref="</xsl:text>
          <xsl:value-of select="$variableField/pd:TypeName" />
          <xsl:text>"/&gt;.
        /// &lt;/summary&gt;
        /// &lt;param name="</xsl:text>
          <xsl:value-of select="$paramName"/><xsl:text>"&gt;The count of &lt;see cref="</xsl:text>
          <xsl:value-of select="$variableField/pd:TypeName" />
          <xsl:text>"/&gt; from which the size will be calculated.&lt;/param&gt;
        </xsl:text>
        </xsl:when>
        <xsl:otherwise>
          <xsl:text>
        /// &lt;summary&gt;
        /// Calculates the size of the packet for the specified field content.
        /// &lt;/summary&gt;
        /// &lt;param name="content"&gt;The content of the variable '</xsl:text>
          <xsl:apply-templates select="$variableField/pd:Name" />
          <xsl:text>' field from which the size will be calculated.&lt;/param&gt;
        </xsl:text>
        </xsl:otherwise>
      </xsl:choose>
      <xsl:text>public static int GetRequiredSize(</xsl:text>
      <xsl:value-of select="$paramTypeName"/>
      <xsl:text xml:space="preserve"> </xsl:text>
      <xsl:value-of select="$paramName"/>
      <xsl:text>) => </xsl:text>
      
      <xsl:choose>
        <xsl:when test="$variableField/pd:Type = 'String'">
          <xsl:text>System.Text.Encoding.UTF8.GetByteCount(content) + 1</xsl:text>
        </xsl:when>
        <xsl:when test="$variableField/pd:Type = 'Binary'">
          <xsl:text>content.Length</xsl:text>
        </xsl:when>
        <xsl:when test="$variableField/pd:Type = 'Structure[]'">
          <xsl:value-of select="concat(translate(substring($variableField/pd:Name, 1, 1), $upperCaseLetters, $lowerCaseLetters), substring($variableField/pd:Name, 2))"/>
          <xsl:text>Count * </xsl:text>
          <xsl:value-of select="$variableField/pd:TypeName" />
          <xsl:text>.Length</xsl:text>
        </xsl:when>
      </xsl:choose>
      <xsl:text> + </xsl:text>
      <xsl:value-of select="$variableField/pd:Index"/>
      <xsl:text>;</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:if>
  </xsl:template>

    <xsl:template name="implicitConversions">
      <xsl:param name="packet" />
      <xsl:text>
        /// &lt;summary&gt;
        /// Performs an implicit conversion from a Span of bytes to a &lt;see cref="</xsl:text><xsl:apply-templates select="pd:Name" /><xsl:text>"/&gt;.
        /// &lt;/summary&gt;
        /// &lt;param name="packet"&gt;The packet as span.&lt;/param&gt;
        /// &lt;returns&gt;The packet as struct.&lt;/returns&gt;
        public static implicit operator </xsl:text>
      <xsl:apply-templates select="pd:Name" />
      <xsl:text>(Span&lt;byte&gt; packet) => new </xsl:text>
      <xsl:apply-templates select="pd:Name" />
      <xsl:text>(packet, false);

        /// &lt;summary&gt;
        /// Performs an implicit conversion from &lt;see cref="</xsl:text><xsl:apply-templates select="pd:Name" /><xsl:text>"/&gt; to a Span of bytes.
        /// &lt;/summary&gt;
        /// &lt;param name="packet"&gt;The packet as struct.&lt;/param&gt;
        /// &lt;returns&gt;The packet as byte span.&lt;/returns&gt;
        public static implicit operator Span&lt;byte&gt;(</xsl:text>
      <xsl:apply-templates select="pd:Name" />
      <xsl:text> packet) => packet.data; </xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>

    <!-- Example: public CharacterData this[int index] => new CharacterData(this.data.Slice(8 + index));-->
    <xsl:template match="pd:Field[pd:Type = 'Structure[]']">
      <xsl:text>
        /// &lt;summary&gt;
        /// Gets the </xsl:text>
      <xsl:value-of select="concat(translate(substring(pd:TypeName, 1, 1), $upperCaseLetters, $lowerCaseLetters), substring(pd:TypeName, 2))"/>
      <xsl:text> of the specified index.
        /// &lt;/summary&gt;</xsl:text>
      <xsl:value-of select="$newline"/>
      <xsl:text>        public </xsl:text>
      <xsl:value-of select="pd:TypeName"/>
      <xsl:text> this[int index] => new </xsl:text>
      <xsl:value-of select="pd:TypeName"/>
      <xsl:text>(this.data.Slice(</xsl:text>
      <xsl:value-of select="pd:Index"/>
      <xsl:text> + (index * </xsl:text>
      <xsl:value-of select="pd:TypeName"/>
      <xsl:text>.Length)));</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>

    <xsl:template match="pd:Field[pd:DefaultValue]" mode="init">
      <xsl:value-of select="$newline"/>
      <xsl:text>                this.data[</xsl:text>
      <xsl:value-of select="pd:Index"/>
      <xsl:text>] = </xsl:text>
      <xsl:value-of select="pd:DefaultValue"/>
      <xsl:text>;</xsl:text>
    </xsl:template>

    <xsl:template match="pd:Field">
      <xsl:choose>
        <xsl:when test="pd:Description">
          <xsl:text>
        /// &lt;summary&gt;
        /// Gets or sets </xsl:text><xsl:value-of select="concat(translate(substring(pd:Description, 1, 1), $upperCaseLetters, $lowerCaseLetters), substring(pd:Description, 2))"/><xsl:text>
        /// &lt;/summary&gt;</xsl:text>
        </xsl:when>
        <xsl:otherwise>
          <xsl:text>
        /// &lt;summary&gt;
        /// Gets or sets the</xsl:text>
          <xsl:call-template name="splitName">
            <xsl:with-param name="name" select="pd:Name" />
          </xsl:call-template><xsl:text>.
        /// &lt;/summary&gt;</xsl:text>
        </xsl:otherwise>
      </xsl:choose>
      <xsl:apply-templates select="pd:Description"/>
      <xsl:value-of select="$newline"/>
      <xsl:text>        public </xsl:text>
      <xsl:apply-templates mode="type" />
      <xsl:text xml:space="preserve"> </xsl:text>
      <xsl:apply-templates select="pd:Name" />
      <xsl:value-of select="$newline"/>
      <xsl:text>        {</xsl:text>
      <xsl:apply-templates select="." mode="get" />
      <xsl:apply-templates select="." mode="set" />
      <xsl:value-of select="$newline"/>
      <xsl:text>        }</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>

    <xsl:template match="pd:Enum/pd:Description">
      <xsl:text>        /// &lt;summary&gt;
        /// </xsl:text><xsl:value-of select="."/><xsl:text>
        /// &lt;/summary&gt;</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>
    <xsl:template match="pd:EnumValue/pd:Description">
      <xsl:text>            /// &lt;summary&gt;
            /// </xsl:text><xsl:value-of select="."/><xsl:text>
            /// &lt;/summary&gt;</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>
    <xsl:template match="pd:Enum">
      <xsl:apply-templates select="pd:Description"/>
      <xsl:text>        public enum </xsl:text>
      <xsl:apply-templates select="pd:Name" />
      <xsl:value-of select="$newline"/>
      <xsl:text>        {</xsl:text>
      <xsl:apply-templates select="pd:Values" />
      <xsl:text>        }</xsl:text>
      <xsl:value-of select="$newline"/>
      <xsl:value-of select="$newline"/>
    </xsl:template>
    <xsl:template match="pd:EnumValue">
      <xsl:value-of select="$newline"/>
      <xsl:apply-templates select="pd:Description"/>
      <xsl:text xml:space="preserve">            </xsl:text>
      <xsl:apply-templates select="pd:Name" />
      <xsl:text> = </xsl:text>
      <xsl:value-of select="pd:Value" />
      <xsl:text>,</xsl:text>
      <xsl:value-of select="$newline"/>
    </xsl:template>

  <xsl:template match="text()"></xsl:template>
    
    <xsl:template match="pd:Name">
      <xsl:value-of select="translate(., ' ()/-:', '')"/>
    </xsl:template>

    <!-- Type mapping: -->
    <xsl:template match="pd:Type[. = 'Boolean']" mode="type">bool</xsl:template>
    <xsl:template match="pd:Type[. = 'Byte']" mode="type">byte</xsl:template>
    <xsl:template match="pd:Type[. = 'Short' or . = 'ShortBigEndian']" mode="type">ushort</xsl:template>
    <xsl:template match="pd:Type[. = 'Integer' or . = 'IntegerBigEndian']" mode="type">uint</xsl:template>
    <xsl:template match="pd:Type[. = 'Long' or . = 'LongBigEndian']" mode="type">ulong</xsl:template>
    <xsl:template match="pd:Type[. = 'Float']" mode="type">float</xsl:template>
    <xsl:template match="pd:Type[. = 'String']" mode="type">string</xsl:template>
    <xsl:template match="pd:Type[. = 'Binary']" mode="type">Span&lt;byte&gt;</xsl:template>
    <xsl:template match="pd:Type[. = 'Enum']" mode="type">
      <xsl:value-of select="./../pd:TypeName"/>
    </xsl:template>
    <xsl:template match="pd:Type[. = 'Structure[]']" mode="type">
      <xsl:text>Span&lt;</xsl:text>
      <xsl:value-of select="./../pd:TypeName"/>
      <xsl:text>&gt;</xsl:text>
    </xsl:template>

    <xsl:template match="text()" mode="type"></xsl:template>

    <!-- Getter/Setter implementations: -->
    <xsl:template match="pd:Field[pd:Type = 'Boolean']" mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).GetBoolean(</xsl:text>
      <xsl:if test="pd:LeftShifted">
        <xsl:value-of select="pd:LeftShifted"/>
      </xsl:if>
      <xsl:text>);</xsl:text>
    </xsl:template>
    <xsl:template match="pd:Field[pd:Type = 'Boolean']" mode="set">
      <xsl:value-of select="$newline"/>
      <xsl:text>            set =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).SetBoolean(value</xsl:text>
      <xsl:if test="pd:LeftShifted">
        <xsl:text>, </xsl:text>
        <xsl:value-of select="pd:LeftShifted"/>
      </xsl:if>
      <xsl:text>);</xsl:text>
    </xsl:template>

    <xsl:template match="pd:Field[pd:Type = 'Byte']" mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; this.data[</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>];</xsl:text>
    </xsl:template>
    <xsl:template match="pd:Field[pd:Type = 'Byte']" mode="set">
      <xsl:value-of select="$newline"/>
      <xsl:text>            set =&gt; this.data[</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>] = value;</xsl:text>
    </xsl:template>

    <xsl:template match="pd:Field[pd:Type = 'Short']" mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).GetShortLittleEndian();</xsl:text>
    </xsl:template>
    <xsl:template match="pd:Field[pd:Type = 'Short']" mode="set">
      <xsl:value-of select="$newline"/>
      <xsl:text>            set =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).SetShortLittleEndian(value);</xsl:text>
    </xsl:template>

    <xsl:template match="pd:Field[pd:Type = 'ShortBigEndian']" mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).GetShortBigEndian();</xsl:text>
    </xsl:template>
    <xsl:template match="pd:Field[pd:Type = 'ShortBigEndian']" mode="set">
      <xsl:value-of select="$newline"/>
      <xsl:text>            set =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).SetShortBigEndian(value);</xsl:text>
    </xsl:template>
    
    <xsl:template match="pd:Field[pd:Type = 'Integer']" mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).GetIntegerLittleEndian();</xsl:text>
    </xsl:template>
    
    <xsl:template match="pd:Field[pd:Type = 'Integer']" mode="set">
      <xsl:value-of select="$newline"/>
      <xsl:text>            set =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).SetIntegerLittleEndian(value);</xsl:text>
    </xsl:template>

    <xsl:template match="pd:Field[pd:Type = 'IntegerBigEndian']" mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).GetIntegerBigEndian();</xsl:text>
    </xsl:template>
    <xsl:template match="pd:Field[pd:Type = 'IntegerBigEndian']" mode="set">
      <xsl:value-of select="$newline"/>
      <xsl:text>            set =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).SetIntegerBigEndian(value);</xsl:text>
    </xsl:template>

    <xsl:template match="pd:Field[pd:Type = 'Long']"  mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).GetLongLittleEndian();</xsl:text>
    </xsl:template>
    <xsl:template match="pd:Field[pd:Type = 'Long']"  mode="set">
      <xsl:value-of select="$newline"/>
      <xsl:text>            set =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).SetLongLittleEndian(value);</xsl:text>
    </xsl:template>

    <xsl:template match="pd:Field[pd:Type = 'LongBigEndian']"  mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).GetLongBigEndian();</xsl:text>
    </xsl:template>
    <xsl:template match="pd:Field[pd:Type = 'LongBigEndian']"  mode="set">
      <xsl:value-of select="$newline"/>
      <xsl:text>            set =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>).SetLongBigEndian(value);</xsl:text>
    </xsl:template>

    <!-- Floats can be optimized I think-->
    <xsl:template match="pd:Field[pd:Type = 'Float']"  mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; BitConverter.ToSingle(this.data.Slice(</xsl:text>
      <xsl:value-of select="pd:Index"/>
      <xsl:text>));</xsl:text>
    </xsl:template>
    <xsl:template match="pd:Field[pd:Type = 'Float']"  mode="set">
      <xsl:value-of select="$newline"/>
      <xsl:text>            set =&gt; BitConverter.GetBytes(value).CopyTo(this.data.Slice(</xsl:text>
      <xsl:value-of select="pd:Index"/>
      <xsl:text>));</xsl:text>
    </xsl:template>

    <xsl:template match="pd:Field[pd:Type = 'String']"  mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; this.data.ExtractString(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>, </xsl:text>
        <xsl:choose>
          <xsl:when test="pd:Length">
            <xsl:value-of select="pd:Length"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:text>this.data.Length - </xsl:text>
            <xsl:value-of select="pd:Index"/>
          </xsl:otherwise>
        </xsl:choose>
      <xsl:text>, System.Text.Encoding.UTF8);</xsl:text>
      <xsl:value-of select="$newline"/>
      <xsl:text>            set =&gt; this.data.Slice(</xsl:text>
        <xsl:value-of select="pd:Index"/>
        <xsl:if test="pd:Length">
          <xsl:text>, </xsl:text><xsl:value-of select="pd:Length"/>
        </xsl:if>
      <xsl:text>).WriteString(value, System.Text.Encoding.UTF8);</xsl:text>
    </xsl:template>

    <xsl:template match="pd:Field[pd:Type = 'Binary']" mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; this.data.Slice(</xsl:text>
        <xsl:value-of select="pd:Index"/>
      <xsl:if test="pd:Length">
        <xsl:text>, </xsl:text>
        <xsl:value-of select="pd:Length"/>
      </xsl:if>
      <xsl:text>);</xsl:text>
    </xsl:template>

    <xsl:template match="pd:Field[pd:Type = 'Enum']" mode="get">
      <xsl:value-of select="$newline"/>
      <xsl:text>            get =&gt; (</xsl:text><xsl:value-of select="pd:TypeName"/><xsl:text>)this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>)</xsl:text>
      <xsl:choose>
        <xsl:when test="pd:Length and pd:LeftShifted">
          <xsl:text>.GetByteValue(</xsl:text>
          <xsl:value-of select="pd:Length"/>
          <xsl:text>, </xsl:text>
          <xsl:value-of select="pd:LeftShifted"/>
          <xsl:text>)</xsl:text>
        </xsl:when>
        <xsl:when test="pd:Length">
          <xsl:text>.GetByteValue(</xsl:text>
          <xsl:value-of select="pd:Length"/>
          <xsl:text>, 0)</xsl:text>
        </xsl:when>
        <xsl:when test="pd:LeftShifted">
          <xsl:text>.GetByteValue(8, </xsl:text>
          <xsl:value-of select="pd:LeftShifted"/>
          <xsl:text>)</xsl:text>
        </xsl:when>
        <xsl:otherwise>
          <xsl:text>[0]</xsl:text>
        </xsl:otherwise>
      </xsl:choose>
      <xsl:text>;</xsl:text>
    </xsl:template>
    <xsl:template match="pd:Field[pd:Type = 'Enum']" mode="set">
      <xsl:value-of select="$newline"/>
      <xsl:text>            set =&gt; this.data.Slice(</xsl:text><xsl:value-of select="pd:Index"/><xsl:text>)</xsl:text>
      <xsl:choose>
        <xsl:when test="pd:Length and pd:LeftShifted">
          <xsl:text>.SetByteValue((byte)value, </xsl:text>
          <xsl:value-of select="pd:Length"/>
          <xsl:text>, </xsl:text>
          <xsl:value-of select="pd:LeftShifted"/>
          <xsl:text>)</xsl:text>
        </xsl:when>
        <xsl:when test="pd:Length">
          <xsl:text>.SetByteValue((byte)value, </xsl:text>
          <xsl:value-of select="pd:Length"/>
          <xsl:text>, 0)</xsl:text>
        </xsl:when>
        <xsl:when test="pd:LeftShifted">
          <xsl:text>.SetByteValue((byte)value, 8, </xsl:text>
          <xsl:value-of select="pd:LeftShifted"/>
          <xsl:text>)</xsl:text>
        </xsl:when>
        <xsl:otherwise>[0] = (byte)value</xsl:otherwise>
      </xsl:choose>
      <xsl:text>;</xsl:text>
    </xsl:template>

  <!-- Splits a name by inserting a space before each upper case letter and additionally lowering this letter -->
    <xsl:template name="splitName">
      <xsl:param name="name" />

      <xsl:if test="$name != ''">
        <xsl:variable name="currentLetter" select="substring($name, 1, 1)" />
        <xsl:variable name="isUpperCase" select="contains($upperCaseLetters, $currentLetter)" />
        <xsl:variable name="isDigit" select="contains($digits, $currentLetter)" />
        <xsl:choose>
          <xsl:when test="$isUpperCase">
            <xsl:text xml:space="preserve"> </xsl:text>
            <xsl:value-of select="translate($currentLetter, $upperCaseLetters, $lowerCaseLetters)" />
          </xsl:when>
          <xsl:when test="contains($digits, $currentLetter)">
            <xsl:text xml:space="preserve"> </xsl:text>
            <xsl:value-of select="$currentLetter" />
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="$currentLetter"/>
          </xsl:otherwise>
        </xsl:choose>

        <!-- Call this template again to handle the next letter. -->
        <xsl:call-template name="splitName">
          <xsl:with-param name="name" select="substring-after($name, $currentLetter)" />
        </xsl:call-template>
      </xsl:if>
    </xsl:template>

    <xsl:template match="text()" mode="get"></xsl:template>
    <xsl:template match="text()" mode="set"></xsl:template>
    <xsl:template match="text()" mode="doc"></xsl:template>
    <xsl:template match="text()" mode="init"></xsl:template>

</xsl:stylesheet>
