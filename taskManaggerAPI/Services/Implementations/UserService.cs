using Microsoft.EntityFrameworkCore;
using taskManaggerAPI.Data.Entities;
using taskManaggerAPI.Data.Models;
using taskManaggerAPI.DBContext;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly taskContext _taskContext;

        public UserService(taskContext taskContext)
        {
            _taskContext = taskContext;
        }

        public User? GetUserByEmail(string email)
        {
            return _taskContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public BaseResponse UserValidation(string email, string password)
        {
            BaseResponse response = new BaseResponse();

            if (email == "string" || password == "string")
            {
                response.Result = false;
                response.Message = "Por favor, ingrese email y contraseña";
                return response;
            }

            User? userForLogin = _taskContext.Users.FirstOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                {
                    response.Result = true;
                    response.Message = "Registro exitoso";
                }
                else
                {
                    response.Result = false;
                    response.Message = "Contraseña incorrecta";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "Email incorrecto";
            }
            return response;
        }

        public int CreateUser (User user)
        {
            _taskContext.Add(user);
            _taskContext.SaveChanges();
            return user.Id;
        }

        public void DeleteUser(int Id)
        {
            User? userToDelete = _taskContext.Users.FirstOrDefault(u => u.Id == Id);
            userToDelete.State = false;
            _taskContext.Update(userToDelete);
            _taskContext.SaveChanges();
        }
    }
}
