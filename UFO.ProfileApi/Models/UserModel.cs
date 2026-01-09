using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UFO.ProfileApi.Models;

[Table("users")]
public class UserModel
{
    [Key]
    public int Id { get; set; }

    [Column(name: "username")]
    public string Username { get; set; }

    [Column(name: "password")]
    public string Password { get; set; }

    [Column(name: "email")]
    public string Email { get; set; }

    public UserModel() { }

    public UserModel(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
    }
}
