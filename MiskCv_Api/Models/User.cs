﻿namespace MiskCv_Api.Models;

public partial class User
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    public DateTime DateOfBirth { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public virtual ICollection<Address> Address { get; set; } = new List<Address>();
}
