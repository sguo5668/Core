namespace MoviesAPIStore.Repository
{
    public interface IValidateRequest
    {
        bool ValidateKeys(string Key);

        bool IsValidServiceRequest(string Key, string ServiceName);

        bool ValidateIsServiceActive(string Key);

      //  bool CalculateCountofRequest(string Key);
    }
}
