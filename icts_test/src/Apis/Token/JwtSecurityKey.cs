using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace icts_test.WebAPIs.Token
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        }
    }

}
