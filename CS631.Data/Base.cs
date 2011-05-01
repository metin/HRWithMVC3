using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public class Base
    {
        private MySqlConnection _connection = null;
        public MySqlConnection connection {
            get {
                return _connection;
            } 
        }
        public Base()
        {
            _connection = new MySqlConnection();
            _connection.ConnectionString = "Server=localhost;Database=cs631;Uid=ODBC;Pwd=;";
            //MySqlCommand cmd = c.CreateCommand();
            //cmd.CommandText = "Select * from tbl1";
            //c.Open();
            //cmd.ExecuteReader();
            //c.Close();
        }

        public static MySqlConnection getConnection()
        {
            MySqlConnection c = new MySqlConnection();
            c.ConnectionString = "Server=localhost;Database=cs631;Uid=ODBC;Pwd=;";
            return c;
        }

        public static void PopulateTestData()
        {
            Division d1 = new Division { DivName = "Acme Web" };
            d1.Save();
            Department dp1 = new Department { DeptName = "Acme Web Development", DivID = d1.DivID };
            dp1.Save();
            Department dp2 = new Department { DeptName = "Acme Web Marketing", DivID = d1.DivID };
            dp2.Save();
            Department dp3 = new Department { DeptName = "Acme Web Operations", DivID = d1.DivID };
            dp3.Save();
            Department dp4 = new Department { DeptName = "Acme Web HR", DivID = d1.DivID };
            dp4.Save();

            Division d2 = new Division { DivName = "Acme Publishing" };
            d2.Save();
            Department dp12 = new Department { DeptName = "Acme Publishing Development", DivID = d2.DivID };
            dp12.Save();
            Department dp22 = new Department { DeptName = "Acme Publishing Marketing", DivID = d2.DivID };
            dp22.Save();
            Department dp32 = new Department { DeptName = "Acme Publishing Operations", DivID = d2.DivID };
            dp32.Save();
            Department dp42 = new Department { DeptName = "Acme Publishing HR", DivID = d2.DivID };
            dp42.Save();

            Division d3 = new Division { DivName = "Acme Research" };
            d3.Save();
            Department dp13 = new Department { DeptName = "Acme Research Development", DivID = d3.DivID };
            dp13.Save();
            Department dp23 = new Department { DeptName = "Acme Research Marketing", DivID = d3.DivID };
            dp23.Save();
            Department dp33 = new Department { DeptName = "Acme Research Operations", DivID = d3.DivID };
            dp33.Save();
            Department dp43 = new Department { DeptName = "Acme Research HR", DivID = d3.DivID };
            dp43.Save();

            Building b1 = new Building { BuildingCode = "BLDG1", BuildingName = "A Hall", BuildingCost = 121123, YearAcquired = 1923 };
            b1.Save();
            Office o1 = new Office { BuildingID = b1.BuildingID, DeptID = dp1.DeptID, OfficeNumber = "346554", Area = 2323, RoomType = "O" };
            o1.Save();
            Office o6 = new Office { BuildingID = b1.BuildingID, DeptID = dp22.DeptID, OfficeNumber = "2346456", Area = 2323, RoomType = "O" };
            o6.Save();
            Office o11 = new Office { BuildingID = b1.BuildingID, DeptID = dp33.DeptID, OfficeNumber = "457897", Area = 2323, RoomType = "O" };
            o11.Save();

            Building b2 = new Building { BuildingCode = "BLDG2", BuildingName = "B Hall", BuildingCost = 129211123, YearAcquired = 1923 };
            b2.Save();
            Office o2 = new Office { BuildingID = b2.BuildingID, DeptID = dp2.DeptID, OfficeNumber = "5678", Area = 2323, RoomType = "O" };
            o2.Save();
            Office o7 = new Office { BuildingID = b2.BuildingID, DeptID = dp32.DeptID, OfficeNumber = "3245", Area = 2323, RoomType = "O" };
            o7.Save();
            Office o12 = new Office { BuildingID = b2.BuildingID, DeptID = dp43.DeptID, OfficeNumber = "6578", Area = 2323, RoomType = "O" };
            o12.Save();

            Building b3 = new Building { BuildingCode = "BLDG3", BuildingName = "C Hall", BuildingCost = 7821123, YearAcquired = 1983 };
            b3.Save();
            Office o3 = new Office { BuildingID = b3.BuildingID, DeptID = dp3.DeptID, OfficeNumber = "567", Area = 2323, RoomType = "O" };
            o3.Save();
            Office o8 = new Office { BuildingID = b3.BuildingID, DeptID = dp42.DeptID, OfficeNumber = "8675", Area = 2323, RoomType = "O" };
            o8.Save();

            Building b4 = new Building { BuildingCode = "BLDG4", BuildingName = "Building D", BuildingCost = 34121123, YearAcquired = 1973 };
            b4.Save();
            Office o4 = new Office { BuildingID = b4.BuildingID, DeptID = dp4.DeptID, OfficeNumber = "789", Area = 2323, RoomType = "O" };
            o4.Save();
            Office o9 = new Office { BuildingID = b3.BuildingID, DeptID = dp13.DeptID, OfficeNumber = "7689", Area = 2323, RoomType = "O" };
            o9.Save();

            Building b5 = new Building { BuildingCode = "BLDG5", BuildingName = "Building E", BuildingCost = 97521123, YearAcquired = 1993 };
            b5.Save();
            Office o5 = new Office { BuildingID = b5.BuildingID, DeptID = dp12.DeptID, OfficeNumber = "4356", Area = 2323, RoomType = "O" };
            o5.Save();
            Office o10 = new Office { BuildingID = b3.BuildingID, DeptID = dp23.DeptID, OfficeNumber = "5678", Area = 2323, RoomType = "O" };
            o10.Save();

            Employee e1 = new Employee { EmpFName = "John", EmpLName = "Doe", EmpBuilding = b1.BuildingID, EmpDept = dp1.DeptID, 
                                         EmpTitle = "Developer", EmpOffice = o1.OfficeID, EmpDiv = d1.DivID, EmpType = "S" };
            e1.Save();
            EmployeeSalary es1 = new EmployeeSalary { EmpID = e1.EmpID, AnnualSalary = 80000, SalaryStartDate = DateTime.Parse("1/1/2010") };
            es1.Save();
            EmployeeSalary es12 = new EmployeeSalary { EmpID = e1.EmpID, AnnualSalary = 85000, SalaryStartDate = DateTime.Parse("1/1/2011") };
            es12.Save();

            Employee e2 = new Employee { EmpFName = "Jack", EmpLName = "Doe", EmpBuilding = b2.BuildingID, EmpDept = dp2.DeptID, 
                                         EmpTitle = "Developer", EmpOffice = o2.OfficeID, EmpDiv = d2.DivID, EmpType = "S" };
            e2.Save();
            EmployeeSalary es2 = new EmployeeSalary { EmpID = e2.EmpID, AnnualSalary = 86000, SalaryStartDate = DateTime.Parse("1/1/2011") };
            es2.Save();

            Employee e3 = new Employee { EmpFName = "Jesse", EmpLName = "Mark", EmpBuilding = b2.BuildingID, EmpDept = dp2.DeptID, 
                                         EmpTitle = "DBA", EmpOffice = o2.OfficeID, EmpDiv = d2.DivID, EmpType = "S" };
            e3.Save();
            EmployeeSalary es3 = new EmployeeSalary { EmpID = e3.EmpID, AnnualSalary = 86000, SalaryStartDate = DateTime.Parse("1/1/2011") };
            es3.Save();

            Employee e4 = new Employee { EmpFName = "Martin", EmpLName = "Mark", EmpBuilding = b3.BuildingID, EmpDept = dp3.DeptID, 
                                         EmpTitle = "DBA", EmpOffice = o3.OfficeID, EmpDiv = d3.DivID, EmpType = "S" };
            e4.Save();
            EmployeeSalary es4 = new EmployeeSalary { EmpID = e4.EmpID, AnnualSalary = 86000, SalaryStartDate = DateTime.Parse("1/1/2011") };
            es4.Save();

            Project p1 = new Project { ProjDept = dp1.DeptID, ProjName = "Project A", StartDate = DateTime.Parse("1/1/2011"), ProjManager = e1.EmpID, ProjBudget=345632 };
            p1.Save();

            ProjectMember pm1 = new ProjectMember { EmpID = e1.EmpID, ProjID = p1.ProjID, StartDate = DateTime.Parse("2011-1-1"), Role = "Developer" };
            pm1.Save();
            ProjectMember pm2 = new ProjectMember { EmpID = e2.EmpID, ProjID = p1.ProjID, StartDate = DateTime.Parse("2011-1-1"), Role = "DBA" };
            pm2.Save();

            Milestone m1 = new Milestone { ProjID = p1.ProjID, MilestoneDeliverable = "Deliverable", MilestonePlannedDate = DateTime.Parse("1/15/2011"), 
                                                MilestoneDeliveryDate = DateTime.Parse("1/16/2011"), ToBeDelivered = "To Be deliveres" };
            m1.Save();
            Milestone m2 = new Milestone { ProjID = p1.ProjID, MilestoneDeliverable = "Deliverable of milestone 2", MilestonePlannedDate = DateTime.Parse("1/25/2011"), 
                                                MilestoneDeliveryDate = DateTime.Parse("1/27/2011"), ToBeDelivered = "To Be deliveres" };
            m2.Save();

            Bug bg1 = new Bug { ProjID = p1.ProjID, Status = "Open", Type = "Bug", DateReported = DateTime.Parse("4/27/2011"), Details = "This and that" };
            bg1.Save();
            Bug bg2 = new Bug { ProjID = p1.ProjID, Status = "Open", Type = "Request", DateReported = DateTime.Parse("4/27/2011"), Details = "This and that" };
            bg2.Save();
        }
    }
}