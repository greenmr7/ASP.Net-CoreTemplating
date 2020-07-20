using APICore.Context;
using APICore.Models;
using APICore.Repository.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APICore.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        IConfiguration _configuration;
        DynamicParameters parameters = new DynamicParameters();

        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Create(Department department)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPInsertDepartment";
                parameters.Add("Name", department.Name);
                var insertDepartment = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return insertDepartment;
            }
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPDeleteDepartment";
                parameters.Add("id", id);
                var DeleteDepartment = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return DeleteDepartment;
            }
        }

        //public IEnumerable<Department> getAll()
        //{
        //    using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
        //    {
        //        var procName = "SPGetAllDepartment";
        //        var getAllDepartment = connection.Query<Department>(procName, commandType: CommandType.StoredProcedure);
        //        return getAllDepartment;
        //    }
        //}

        //public async Task<IEnumerable<Department>> getID(int Id)
        //{
        //    using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
        //    {
        //        var procName = "SPGetIdDepartment";
        //        parameters.Add("id", Id);
        //        var getIdDepartment = await connection.QueryAsync<Department>(procName, parameters, commandType: CommandType.StoredProcedure);
        //        return getIdDepartment;
        //    }
        //}



        public int Update(Department department, int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPEditDepartment";
                parameters.Add("id", id);
                parameters.Add("Name", department.Name);
                var EditDepartment = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return EditDepartment;
            }
        }

        public async Task<IEnumerable<Department>> getAll()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPGetAllDepartment";
                var getAllDepartment = await connection.QueryAsync<Department>(procName, commandType: CommandType.StoredProcedure);
                return getAllDepartment;
            }
        }

        public Department getID(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPGetIdDepartment";
                parameters.Add("id", Id);
                var getIdDepartment = connection.Query<Department>(procName, parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return getIdDepartment;
            }
        }
    }
}
