using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCriminalidade.Application.Dtos
{
    public class CidadeForm
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Area { get; set; }
    }
}
