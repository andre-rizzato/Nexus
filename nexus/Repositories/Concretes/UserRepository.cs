using nexus.Models;
using nexus.Repositories.Interfaces;
using nexus.Data;
using nexus.Dtos.ResponseDtos;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.EntityFrameworkCore;

namespace nexus.Repositories.Concretes
{


    public class UserRepository : IUserRepository
    {


        NexusUsersDbContext _nexusContext { get; set; }

        public UserRepository(NexusUsersDbContext NexusContext)
        {
            _nexusContext = NexusContext;
        }

        public User Add(User user)
        {
            var entity = _nexusContext.Users.Add(user).Entity;
            _nexusContext.SaveChanges();
            return entity;
        }

        public int Delete(User user)
        {
            var entity = _nexusContext.Users.Remove(user).Entity;
            _nexusContext.SaveChanges();
            return entity.Id;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            var user = _nexusContext.Users.Find(id);
            user ??= new User();

            return user ?? new();
        }

        public User Update(User user)
        {
            var existingUser = _nexusContext.Users.Find(user.Id);
            
            if (existingUser != null)
            {
                var properties = typeof(User).GetProperties();

                foreach (var property in properties)
                {
                    var newValue = property.GetValue(user);

                    if (newValue != null && !Equals(newValue, GetDefault(property.PropertyType)))
                    {
                        property.SetValue(existingUser, newValue);
                    }
                }
                _nexusContext.Entry(existingUser).State = EntityState.Modified;
                _nexusContext.SaveChanges();
                return existingUser;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }

}