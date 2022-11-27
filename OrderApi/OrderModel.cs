namespace OrderApi
{
    public class OrderModel
    {
        public DateTime Date { get; set; }

        public int Code { get; set; }

        public int CodeInternal => 32 + (int)(Code / 0.5556);

        public string? ProductName { get; set; }
    }
}