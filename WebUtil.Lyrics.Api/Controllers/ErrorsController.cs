
using WebUtil.Lyrics.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebUtil.Lyrics.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            //accessing the thrown exception.
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                IExceptionService exceptionService => ((int)exceptionService.StatusCode, exceptionService.ErrorMessage),
                _=>(StatusCodes.Status500InternalServerError, "An unexpected error occurred."),
                /* InvalidProfileData => (StatusCodes.Status201Created, "Profile Data is not valid."),
                 InvalidRegisterData => (StatusCodes.Status201Created, "Email or Username is not valid."),
                 DuplicateEmailException => (StatusCodes.Status409Conflict, "User already exists."),
                 InvalidUser => (StatusCodes.Status404NotFound, "User doesn't exists."),
                 InvalidAccount => (StatusCodes.Status404NotFound, "Invalid UserAccount."),
                 Invalid_Account_Password => (StatusCodes.Status400BadRequest, "Invalid Password or Username combination."),
                 InvalidFrequency => (StatusCodes.Status400BadRequest, "Invalid Frequency or Authentication Token."),
                 InvalidTransferAmount => (StatusCodes.Status400BadRequest, "The Transfer Amount Must Be Positive."),
                 InvalidTransferOperation => (StatusCodes.Status400BadRequest, "No such transfer operation, See Documentation for further information."),
                 InvalidTransfer => (StatusCodes.Status400BadRequest, "Invalid Account Ownership or account not in existence"),
                 InsufficientFunds => (StatusCodes.Status400BadRequest, "Insufficient funds or you're not the owner of both accounts, change operation!"),
                 InternalServerError => (StatusCodes.Status500InternalServerError, "Internal server error."),
                 RequieredFrequencyForSavingAcc => (StatusCodes.Status400BadRequest, "Invalid Frequency interval for a Savings Account"),
                 InvalidCustomer => (StatusCodes.Status400BadRequest, "Something went wrong! No customer in database."),
                 NotProfileExisted => (StatusCodes.Status404NotFound, "Profile doesn't exists."),
                 InvalidBadRequest => (StatusCodes.Status400BadRequest, "Invalid - Bad requests"),
                */

            } ;
            return Problem(statusCode: statusCode, title: message);
        }
    }
}
