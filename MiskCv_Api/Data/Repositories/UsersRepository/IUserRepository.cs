﻿namespace MiskCv_Api.Data.Repositories.UsersRepository;

public interface IUserRepository
{
    Task<IEnumerable<User>?> GetUsers();
    Task<User?> GetUser(int id);
    Task<User?> UpdateUser(int id, User user);
    Task<User?> CreateUser(User user);
    Task<bool> DeleteUser(int id);
}