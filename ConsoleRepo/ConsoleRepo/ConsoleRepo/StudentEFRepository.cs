using ConsoleRepo;
using ConsoleRepo.DomainObjecs;
 

namespace ConsoleRepo
{

    public  class StudentEFRepository: EFRepositoryBase<SchoolContext, Student, int>, IStudentRepository
    {

    }
}
