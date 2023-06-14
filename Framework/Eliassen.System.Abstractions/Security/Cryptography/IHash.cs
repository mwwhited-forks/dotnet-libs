namespace Eliassen.System.Security.Cryptography
{
    public interface IHash
    {
        string GetHash(string value);
    }
}