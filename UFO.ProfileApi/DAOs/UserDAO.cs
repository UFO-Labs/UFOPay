using System.ComponentModel.DataAnnotations;

namespace UFO.ProfileApi.DAOs;

public record UserDAO([EmailAddress] string Email);
