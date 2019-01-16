using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using eMMA.Entities;
using eMMA.Uni.Professor.Dto;

namespace eMMA.Uni.Professor
{
    public class ProfessorAppService : AsyncCrudAppService<Entities.Professor, ProfessorDto, Guid, PagedResultRequestDto, ProfessorDto, ProfessorDto>, IProfessorAppService
    {
        private IRepository<ProfessorUniSubjects, Guid> _professorUniSubjectsRepository;
        public ProfessorAppService(IRepository<Entities.Professor, Guid> repository, IRepository<ProfessorUniSubjects, Guid> professorUniSubjectsRepository) : base(repository)
        {
            _professorUniSubjectsRepository = professorUniSubjectsRepository;
        }

        public ProfessorDto UpdateSync(ProfessorDto input)
        {
            var prof = ObjectMapper.Map<Entities.Professor>(input);

            var updatedProf = Repository.Update(prof);

            var presentSubj = _professorUniSubjectsRepository.GetAll().Where(x => x.ProfessorId == prof.Id).OrderBy(s => s.UniSubjectId).ToList();

            if (prof.ObjectList.Count > 0)
            {
                //add all
                if (presentSubj.Count == 0)
                {
                    foreach (var professorUniSubjectse in prof.ObjectList)
                    {
                        _professorUniSubjectsRepository.Insert(professorUniSubjectse);
                    }
                }
                else
                {
                    foreach (var professorUniSubjectse in prof.ObjectList)
                    {
                        if (presentSubj.SingleOrDefault(s => s.UniSubjectId == professorUniSubjectse.UniSubjectId) == null)
                        {
                            _professorUniSubjectsRepository.Insert(professorUniSubjectse);
                        }
                    }
                }

            }

            //Remove
            foreach (var professorUniSubjectse in presentSubj)
            {
                if (prof.ObjectList.SingleOrDefault(s => s.UniSubjectId == professorUniSubjectse.UniSubjectId) == null)
                {
                    _professorUniSubjectsRepository.Delete(professorUniSubjectse);
                }
            }
            return ObjectMapper.Map<ProfessorDto>(updatedProf);
        }

        public async Task<Entities.Professor> GetProfessorUserByAuthUserIdAsync(long id)
        {
            var profList = await Repository.GetAllListAsync(p => p.UserId == id);

            var prof = profList.FirstOrDefault();
            //get subjects
            var subjects = await _professorUniSubjectsRepository.GetAllListAsync(x => x.ProfessorId == prof.Id);
            if (prof != null && subjects != null)
            {
                prof.ObjectList = subjects;
            }
            return prof;

        }
    }
}
