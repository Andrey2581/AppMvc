using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            //para que o id nunca seja 0
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
