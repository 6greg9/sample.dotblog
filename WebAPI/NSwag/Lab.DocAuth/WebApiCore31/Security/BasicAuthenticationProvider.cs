using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCore31.Security
{
    public class BasicAuthenticationProvider : IBasicAuthenticationProvider
    {
        //����db�s�񪺸��
        private readonly List<User> _fakeUsers = new List<User>
        {
            new User
            {
                Id = 1, FirstName = "�p��", LastName = "�E", UserId = "yao", Password = "123456"
            }
        };

        public async Task<bool> Authenticate([NotNull] string userId, [NotNull] string password)
        {
            return this._fakeUsers
                       .Where(p => string.Compare(p.UserId, userId, true) == 0)
                       .Where(p => p.Password                             == password)
                       .Any();
        }
    }
}