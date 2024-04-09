﻿using System.ComponentModel.DataAnnotations;

namespace Social.API.Contracts.Identity;

public class UserRegistrationDto
{

    [Required]
    [EmailAddress]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    public string Phone { get; set; }
    public string CurrentCity { get; set; }
}