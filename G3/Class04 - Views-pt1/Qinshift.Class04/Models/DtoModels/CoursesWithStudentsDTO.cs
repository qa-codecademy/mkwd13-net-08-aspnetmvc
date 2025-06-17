namespace Qinshift.Class04.Models.DtoModels {
	public class CoursesWithStudentsDTO {
		 public CoursesWithStudentsDTO() {
			Students = new List<StudentDTO>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public List<StudentDTO> Students{ get; set; }
	}
}
