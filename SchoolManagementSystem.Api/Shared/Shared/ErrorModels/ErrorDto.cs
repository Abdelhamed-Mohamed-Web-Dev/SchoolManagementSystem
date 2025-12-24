
namespace Shared.ErrorModels
{
	public class ErrorDto
	{
        public int StatusCode { get; set; }
		public string Message { get; set; }
        public IEnumerable<string>? Errors { get; set; }
	}
}
