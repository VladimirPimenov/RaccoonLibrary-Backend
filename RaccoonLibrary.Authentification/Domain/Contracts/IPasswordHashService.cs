namespace RaccoonLibrary.Authentification.Domain.Contracts
{
	public interface IPasswordHashService
	{
		public string HashPassword(string password);

		public bool VerifyPassword(string password, string hashedPassword);
	}
}
