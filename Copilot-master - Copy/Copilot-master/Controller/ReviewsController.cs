using YourNamespace.Model;
using YourNamespace.Services;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewsController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public ActionResult<List<Reviews>> Get() =>
            _reviewService.Get();

        [HttpGet("{id:length(24)}", Name = "GetReview")]
        public ActionResult<Reviews> Get(string id)
        {
            var review = _reviewService.GetByProperty(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        [HttpPost]
        public ActionResult<Reviews> Create(Reviews review)
        {
            _reviewService.Create(review);

            return CreatedAtRoute("GetReview", new { id = review.Id.ToString() }, review);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Reviews reviewIn)
        {
            var review = _reviewService.Get(id);

            if (review == null)
            {
                return NotFound();
            }

            _reviewService.Update(id, reviewIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var review = _reviewService.Get(id);

            if (review == null)
            {
                return NotFound();
            }

            _reviewService.Remove(review.Id);

            return NoContent();
        }
    }
}
