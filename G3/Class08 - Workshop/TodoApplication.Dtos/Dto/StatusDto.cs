﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication.Dtos.Dto {
	public class StatusDto {
		public int Id { get; set; }
		public string Name { get; set; }
        public bool IsSelected { get; set; }

	}
}
