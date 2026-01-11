using System.ComponentModel.DataAnnotations;

namespace UFO.ProfileApi.DAOs;

public record UserEmailDAO([EmailAddress] string Email);
