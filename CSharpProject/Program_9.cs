using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpProject
{
    class Program_9
    {
        public class StudentDetails
        {
            public int studentId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string fatherFirstName { get; set; }
            public string fatherLastName { get; set; }
            public long fatherMobileNumber { get; set; }
            public string motherFirstName { get; set; }
            public string motherLastName { get; set; }
            public long motherMobileNumber { get; set; }
            public string address { get; set; }
        }
        public class BillStatement
        {
            public int studentId { get; set; }
            public int amountToPay { get; set; }
            public int feesCollected { get; set; }
            public string datePaid { get; set; }
            public string busPickUppoint { get; set; }
            public string busNumber { get; set; }
            public string busDriverId { get; set; }

        }

        public class DriverDetails
        {
            public string driverId { get; set; }
            public string driverFirstName { get; set; }
            public string driverLastName { get; set; }
            public long driverMobileNumber { get; set; }
            public string drivingLicenseNumber { get; set; }
            public long aadharCard { get; set; }
            public long bankAccountNumber { get; set; }
            public string IFSCCode { get; set; }
        }
        public static void Main(string[] args)
        {
            string[] studentDetailsData = File.ReadAllLines(@"C:\Users\Nandita\Desktop\LinqAssignment\StudentDetails.csv").Skip(1).ToArray();
            string[] billStatementData = File.ReadAllLines(@"C:\Users\Nandita\Desktop\LinqAssignment\BillStatement.csv").Skip(1).ToArray();
            string[] driverDetailsData = File.ReadAllLines(@"C:\Users\Nandita\Desktop\LinqAssignment\DriverDetails.csv").Skip(1).ToArray();
            List<StudentDetails> students = new List<StudentDetails> { };
            List<BillStatement> billstatement = new List<BillStatement> { };
            List<DriverDetails> driverdetails = new List<DriverDetails> { };
            foreach (string line in studentDetailsData)
            {
                var rows = line.Split(";");
                students.Add(new StudentDetails()
                {
                    studentId = Convert.ToInt32(rows[0]),
                    firstName = rows[1].ToString(),
                    lastName = rows[2].ToString(),
                    fatherFirstName = rows[3].ToString(),
                    fatherLastName = rows[4].ToString(),
                    fatherMobileNumber = Convert.ToInt64(rows[5]),
                    motherFirstName = rows[6].ToString(),
                    motherLastName = rows[7].ToString(),
                    motherMobileNumber = Convert.ToInt64(rows[8]),
                    address = rows[9].ToString()
                });
            }
            foreach (string line in billStatementData)
            {
                string[] rows = line.Split(";");
                billstatement.Add(new BillStatement()
                {
                    studentId = Convert.ToInt32(rows[0]),
                    amountToPay = Convert.ToInt32(rows[1]),
                    feesCollected = Convert.ToInt32(rows[2]),
                    datePaid = rows[3].ToString(),
                    busPickUppoint = rows[4].ToString(),
                    busNumber = rows[5].ToString(),
                    busDriverId = rows[6].ToString()
                });
            }
            foreach (string line in driverDetailsData)
            {
                var rows = line.Split(";");
                driverdetails.Add(new DriverDetails()
                {
                    driverId = rows[0].ToString(),
                    driverFirstName = rows[1].ToString(),
                    driverLastName = rows[2].ToString(),
                    driverMobileNumber = Convert.ToInt64(rows[3]),
                    drivingLicenseNumber = rows[4].ToString(),
                    aadharCard = Convert.ToInt64(rows[5]),
                    bankAccountNumber = Convert.ToInt64(rows[6]),
                    IFSCCode = rows[7].ToString()
                });
            }
            var getDriverMobileNumber = from s in students
                              join b in billstatement on s.studentId equals b.studentId
                              join d in driverdetails on b.busDriverId equals d.driverId
                              where s.firstName == "Sathya" && s.lastName == "Sri"
                              select d.driverMobileNumber;
            
            Console.WriteLine("\nMobile number of driver who pick up Sathya Sri is\n");
            foreach (var i in getDriverMobileNumber)
                Console.WriteLine(i);
        }
    }
}
