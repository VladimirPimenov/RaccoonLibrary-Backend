using System.Text.Json.Serialization;

namespace RaccoonLibrary.Bookshelf.Domain.Enums
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum SearchType
	{
		General,
		BookTitle,
		AuthorLastName,
		PublisherName,
		GenreName
	}
}
