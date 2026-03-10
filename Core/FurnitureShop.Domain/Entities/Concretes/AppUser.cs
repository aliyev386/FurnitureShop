using FurnitureShop.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Domain.Entities.Concretes;

public class AppUser:IdentityUser,IBaseEntity
{
    public string Username { get; set; }
    public string Role { get; set; }
    public ICollection<Order> Orders { get; set; }

}
