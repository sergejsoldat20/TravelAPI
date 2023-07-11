using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using TravelAPI.Contracts;


namespace TravelAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DestinationController : ControllerBase
	{
		private IDestinationRepository _destinationRepository { get; set; }

        public DestinationController(IDestinationRepository destinationRepository)
        {
            this._destinationRepository = destinationRepository;
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAync([FromRoute] int id)
		{

			throw new Exception("pOruka");
			var result = await _destinationRepository.GetByConditionAsync(x => x.Id == id);

			if (result is not null)
			{
				return Ok(result);
			}

			return NotFound();
		}
    }
}
