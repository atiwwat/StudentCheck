using Microsoft.Extensions.Configuration;
using StudentCheck.DataAccess.ModelViews;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StudentCheck.DataAccess.Repository
{
    public class ReportRepository
    {
        public static List<CreateReport> GetReportData(StudentCheckDbContext dbContext)
        {
            var result = dbContext.ScheduleClass.Join(dbContext.Subjects, sc => sc.SubjectId, s => s.SubjectId, (sc, s) => new { sc, s })
                .Join(dbContext.Day, sc1 => sc1.sc.DayId, d => d.DayId, (sc1, d) => new { sc1, d })
                .Select(x => new CreateReport
                {
                    ScheduleClassId = x.sc1.sc.ScheduleClassId,
                    SubjectId = x.sc1.sc.SubjectId,
                    SubjectGroup = x.sc1.sc.SubjectGroup,
                    SubjectNameThai = x.sc1.s.SubjectNameThai,
                    SubjectCredit = x.sc1.s.SubjectCredit,
                    Day = x.d.DayNameThai
                }).ToList();
            return result;
        }

        //public static List<PageReport> GetPageReportData(StudentCheckDbContext dbContext)
        //{
        //    var result = dbContext.CheckStudent.Join(dbContext.Qrcode, cs => cs.IdQr, qr => qr.IdQr, (cs, qr) => new { cs, qr })
        //       .Join(dbContext.StudentList, cs1 => cs1.cs.StudentId, sl => sl.StudentId, (cs1, sl) => new { cs1, sl })
        //       .Join(dbContext.ScheduleClass, cs2 => cs2.cs1.qr.ScheduleClassId, sc => sc.ScheduleClassId, (cs2, sc) => new { cs2, sc })
        //       .Join(dbContext.Subjects, cs3 => cs3.sc.SubjectId, s => s.SubjectId, (cs3, s) => new { cs3, s })
        //       .Join(dbContext.Professors, cs4 => cs4.cs3.sc.ProfessorsId, p => p.ProfessorsId, (cs4, p) => new { cs4, p })
        //       .Join(dbContext.FacultyProfessors, cs5 => cs5.p.FacultyIdP, f => f.FacultyIdP, (cs5, f) => new { cs5, f })
        //       .Join(dbContext.BranchProfessors, cs6 => cs6.cs5.p.BranchIdP, b => b.BranchIdP, (cs6, b) => new { cs6, b })
        //       .Join(dbContext.Day, cs7 => cs7.cs6.cs5.cs4.cs3.sc.DayId, d => d.DayId, (cs7, d) => new { cs7, d })
        //       //.Join(dbContext.FacultyProfessors, c8 => c8.cs7.cs6.cs5.p.)
        //       .Select(z => new PageReport
        //       {
        //           ScheduleClassId = z.cs7.cs6.cs5.cs4.cs3.sc.ScheduleClassId,
        //           SubjectId = z.cs7.cs6.cs5.cs4.cs3.sc.SubjectId,
        //           SubjectGroup = z.cs7.cs6.cs5.cs4.cs3.sc.SubjectGroup,
        //           SubjectNameThai = z.cs7.cs6.cs5.cs4.s.SubjectNameThai,
        //           SubjectCredit = z.cs7.cs6.cs5.cs4.s.SubjectCredit,
        //           Day = z.d.DayNameThai,
        //           ProfessorsId = z.cs7.cs6.cs5.cs4.cs3.sc.ProfessorsId,
        //           ProfessorsFirstname = z.cs7.cs6.cs5.p.ProfessorsFirstname,
        //           ProfessorsLastname = z.cs7.cs6.cs5.p.ProfessorsLastname,
        //           ProfessorsTel = z.cs7.cs6.cs5.p.ProfessorsTel,
        //           ProfessorsEmail = z.cs7.cs6.cs5.p.ProfessorsEmail,
        //           StudentId = z.cs7.cs6.cs5.cs4.cs3.cs2.cs1.cs.StudentId,
        //           StudentFirstname = z.cs7.cs6.cs5.cs4.cs3.cs2.sl.StudentFirstname,
        //           StudentLastname = z.cs7.cs6.cs5.cs4.cs3.cs2.sl.StudentLastname,
        //           StudentPrefix = z.cs7.cs6.cs5.cs4.cs3.cs2.sl.StudentPrefix,
        //           FacultyName = z.cs7.cs6.cs5.cs4.cs3.cs2.sl.FacultyId.ToString(),
        //           BranchName = z.cs7.cs6.cs5.cs4.cs3.cs2.sl.BranchId.ToString(),
        //           NumberClass = z.cs7.cs6.cs5.cs4.cs3.cs2.cs1.qr.NumberClass,
        //           Checkname = z.cs7.cs6.cs5.cs4.cs3.cs2.cs1.cs.IdQr,
        //           Satatus = z.cs7.cs6.cs5.cs4.cs3.cs2.cs1.cs.StatusId
        //       }).ToList();

        //    return result;


        //}

        //public static List<PageReport> GetPageReportDataNew(StudentCheckDbContext dbContext)
        //{
        //    var result = dbContext.Faculty.Join(dbContext.StudentList, faculty => faculty.FacultyId, studentList => studentList.FacultyId, (faculty, studentList) => new { faculty, studentList })
        //        .Join(dbContext.Branch, obj1 => obj1.studentList.BranchId, branch => branch.BranchId, (obj1, branch) => new { obj1, branch })
        //        .Join(dbContext.Register, obj2 => obj2.obj1.studentList.StudentId, register => register.StudentId, (obj2, register) => new { obj2, register })
        //        .GroupJoin(dbContext.ScheduleClass, obj3 => obj3.register.ScheduleClassId, scheduleClass => scheduleClass.ScheduleClassId, (obj3, scheduleClass) => new { obj3, scheduleClass })
        //        .Select(s => new PageReport
        //    {
        //        BranchName = s.obj3.obj2.branch.BranchName,
        //        FacultyName = s.obj3.obj2.obj1.faculty.Facultyname

        //    }).ToList();
        //    return result;
        //}

        public static List<PageReport> GetPageReportDataNew(IConfiguration configuration, StudentCheckDbContext dbContext)
        {
            List<PageReport> pageReportList = new List<PageReport>();

            using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("StudentCheckContext")))
            {
                string cmdText = string.Empty;
                cmdText += "SELECT Subjects.SubjectNameThai, Subjects.SubjectID, Subjects.SubjectCredit, ScheduleClass.Schedule_Class_Id, ScheduleClass.SubjectGroup, ScheduleClass.YearStudy, ScheduleClass.Semester, ";
                cmdText += "Day.DayName_Thai, Professors.ProfessorsID, Professors.ProfessorsFirstname, Professors.ProfessorsLastname, Professors.ProfessorsEmail, Professors.ProfessorsTel, Position.PositionName, ";
                cmdText += "FacultyProfessors.Facultyname_P, BranchProfessors.BrachName_P, Faculty.Facultyname, Branch.BranchName, StudentList.StudentId, StudentList.StudentFirstname, StudentList.StudentLastname, ";
                cmdText += "Register.AttendClass, Register.Absent FROM Faculty INNER JOIN StudentList ON Faculty.FacultyID = StudentList.FacultyID INNER JOIN Branch ON StudentList.BranchID = Branch.BranchID INNER JOIN ";
                cmdText += "Register ON StudentList.StudentId = Register.StudentId RIGHT OUTER JOIN ScheduleClass INNER JOIN FacultyProfessors INNER JOIN Professors ON FacultyProfessors.FacultyID_P = Professors.FacultyID_P INNER JOIN ";
                cmdText += "BranchProfessors ON Professors.BranchID_P = BranchProfessors.BranchId_P ON ScheduleClass.ProfessorsID = Professors.ProfessorsID INNER JOIN Position ON Professors.PositionID = Position.PositionID ON Register.Schedule_Class_Id = ScheduleClass.Schedule_Class_Id LEFT OUTER JOIN Day ON ScheduleClass.Day_id = Day.Day_id LEFT OUTER JOIN Subjects ON ScheduleClass.SubjectID = Subjects.SubjectID WHERE ScheduleClass.Schedule_Class_Id = '1112'";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PageReport pageReport = new PageReport();
                    pageReport.SubjectId = reader["TenMon"].ToString();
                    pageReport.SubjectGroup = reader["LoaiMon"].ToString();
                    pageReportList.Add(pageReport);
                }

            }

            return pageReportList;
        }
    }
}
//.Select(m => new { 
//       ProdId = m.ppc.p.Id, // or m.ppc.pc.ProdId
//       CatId = m.c.CatId
//       // other assignments
//   });

//var startingDeck = Suits().SelectMany(suit => Ranks().Select(rank => new { Suit = suit, Rank = rank }));

//var data = dbContext.Qrcode.Join(dbContext.CheckStudent, qr => qr.IdQr, cs => cs.IdQr, (qr, cs) => new {qr, cs })
//    .Join(dbContext.)


//var data = dbContext.ScheduleClass.Join(dbContext.Professors, sc => sc.ProfessorsId, p => p.ProfessorsId, (sc, p) => new { sc, p })
//    .Join(dbContext.Subjects, sc1 => sc1.sc.SubjectId, sl => sl.SubjectId, (sc1, sl) => new { sc1, sl })
//    .Join(dbContext.Day, sc2 => sc2.sc1.sc.DayId, d => d.DayId, (sc2, d) => new { sc2, d })
