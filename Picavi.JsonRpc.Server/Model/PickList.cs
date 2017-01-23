// <copyright file="Picklist.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// class Pick list
    /// </summary>
    public class Picklist
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Picklist"/> class.
        /// </summary>
        public Picklist()
        {
            this.Lines = new List<Pickline>();
        }

        // public Properties

        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public string Ident { get; set; }

        /// <summary>
        /// Gets or sets Lines
        /// </summary>
        public List<Pickline> Lines { get; set; }
    }

    /// <summary>
    /// class Pick line
    /// </summary>
    public class Pickline
    {
        // public Properties

        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public string Ident { get; set; }

        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets Item
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets Unit
        /// </summary>
        public string Unit { get; set; }
    }
}
