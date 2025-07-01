using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApplication.Dtos.Dto;

namespace TodoApplication.Services.Interfaces {
	public interface IFilterService {
		List<CategoryDto> GetCategories();
		List<StatusDto>GetStatuses();
	}
}
