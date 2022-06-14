namespace JsonResponseClient.Interfaces
{
	public interface IJsonResponseClient
	{
		T DeserializeResponse<T>(string response);
		string SerializeResponse<T>(T model);
	}
}