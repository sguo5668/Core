namespace ConsoleRepo
{
    public static class RepositoryFactory
    {

        public static TRepository Create<TRepository>() where TRepository: class
        {
      
                    if (typeof(TRepository) == typeof(IStudentRepository))
                    {
                        return new StudentEFRepository() as TRepository;
                    }
                    return null;
               
         
        }
    }
}
