using StudentCheck.DataAccess.Models;
using StudentCheck.DataAccess.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentCheck.DataAccess.Repository
{
    public static class ManageStudentRepository
    {

        public static List<StudentList> GetStudentList(StudentCheckDbContext context)
        {
            return context.StudentList.ToList();
        }

        public static void SaveStudent(StudentCheckDbContext context, CreateStudentModel modelToSave)
        {
            context.StudentList.Add(new StudentList
            {
                StudentId = modelToSave.StudentId,
                StudentFirstname = modelToSave.StudentFirstname,
                StudentLastname = modelToSave.StudentLastname,
                StudentEmail = modelToSave.StudentEmail,
                StudentTel = modelToSave.StudentTel,
                StudentPrefix = modelToSave.StudentPrefix,
                StudentLine = modelToSave.StudentLine,
                //StudentImg = modelToSave.StudentImg,
                StudentEducationStatus = modelToSave.StudentEducationStatus,
                StudentParentName = modelToSave.StudentParentName,
                StudentParentLastName = modelToSave.StudentParentLastName,
                StudentParentNumber = modelToSave.StudentParentNumber,
                StudentParentEmail = modelToSave.StudentParentEmail,
                StudentAddress = modelToSave.StudentAddress,
                StudentFacebook = modelToSave.StudentFacebook,
                StudentlineParent = modelToSave.StudentlineParent,
                FacultyId = modelToSave.FacultyId,
                BranchId = modelToSave.BranchId
                //PositionId = modelToSave.PositionId
            });

            context.SaveChanges();
        }

        public static void UpdateStudent(StudentCheckDbContext context, CreateStudentModel modelToUpdate)
        {
            var updateStudent = context.StudentList.Where(w => w.StudentId == modelToUpdate.StudentId).Single();
            updateStudent.StudentId = modelToUpdate.StudentId;
            updateStudent.StudentFirstname = modelToUpdate.StudentFirstname;
            updateStudent.StudentLastname = modelToUpdate.StudentLastname;
            updateStudent.StudentEmail = modelToUpdate.StudentEmail;
            updateStudent.StudentTel = modelToUpdate.StudentTel;
            updateStudent.StudentPrefix = modelToUpdate.StudentPrefix;
            updateStudent.StudentLine = modelToUpdate.StudentLine;
            //StudentImg = modelToSave.StudentImg,
            updateStudent.StudentEducationStatus = modelToUpdate.StudentEducationStatus;
            updateStudent.StudentParentName = modelToUpdate.StudentParentName;
            updateStudent.StudentParentLastName = modelToUpdate.StudentParentLastName;
            updateStudent.StudentParentNumber = modelToUpdate.StudentParentNumber;
            updateStudent.StudentParentEmail = modelToUpdate.StudentParentEmail;
            updateStudent.StudentAddress = modelToUpdate.StudentAddress;
            updateStudent.StudentFacebook = modelToUpdate.StudentFacebook;
            updateStudent.StudentlineParent = modelToUpdate.StudentlineParent;
            updateStudent.FacultyId = modelToUpdate.FacultyId;
            updateStudent.BranchId = modelToUpdate.BranchId;

            context.SaveChanges();
        }

        public static void DeleteStudent(StudentCheckDbContext context, string StudentId)
        {
            var itemToRemove = context.StudentList.Where(w => w.StudentId == StudentId).Single();
            context.StudentList.Remove(itemToRemove);

            context.SaveChanges();
        }

    }
}
