using SmartSchool.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Aluno[] GetAllAlunos(bool incluiProfessor = false);
        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool incluiProfessor = false);
        Aluno GetAlunoById(int alunoId, bool incluiProfessor = false);
        Professor[] GetAllProfessores(bool incluiAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool incluiAlunos = false);
        Professor GetProfessorById(int professorId, bool incluiAlunos = false);



    }
}
