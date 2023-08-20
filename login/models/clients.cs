namespace login.models
{
    public class clients : user
    {
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
