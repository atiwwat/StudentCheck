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
        public static List<FacultyProfessors> GetFacultyProfessorsList(StudentCheckDbContext context)
        {
            return context.FacultyProfessors.ToList();
        }
        public static List<BranchProfessors> GetBranchProfessorsList(StudentCheckDbContext context)
        {
            return context.BranchProfessors.ToList();
        }
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
                FacultyIdP = modelToSave.FacultyID_P,
                BranchIdP = modelToSave.BarnchID_P,
                PositionId = modelToSave.PositionId,
                ProfessorslineId = modelToSave.ProfessorslineId,
                ProfessorsFacebookId = modelToSave.ProfessorsFacebookId,
                //FacultyId =
            });

            context.SaveChanges();
        }

        public static void UpdateProfessor(StudentCheckDbContext context, CreateProfessorModel modelToUpdate)
        {
            var updateProfessor = context.Professors.Where(w => w.ProfessorsId == modelToUpdate.ProfessorsId).Single();
            updateProfessor.ProfessorsId = modelToUpdate.ProfessorsId;
            updateProfessor.PositionId = modelToUpdate.PositionId;
            updateProfessor.ProfessorsFirstname = modelToUpdate.ProfessorsFirstname;
            updateProfessor.ProfessorsLastname = modelToUpdate.ProfessorsLastname;
            updateProfessor.FacultyIdP = modelToUpdate.FacultyID_P;
            updateProfessor.BranchIdP = modelToUpdate.BarnchID_P;
            updateProfessor.ProfessorsTel = modelToUpdate.ProfessorsTel;
            updateProfessor.ProfessorsEmail = modelToUpdate.ProfessorsEmail;
            updateProfessor.ProfessorsFacebookId = modelToUpdate.ProfessorsFacebookId;
            updateProfessor.ProfessorslineId = modelToUpdate.ProfessorslineId;

            context.SaveChanges();
        }

        public static void DeleteProfessor(StudentCheckDbContext context, string ProfessorId)
        {
            var itemToRemove = context.Professors.Where(w => w.ProfessorsId == ProfessorId).Single();
            context.Professors.Remove(itemToRemove);

            context.SaveChanges();
        }

    }
}
