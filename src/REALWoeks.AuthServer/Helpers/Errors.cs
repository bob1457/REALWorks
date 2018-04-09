using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Helpers
{
    public class Errors
    {
        public static ModelStateDictionary AddErrorsToModelState(IdentityResult identityResult, ModelStateDictionary modelState)
        {
          foreach (var e in identityResult.Errors)
          {
            modelState.TryAddModelError(e.Code, e.Description);
          }

          return modelState;
        }

        public static ModelStateDictionary AddErrorToModelState(string code, string description, ModelStateDictionary modelState)
        {
          modelState.TryAddModelError(code, description);
          return modelState;
        }
  }
}
