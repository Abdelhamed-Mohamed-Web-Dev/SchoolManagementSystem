
namespace Shared.ErrorModels
{
	public class ValidationErrorResponse
	{
		public int StatusCode { get; set; }
		public string ErrorMassage { get; set; }
		public IEnumerable<ValidationError> Errors { get; set; }
	}
	public class ValidationError
	{
		public string Field { get; set; }
		public IEnumerable<string> ErrorsDescription { get; set; }

	}
}
