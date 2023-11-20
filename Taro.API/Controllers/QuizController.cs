using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taro.Core.Entities.Models.CourseModels;
using Taro.Repository.Context;

namespace Taro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly AppDbContext _context;
        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add Question
        /// </summary>
        /// <response code="200">Added Successfully </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpPost("AddQuestion")]
        public async Task<IActionResult> AddQuestion([FromForm] String Q)
        {

            await _context.AddAsync(Q);
            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Add Answer
        /// </summary>
        /// <response code="200">Added Successfully </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpPost("AddAnswer")]
        public async Task<IActionResult> AddAnswer([FromForm] String Q)
        {
            await _context.AddAsync(Q);
            _context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Add Quiz
        /// </summary>
        /// <response code="200">Added Successfully </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpPost("AddQuiz")]
        public async Task<IActionResult> AddQuiz(int id, string Q, string A)
        {
            var quiz = new Quiz
            {
                Id = id,
                A = A,
                Q = Q
            };

            return Ok(quiz);
        }

        /// <summary>
        /// Get Qiuz
        /// </summary>
        /// <response code="200">Added Successfully </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpGet("viewQuiz={id}")]
        public async Task<IActionResult> viewQuiz(int id)
        {
            var qquiz = await _context.Quizzes
               .Where(Quiz => Quiz.Id == id)
               .Select(quiz => new
               {
                   A = quiz.A,
                   Q = quiz.Q
               })
               .ToListAsync();

            return Ok(qquiz);
        }

        /// <summary>
        /// Delete Quiz
        /// </summary>
        /// <response code="200">Added Successfully </response>
        /// <response code="400">something goes wrong in backend</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {

            var qquiz = await _context.Quizzes.SingleOrDefaultAsync(g => g.Id == id);
            if (qquiz == null)
            {
                return NotFound($"$your id is not correct :{id}");
            }
            _context.Quizzes.Remove(qquiz);
            _context.SaveChanges();
            return Ok(qquiz);
        }
    }
}
