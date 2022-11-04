using Receipt_service.Core.Interfaces;
using System.Security.Principal;

namespace Receipt_service.Core.Models
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
    }
}