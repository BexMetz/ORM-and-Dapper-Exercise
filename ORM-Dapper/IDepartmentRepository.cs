using System;
using System.Collections.Generic;
namespace ORM_Dapper
{
	public interface IDepartmentRepository
	{
		public IEnumerable<Department> GetAllDepartments();

		public void CreateDepartment(string name);

		public void UpdateDepartment(int id, string newName);
	}
}

