namespace OrangeHRMTestingSuite.Interfaces
{
	internal interface IUser
	{
		int Id { get; set; }
		string? Nationality { get; set; }
		string Password { get; set; }
		string UserName { get; set; }
	}
}