using StudentCheck.DataAccess.Models;
using StudentCheck.DataAccess.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentCheck.DataAccess.Repository
{
    public static class ManageProfessorRepository
    {
        public static List<Position> GetPositionList(StudentCheckDbContext context)
        {
            return context.Position.ToList();
        }

        public static List<Professors> GetProfessorList(StudentCheckDbContext context)
        {
            return context.Professors.ToList();
        }

        public static void SaveProfessor(StudentCheckDbContext context, CreateProfessorModel modelToSave)
        {
            context.Professors.Add(new Professors
            {
                ProfessorsId = modelToSave.ProfessorsId,
                ProfessorsFirstname = modelToSave.ProfessorsFirstname,
                ProfessorsLastname = modelToSave.ProfessorsLastname,
                ProfessorsEmail = modelToSave.ProfessorsEmail,
                ProfessorsTel = modelToSave.ProfessorsTel,
                ProfessorsFacultys = modelToSave.ProfessorsFacultys,
                ProfessorsBranch = modelToSave.ProfessorsBranch,
                PositionId = modelToSave.PositionId,
                ProfessorslineId = modelToSave.ProfessorslineId,
                ProfessorsFacebookId = modelToSave.ProfessorsFacebookId,
                //FacultyId =
            });

            context.SaveChanges();
        }
    }
}
