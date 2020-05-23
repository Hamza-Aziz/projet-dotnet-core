using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using projet.Models;

namespace projet.Services
{
    public class EnseignantServices : RepositoryEnseignant
    {
        private readonly PrjContext _context;
        private readonly IConfiguration _config;
        public EnseignantServices(PrjContext contextDB, IConfiguration config)
        {
            _config = config;
            _context = contextDB;
        }
        public void DeleteEns(int id)
        {
            var enseignant = _context.Enseignants.Find(id);
            _context.Enseignants.Remove(enseignant);
            _context.SaveChanges();
        }

        public IEnumerable<Enseignant> FindAllEns()
        {
            return _context.Enseignants.ToList();
        }

        public Enseignant GetEnsbyID(int id)
        {
            Enseignant ens = _context.Enseignants.Find(id);
            return ens;
        }

        public void SaveEns(Enseignant Ens)
        {
            _context.Add(Ens);
            _context.SaveChanges();
        }

        public void UpdateEns(Enseignant enseignant)
        {
            _context.Update(enseignant);
            _context.SaveChanges();
        }
        public string GenerateJSONWebTokenEnseignant(Enseignant claimedEnseignant)
        {
            Enseignant enseignant =  _context.Enseignants.Where(x => x.email == claimedEnseignant.email && x.mdp == claimedEnseignant.mdp).FirstOrDefault();
            if (enseignant == null)
            {
                return null;
            }

            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var expiryDuration = int.Parse(_config["Jwt:ExpiryDuration"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,
                Audience = null,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim> {
                    new Claim("userId",enseignant.Id.ToString()),
                    new Claim("nom",enseignant.nom.ToString()),
                    new Claim("prenom",enseignant.prenom.ToString()),
                    new Claim("email",enseignant.email.ToString()),
                    new Claim("roles",enseignant.role.ToString()),

                }),
                SigningCredentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256)

            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return token;
        }
        public string GenerateJSONWebTokenAdmin(Admin claimedAdmin)
        {
            Admin admin = _context.Admins.Where(x => x.username == claimedAdmin.username && x.mdp == claimedAdmin.mdp).FirstOrDefault();
            if (admin == null)
            {
                return null;
            }

            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var expiryDuration = int.Parse(_config["Jwt:ExpiryDuration"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,
                Audience = null,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim> {
                    new Claim("userId",admin.Id.ToString()),
                    new Claim("nom",admin.nom.ToString()),
                    new Claim("prenom",admin.prenom.ToString()),
                    new Claim("email",admin.email.ToString()),
                    new Claim("roles",admin.role.ToString()),

                }),
                SigningCredentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256)

            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return token;
        }
    }
}
