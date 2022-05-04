using System;

namespace DesafioSidequest.Business.Models
{
    public class Entity
    {
        protected Entity() => Id = Guid.NewGuid();
        public Guid Id { get; set; }
    }
}