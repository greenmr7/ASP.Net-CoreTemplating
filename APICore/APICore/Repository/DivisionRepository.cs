using APICore.Models;
using APICore.Repository.Interface;
using APICore.ViewModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APICore.Repository
{
    public class DivisionRepository : IDivisionRepository
    {
        IConfiguration _configuration;
        DynamicParameters parameters = new DynamicParameters();
        public DivisionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int Create(DivisionVM divisionVM, int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPInsertDivision";
                parameters.Add("Name", divisionVM.Name);
                parameters.Add("departmentId", divisionVM.departmentId);
                var insertDepartment = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return insertDepartment;
            }
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPDeleteDivision";
                parameters.Add("id", id);
                var DeleteDepartment = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return DeleteDepartment;
            }
        }

        //public IEnumerable<DivisionVM> getAll()
        //{
        //    using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
        //    {
        //        var procName = "SPGetAllDivision";
        //        var getAllDepartment = connection.Query<DivisionVM>(procName, commandType: CommandType.StoredProcedure);
        //        return getAllDepartment;
        //    }
        //}

        //public async Task<IEnumerable<DivisionVM>> getID(int Id)
        //{
        //    using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
        //    {
        //        var procName = "SPGetIdDivision";
        //        parameters.Add("id", Id);
        //        var getIdDepartment = await connection.QueryAsync<DivisionVM>(procName, parameters, commandType: CommandType.StoredProcedure);
        //        return getIdDepartment;
        //    };
        //}

        public int Update(DivisionVM divisionVM, int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPEditDivision";
                parameters.Add("id", id);
                parameters.Add("Name", divisionVM.Name);
                parameters.Add("departmentId", divisionVM.departmentId);
                var EditDepartment = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return EditDepartment;
            }
        }

        public async Task<IEnumerable<DivisionVM>> getAll()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPGetAllDivision";
                var getAllDepartment = await connection.QueryAsync<DivisionVM>(procName, commandType: CommandType.StoredProcedure);
                return getAllDepartment;
            }
        }

        public DivisionVM getID(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPGetIdDivision";
                parameters.Add("id", Id);
                var getIdDepartment = connection.Query<DivisionVM>(procName, parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return getIdDepartment;
            };
        }
    }
}
