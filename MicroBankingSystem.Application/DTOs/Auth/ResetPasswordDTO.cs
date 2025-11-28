using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MicroBankingSystem.Application.DTOs.Auth
{
    public class ResetPasswordDTO
    {
        [Required(ErrorMessage ="Email is required.")]
        public string Email { get; set; } = default!;
        [Required(ErrorMessage = "New password is required.")]
        public string NewPassword { get; set; } = default!;
        [Required(ErrorMessage = "Confirm new password is required.")]
        public string ConfirmNewPassword { get; set; } = default!;

    }
}
