using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MiniEshop.Domain.Exceptions.Business;
using MiniEshop.Domain.Exceptions.NotFound;

namespace MiniEshop.Web.Controllers;

public class ErrorHandleController : Controller
{
    protected ActionResult Try(
        Func<ActionResult> method,
        Func<NotFoundException, ActionResult>? notFound = null,
        Func<BusinessException, ActionResult>? business = null,
        Func<ValidationException, ActionResult>? validation = null)
    {
        notFound ??= ex => View("NotFound", ex);
        business ??= ex =>
        {
            TempData["AlertMessage"] = ex.Message;
            string url = Request.Headers["Referer"].ToString();
            return Redirect(string.IsNullOrEmpty(url) ? Request.Host.Value : url);
        };
        validation ??= ex =>
        {
            foreach (ValidationFailure failure in ex.Errors)
            {
                ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }
            return View();
        };

        return Try<ActionResult>(method, notFound, business, validation);
    }

    protected TResult Try<TResult>(
        Func<TResult> method,
        Func<NotFoundException, TResult> notFound,
        Func<BusinessException, TResult> business,
        Func<ValidationException, TResult> validation)
    {
        try
        {
            return method();
        }
        catch (NotFoundException ex)
        {
            return notFound(ex);
        }
        catch (BusinessException ex)
        {
            return business(ex);
        }
        catch (ValidationException ex)
        {
            return validation(ex);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
