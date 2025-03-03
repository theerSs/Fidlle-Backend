﻿using System.ComponentModel.DataAnnotations;

namespace Fidlle.Application.DTO
{
    public class RegisterDto
    {
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
