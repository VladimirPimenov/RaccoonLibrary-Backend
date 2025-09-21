namespace RaccoonLibrary.ReaderLibrary.Domain.DTO
{
	public record BookAddingRequest
	{
		public int BookId { get; init; }

		public int ReaderId { get; init; }
	}
}
