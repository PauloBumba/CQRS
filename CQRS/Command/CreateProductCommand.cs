using CQRS.Models;
namespace CQRS.Command
{
	public class CreateProductCommand
	{
		
		public string Name { get; set; } = string.Empty;

		public string Price { get; set; } = string.Empty;
	}
}