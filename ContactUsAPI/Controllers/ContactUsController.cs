using Microsoft.AspNetCore.Mvc;
using ContactUsAPI.Services;
using ContactUsAPI.Models;



namespace ContactUsAPI.Controllers
{
    using ContactUsAPI.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/contact-us")]
    public class ContactUsController : ControllerBase
    {
        private readonly ContactUsContext _context;
        private readonly IEmailSender _emailSender;

        public ContactUsController(ContactUsContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        [HttpPost("add")]
        public async Task<IActionResult> PostContactUs(ContactUs contactUs)
        {
            _context.ContactUs.Add(contactUs);
            await _context.SaveChangesAsync();
            return Ok(contactUs);
        }

        [HttpGet("test")]
        public async Task<string> Test()
        {
            await Task.Delay(1000); // Delay for 1 second (for demonstration purposes)

            return "This is a string returned asynchronously from the controller.";
       
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
        {
            await _emailSender.SendEmailAsync(emailRequest.To, emailRequest.Subject, emailRequest.Body);
            return Ok();
        }
    }
}
