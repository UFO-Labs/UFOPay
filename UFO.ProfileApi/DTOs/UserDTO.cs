using System.ComponentModel.DataAnnotations;

namespace UFO.ProfileApi.DTOs;

public record UserDTO(string Username, string Password, [EmailAddress] string Email);
