using System.Security.Cryptography;
using System.Text;

namespace AutoGear.Identity.Utils;

public class PasswordHasher
{
    public string HashPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentNullException(nameof(password), "Входная строка должна содержать значение отличное от null");

        byte[] hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }

    public bool VerifyPasswordHash(string hashedPassword, string providedPassword)
    {
        if (hashedPassword == null)
            throw new ArgumentNullException(nameof(hashedPassword));
        
        if (providedPassword == null)
            throw new ArgumentNullException(nameof(providedPassword));

        byte[] decodedHashedPassword = Convert.FromBase64String(hashedPassword);

        using var hmac = new HMACSHA256(decodedHashedPassword);
        byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(providedPassword));
        
        return SlowEquals(decodedHashedPassword, computedHash);
    }

    private bool SlowEquals(byte[] a, byte[] b)
    {
        uint diff = (uint)a.Length ^ (uint)b.Length;

        for (int i = 0; i < a.Length && i < b.Length; i++)
            diff |= (uint)(a[i] ^ b[i]);
        
        return diff == 0;
    }
}
