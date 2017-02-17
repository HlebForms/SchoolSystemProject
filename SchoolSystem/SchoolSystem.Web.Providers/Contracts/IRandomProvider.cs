namespace SchoolSystem.Web.Providers.Contracts
{
    public interface IRandomProvider
    {
        int GetRandomNumber(int min, int max);
    }
}
