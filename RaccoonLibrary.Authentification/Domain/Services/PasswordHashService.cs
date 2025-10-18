using System.Security.Cryptography;
using System.Text;

using RaccoonLibrary.Authentification.Domain.Contracts;

namespace RaccoonLibrary.Authentification.Domain.Services
{
	public class PasswordHashService: IPasswordHashService
	{
		public string HashPassword(string password)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(password);
			byte[] hashed = SHA256.HashData(bytes);

			return Convert.ToHexString(hashed);
		}

		public bool VerifyPassword(string password, string hashedPassword)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(password);
			byte[] hashed = SHA256.HashData(bytes);

			var hashValue = Convert.FromHexString(hashedPassword);

			return hashValue.SequenceEqual(hashed);
		}
	}

}
