using System;
using System.ComponentModel.DataAnnotations;

namespace WebUtil.Lyrics.Contracts.Authentication;

public record RegisterRequest(
	[Required]
	string Username,
	[Required]
	string Email,
	[Required]
    string Password,
	[Required]
    int Role
);

