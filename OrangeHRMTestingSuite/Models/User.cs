using OrangeHRMTestingSuite.Interfaces;

namespace OrangeHRMTestingSuite.Models
{
	internal class User : IUser
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string? Nationality { get; set; }

		public User(string userName, string password)
		{
			if (string.IsNullOrEmpty(userName))
				throw new ArgumentException($"'{nameof(userName)}' cannot be null or empty.", nameof(userName));
			if (string.IsNullOrEmpty(password))
				throw new ArgumentException($"'{nameof(password)}' cannot be null or empty.", nameof(password));

			UserName = userName;
			Password = password;
		}
	}
}
