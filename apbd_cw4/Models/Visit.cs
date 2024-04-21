using System;
namespace cw4_s24798.Models
{
	public class Visit
	{
		public DateOnly Date { get; set; }
		public int Id { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }

		public Visit()
		{
		}
	}
}

