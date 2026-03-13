using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Domain.Entities.Identity;

public class RefreshToken
{
    public Guid Id { get; set; }
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
    public bool IsRevoked { get; set; }
    public Guid UserId { get; set; }
    public AppUser User { get; set; }
}
