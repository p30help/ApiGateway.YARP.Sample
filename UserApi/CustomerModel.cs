namespace UserApi
{
    public class CustomerModel
    {
        public DateTime RecordDate { get; set; }

        public int UserId { get; set; }

        public int Age => 32 + (int)(UserId / 0.5556);

        public string? UserName { get; set; }
    }
}