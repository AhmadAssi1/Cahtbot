namespace login.models
{
    public class Agents : user
        
    {
        public int EmployeeId { get; set; }
        public bool OnDutyStatus { get; set; }
        public int WorkingHours { get; set; }
    }
}
