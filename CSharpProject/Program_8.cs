using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Concurrent;

namespace CSharpProject
{
    class Program_8
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
        public class FeesCollection
        {
            public string studentId { get; set; }
            public string amountToPay { get; set; }
            public string fatherMobileNumber { get; set; }
            public string motherMobileNumber { get; set; }
        }
        public static void Main(string[] args)
        {
            string[] studentDetailsData = File.ReadAllLines(@"C:\Users\Nandita\Desktop\LinqAssignment\StudentDetails.csv").Skip(1).ToArray();
            string[] billStatementData = File.ReadAllLines(@"C:\Users\Nandita\Desktop\LinqAssignment\BillStatement.csv").Skip(1).ToArray();
            List<StudentDetails> students = new List<StudentDetails> { };
            List<BillStatement> billstatement = new List<BillStatement> { };
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
            var feesPaid = from s in students
                           join b in billstatement
                           on s.studentId equals b.studentId
                           where (Convert.ToInt32(b.amountToPay) - Convert.ToInt32(b.feesCollected)) == 0
                           select s.studentId + " " + s.firstName + " " + s.lastName;
            Console.WriteLine("\nName of students who have paid bus fees:\n");
            foreach (var row in feesPaid)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine("\nName of students who have not paid bus fees:\n");
            var feesNotPaid = from s in students
                              join b in billstatement
                              on s.studentId equals b.studentId
                              where (Convert.ToInt32(b.amountToPay) - Convert.ToInt32(b.feesCollected)) > 0
                              select s.studentId + " " + s.firstName + " " + s.lastName + " " + ((b.amountToPay - b.feesCollected) + 100);
            foreach (var row in feesNotPaid)
            {
                Console.WriteLine(row);
            }
            var newBillStatementTable = from s in students
                                        join b in billstatement
                                        on s.studentId equals b.studentId
                                        where (Convert.ToInt32(b.amountToPay) - Convert.ToInt32(b.feesCollected)) > 0
                                        select s.firstName + " " + s.fatherMobileNumber + " " + s.motherMobileNumber + " " + ((b.amountToPay - b.feesCollected) + 100);
            string[] colName = { "FirstName", "FatherMobileNumber", "MotherMobileNumber", "AmountToPay" };
            string columns = string.Join(";", colName);
            string newBillStatementData = columns + "\n";
            foreach (var i in newBillStatementTable)
            {
                newBillStatementData = newBillStatementData+i.Replace(' ', ';')+"\n";
            }
            File.WriteAllText(@"C:\Users\Nandita\Desktop\NewBillStatement.csv", newBillStatementData);
        }
    }
}