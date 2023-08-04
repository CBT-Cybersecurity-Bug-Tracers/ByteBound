// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ByteBound.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using ByteBound.Data;
using Microsoft.EntityFrameworkCore;

namespace ByteBound.Areas.Identity.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly ByteBoundContext _context;

        public ForgotPasswordModel(ByteBoundContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Check if the email exists in the database
                bool emailExists = await _context.Users.AnyAsync(u => u.Email == Input.Email);

                if (emailExists)
                {
                    // Redirect to the ForgotPasswordConfirmation page if email exists
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }
                else
                {
                    // Add a specific error message for the Email property
                    ModelState.AddModelError("Email", "Email not found.");
                    return Page();
                }
            }
            return Page();
        }
    }
}
