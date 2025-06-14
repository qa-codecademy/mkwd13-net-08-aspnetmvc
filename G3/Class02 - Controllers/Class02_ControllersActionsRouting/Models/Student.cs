using System.ComponentModel.DataAnnotations;

namespace Class02_ControllersActionsRouting.Models {
	public class Student {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}
