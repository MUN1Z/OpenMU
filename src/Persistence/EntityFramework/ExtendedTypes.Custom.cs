﻿// <copyright file="ExtendedTypes.Custom.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>
// <auto-generated>
//     This source code extends auto-generated code of a T4 template.
// </auto-generated>

namespace MUnique.OpenMU.Persistence.EntityFramework
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MUnique.OpenMU.AttributeSystem;

    /// <summary>
    /// Extended <see cref="PowerUpDefinitionValue"/> by the properties of <see cref="SimpleElement"/>, because they are a 1:1 relationship.
    /// </summary>
    internal partial class PowerUpDefinitionValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PowerUpDefinitionValue"/> class.
        /// </summary>
        public PowerUpDefinitionValue()
        {
            this.ConstantValue = new SimpleElement();
            this.ConstantValue.ValueChanged += (sender, args) =>
            {
                var element = sender as IElement;
                if (element != null)
                {
                    this.Value = element.Value;
                    this.AggregateType = element.AggregateType;
                }
            };
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public float Value { get; private set; }

        /// <summary>
        /// Gets the type of the aggregate.
        /// </summary>
        public AggregateType AggregateType { get; private set; }

        /// <summary>
        /// Gets or sets the parent as boost identifier.
        /// </summary>
        /// <remarks>
        /// This is required, because <see cref="PowerUpDefinitionValue"/> is used as <see cref="PowerUpDefinition.Boost"/> and as <see cref="PowerUpDefinitionWithDuration.Duration"/>.
        /// The entity framework will not name the foreign keys in a proper way, so they would collide.
        /// </remarks>
        public Guid? ParentAsBoostId { get; set; }

        /// <summary>
        /// Gets or sets the parent as boost.
        /// </summary>
        /// <remarks>
        /// This is required, because <see cref="PowerUpDefinitionValue"/> is used as <see cref="PowerUpDefinition.Boost"/> and as <see cref="PowerUpDefinitionWithDuration.Duration"/>.
        /// The entity framework will not name the foreign keys in a proper way, so they would collide.
        /// </remarks>
        [InverseProperty(nameof(PowerUpDefinitionWithDuration.RawBoost))]
        public PowerUpDefinitionWithDuration ParentAsBoost { get; set; }

        /// <summary>
        /// Gets or sets the parent as duration identifier.
        /// </summary>
        /// <remarks>
        /// This is required, because <see cref="PowerUpDefinitionValue"/> is used as <see cref="PowerUpDefinition.Boost"/> and as <see cref="PowerUpDefinitionWithDuration.Duration"/>.
        /// The entity framework will not name the foreign keys in a proper way, so they would collide.
        /// </remarks>
        public Guid? ParentAsDurationId { get; set; }

        /// <summary>
        /// Gets or sets the duration of the parent as.
        /// </summary>
        /// <remarks>
        /// This is required, because <see cref="PowerUpDefinitionValue"/> is used as <see cref="PowerUpDefinition.Boost"/> and as <see cref="PowerUpDefinitionWithDuration.Duration"/>.
        /// The entity framework will not name the foreign keys in a proper way, so they would collide.
        /// </remarks>
        [InverseProperty(nameof(PowerUpDefinitionWithDuration.RawDuration))]
        public PowerUpDefinitionWithDuration ParentAsDuration { get; set; }
    }

    /// <summary>
    /// The Entity Framework Core implementation of <see cref="ConstValueAttribute"/>.
    /// </summary>
    internal partial class ConstValueAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstValueAttribute"/> class.
        /// </summary>
        public ConstValueAttribute()
        {
            this.InitJoinCollections();
        }

        /// <summary>
        /// Gets or sets the character class identifier.
        /// </summary>
        /// <value>
        /// The character class identifier.
        /// </value>
        public Guid CharacterClassId { get; set; }

        /// <summary>
        /// Gets or sets the character class.
        /// </summary>
        /// <value>
        /// The character class.
        /// </value>
        public CharacterClass CharacterClass { get; set; }

        /// <inheritdoc />
        public new float Value
        {
            get => base.Value;
            set => base.Value = value;
        }
    }

    /// <summary>
    /// The Entity Framework Core implementation of <see cref="MUnique.OpenMU.DataModel.Entities.Item"/>.
    /// </summary>
    internal partial class Item
    {
        /// <summary>
        /// Clones the item option link.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <returns>The cloned item option link.</returns>
        /// <remarks>It does not need to be explicitly added to the context, because it will happen automatically when the context detects the changes of the item.</remarks>
        protected override DataModel.Entities.ItemOptionLink CloneItemOptionLink(DataModel.Entities.ItemOptionLink link)
        {
            var persistentLink = new ItemOptionLink();
            persistentLink.AssignValues(link);
            return persistentLink;
        }
    }

    /// <summary>
    /// The Entity Framework Core implementation of <see cref="MUnique.OpenMU.DataModel.Entities.GuildMember"/>.
    /// </summary>
    internal partial class GuildMember
    {
        /// <summary>
        /// Gets or sets the character. This property just exists to define the foreign key.
        /// </summary>
        [ForeignKey(nameof(Id))]
        public Character Character { get; set; }
    }
}