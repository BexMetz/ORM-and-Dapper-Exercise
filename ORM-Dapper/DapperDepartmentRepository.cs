using System;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
	public class DapperDepartmentRepository : IDepartmentRepository
	{
		private readonly IDbConnection _connection;

		public DapperDepartmentRepository(IDbConnection connection)
		{
			_connection = connection;
		}

        public IEnumerable<Department> GetDepartments()
        {
            return _connection.Query<Department>("Select * FROM departments;");
        }

        public void CreateDepartment(string name)
        {
            _connection.Execute("INSERT INTO departments Name Values(@name);", new { name = name });
        }

        public void UpdateDepartment(int id, string newName)
        {
            _connection.Execute("UPDATE departments SET Name = @newName WHERE DepartmentID = @id;", new { newName = newName, id = id });
        }
    }
}

