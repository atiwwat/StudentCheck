using StudentCheck.DataAccess.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentCheck.DataAccess.Repository
{
   public class ReportRepository
    {
        public static List<CreateReport>GetReportData(StudentCheckDbContext dbContext)
        {
            var result = dbContext.ScheduleClass.Join(dbContext.Subjects, sc => sc.SubjectId, s => s.SubjectId, (sc, s) => new {sc, s })
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

        public static List<PageReport>GetPageReportData(StudentCheckDbContext dbContext)
        {
            var result = dbContext.CheckStudent.Join(dbContext.Qrcode, cs => cs.IdQr, qr => qr.IdQr, (cs, qr) => new { cs, qr })
               .Join(dbContext.StudentList, cs1 => cs1.cs.StudentId, sl => sl.StudentId, (cs1, sl) => new { cs1, sl })
               .Join(dbContext.ScheduleClass, cs2 => cs2.cs1.qr.ScheduleClassId, sc => sc.ScheduleClassId, (cs2, sc) => new { cs2, sc })
               .Join(dbContext.Subjects, cs3 => cs3.sc.SubjectId, s => s.SubjectId, (cs3, s) => new { cs3, s })
               .Join(dbContext.Professors, cs4 => cs4.cs3.sc.ProfessorsId, p => p.ProfessorsId, (cs4, p) => new { cs4, p })
               .Join(dbContext.FacultyProfessors, cs5 => cs5.p.FacultyIdP, f => f.FacultyIdP, (cs5, f) => new { cs5, f })
               .Join(dbContext.BranchProfessors, cs6 => cs6.cs5.p.BranchIdP, b => b.BranchIdP, (cs6, b) => new { cs6, b })
               .Join(dbContext.Day, cs7 => cs7.cs6.cs5.cs4.cs3.sc.DayId, d => d.DayId, (cs7, d) => new { cs7, d })
               //.Join(dbContext.FacultyProfessors, c8 => c8.cs7.cs6.cs5.p.)
               .Select(z => new PageReport
               {
               ScheduleClassId = z.cs7.cs6.cs5.cs4.cs3.sc.ScheduleClassId,
               SubjectId = z.cs7.cs6.cs5.cs4.cs3.sc.SubjectId,
               SubjectGroup = z.cs7.cs6.cs5.cs4.cs3.sc.SubjectGroup,
               SubjectNameThai = z.cs7.cs6.cs5.cs4.s.SubjectNameThai,
               SubjectCredit = z.cs7.cs6.cs5.cs4.s.SubjectCredit,
               Day = z.d.DayNameThai,
               ProfessorsId = z.cs7.cs6.cs5.cs4.cs3.sc.ProfessorsId,
               ProfessorsFirstname = z.cs7.cs6.cs5.p.ProfessorsFirstname,
               ProfessorsLastname = z.cs7.cs6.cs5.p.ProfessorsLastname,
               ProfessorsTel = z.cs7.cs6.cs5.p.ProfessorsTel,
               ProfessorsEmail = z.cs7.cs6.cs5.p.ProfessorsEmail,
               StudentId = z.cs7.cs6.cs5.cs4.cs3.cs2.cs1.cs.StudentId,
               StudentFirstname = z.cs7.cs6.cs5.cs4.cs3.cs2.sl.StudentFirstname,
               StudentLastname = z.cs7.cs6.cs5.cs4.cs3.cs2.sl.StudentLastname,
               StudentPrefix = z.cs7.cs6.cs5.cs4.cs3.cs2.sl.StudentPrefix,
               FacultyID = z.cs7.cs6.cs5.cs4.cs3.cs2.sl.FacultyId.Value,
               BranchID = z.cs7.cs6.cs5.cs4.cs3.cs2.sl.BranchId.Value,
               NumberClass = z.cs7.cs6.cs5.cs4.cs3.cs2.cs1.qr.NumberClass,
               Checkname = z.cs7.cs6.cs5.cs4.cs3.cs2.cs1.cs.IdQr,
               Satatus = z.cs7.cs6.cs5.cs4.cs3.cs2.cs1.cs.StatusId
               }).ToList();

            return result;


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
