using Microsoft.AspNetCore.Mvc;

namespace BankSolution.Controllers
{
    // a controller is a class that contains a set of action methods, in this case each action method acts as an endpoint which can be requested based on a specific url
    public class BankController : Controller     //class name surfix with controller; response=action result
    {
        //1、When request is received at path "/"
        [Route("/")]
        public IActionResult Index()        //action method called Index
        {
            return Content("Welcome to the Best Bank");
        }

        //2、When request is received at path "/account-details"
        [Route("/account-details")]
        public IActionResult AccountDetails()    //action method called AccountDetails
        {
            //hard-coded data
            var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };

            //send the object as JSON
            return Json(bankAccount);
        }

        //3、When request is received at path "/account-statement"
        [Route("/account-statement")]
        public IActionResult AccountStatement()     //action method called AccountStatement
        {
            //send a pdf file (at wwwroot folder) as response
            return File("~/statement.pdf", "application/pdf");
        }

        //4、When request is received at path "/get-current-balance/{accountNumber}"
        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance(int? accountNumber)
        {
            //hard-coded data
            var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };

            //if accountNumber is null, return HTTP 404
            if (accountNumber == null)
                return NotFound("Account Number should be supplied");


            if (accountNumber == 1001)
                //if accountNumber is 1001, return the current balance value
                return Content(bankAccount.currentBalance.ToString());
            else
                //if accountNumber is not 1001, return HTTP 400
                return BadRequest("Account Number should be 1001");
        }

        // if (Request.Query.ContainsKey("bookid")){}
        // if (string.IsNullOrEmpty(Convert.ToString(RequestDelegate.Query[""]))){}
        // Response.StatusCode = 400;
        // int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
        // if (Convert.ToBoolean(Request.Query["isloggedin"]) == false){}
        //
        // RedirectToActionResult: return new RedirectToActionResult("action", "controller", new{route_values}, permanent);
        // LocalRedirectResult: return new LocalRedirectResult("local_url", permanent);
        // RedirectResult: return new RedirectResult("url", permanent);




    }
}