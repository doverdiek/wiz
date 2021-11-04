using AbstractModels;
using AutoMapper;
using BackOfficeAuthService.Models.DTO;
using BackOfficeAuthService.Models.Requests;
using DataModels;
using MongoDB.Driver;
using MongoDBCrudLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeAuthService.Repos
{
    public class AuthRepo : MongoDBCollection<User>, IAuthRepo
    {
        private readonly IMapper mapper;
        public AuthRepo(IMongoDatabase database, string collectionName, IMapper mapper) : base(database, collectionName) {
            this.mapper = mapper;
        }
        public AuthDTO Login(string email, string password)
        {
            User auth = QueryAble.FirstOrDefault(a => a.Email == email);
            if (auth == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, auth.PasswordHash, auth.PasswordSalt))
            {
                return null;
            }

            var authdto = mapper.Map<AuthDTO>(auth);
            return authdto;
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public AuthDTO Register(RegisterRequest request)
        {
           var auth = mapper.Map<User>(request);
            try
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                auth.PasswordHash = passwordHash;
                auth.PasswordSalt = passwordSalt;

                UpsertRecord(auth);
                var authdto = mapper.Map<AuthDTO>(auth);
                return authdto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {

                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
    }
}
