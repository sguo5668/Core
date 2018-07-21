using System;
using ConsoleRepo.DomainObjecs;

namespace ConsoleRepo
{
    class Program
    {
        static void Main(string[] args)
        {

			Student student = new Student();
			System.Console.Write("Name: ");
			student.Name = System.Console.ReadLine();
			System.Console.Write("SurName: ");
			student.SurName = System.Console.ReadLine();
			System.Console.Write("Classroom: ");
			student.Classroom = System.Console.ReadLine();

			IStudentRepository source1 = null;
			source1 = RepositoryFactory.Create<IStudentRepository>();
			source1.Insert(student);


			var source2 = RepositoryFactory.Create<IStudentRepository>();
			var items = source2.GetAll();
			foreach (var item in items)
			{
				System.Console.WriteLine(item.Name + " " + item.SurName + ": " + item.Classroom);
			}


		}
    }
}
