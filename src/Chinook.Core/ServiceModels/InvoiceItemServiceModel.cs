namespace Chinook.Core.ServiceModels
{
    public partial class InvoiceItemServiceModel
    {
        public long InvoiceLineId { get; set; }
        public long InvoiceId { get; set; }
        public long TrackId { get; set; }
        public byte[] UnitPrice { get; set; }
        public long Quantity { get; set; }

        public virtual InvoiceServiceModel Invoice { get; set; }
        public virtual TrackServiceModel Track { get; set; }
    }
}
