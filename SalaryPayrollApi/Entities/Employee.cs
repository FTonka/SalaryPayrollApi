namespace SalaryPayrollApi.Entities
{
	public class Employee
	{
        public int ID { get; set; }
        public string TurkishIDNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
		public int WorkType{ get; set; }
		public int? WorkedDays { get; set; }
		public decimal? DailyWage { get; set; }
		public int? OvertimeHours { get; set; }
		public decimal? OvertimeRate { get; set; }
		


    }
}
