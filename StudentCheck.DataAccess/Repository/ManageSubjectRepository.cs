using StudentCheck.DataAccess.Models;
using StudentCheck.DataAccess.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentCheck.DataAccess.Repository
{
    public class ManageSubjectRepository
    {
        public static List<Subjects> GetSubjects(StudentCheckDbContext context)
        {
            return context.Subjects.ToList();
        }
        public static void SaveSubject(StudentCheckDbContext context, CreateSubjectModel modelToSave)
        {
            context.Subjects.Add(new Subjects
            {
                SubjectId = modelToSave.SubjectId,
                SubjectNameThai = modelToSave.SubjectNameThai,
                SubjectNameEng = modelToSave.SubjectNameEng,
                SubjectCredit = modelToSave.SubjectCredit
            });

            context.SaveChanges();
        }

        public static void UpdateSubject(StudentCheckDbContext context, CreateSubjectModel modelToUpdate)
        {
            var updateSubject = context.Subjects.Where(w => w.SubjectId == modelToUpdate.SubjectId).Single();
            updateSubject.SubjectId = modelToUpdate.SubjectId;
            updateSubject.SubjectNameThai = modelToUpdate.SubjectNameThai;
            updateSubject.SubjectNameEng = modelToUpdate.SubjectNameEng;
            updateSubject.SubjectCredit = modelToUpdate.SubjectCredit;
            
            context.SaveChanges();
        }

        public static void DeleteSubject(StudentCheckDbContext context, string SubjectId)
        {
            var itemToRemove = context.Subjects.Where(w => w.SubjectId == SubjectId).Single();
            context.Subjects.Remove(itemToRemove);

            context.SaveChanges();
        }

    }
}