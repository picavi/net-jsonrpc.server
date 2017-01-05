namespace Picavi.JsonRpc.Server.Model
{
    using System.Collections.Generic;

    public class Picklist
    {
        // Constructors

        public Picklist()
        {
            this.Lines = new List<Pickline>();
        }

        // public Properties

        public string Ident { get; set; }

        public List<Pickline> Lines { get; set; }
    }

    public class Pickline
    {
        // public Properties

        public string Ident { get; set; }

        public string Location { get; set; }

        public string Item { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }
    }
}
