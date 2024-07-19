using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Domain.Entities
{
    public abstract class Entity
    {

        public Entity() 
        { 
            Validate();
        }

        //Método que faz as validações de regra de negócios da entidade
        public virtual void Validate()
        {
            
        }
    }
}
