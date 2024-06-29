using ApiCriminalidade.Context;
using ApiCriminalidade.Models;
using ApiCriminalidade.Repositorys.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiCriminalidade.Repositorys
{
    public class IndOcorrenciaRepository : IIndOcorrenciaRepository
    {
        private readonly AppDbContext _context;

        public IndOcorrenciaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<IndOcorrencia> Add(List<IndOcorrencia> indOcorrencias)
        {
            _context.BulkInsert(indOcorrencias);
            return indOcorrencias;
        }

        public IEnumerable<IndOcorrencia> GetAll()
        {
            
            return _context.IndOcorrencias;
        }

        public int GetTotalOcorrenciasPorZona(decimal raio, decimal latitude, decimal longitude)
        {
            var latitudeParam = new SqlParameter("LATITUDE", latitude);
            var longitudeParam = new SqlParameter("LONGITUDE", longitude);

            var sql = $"";

            var quantidade = _context.Database.SqlQuery<int>(@$" SELECT (6371 *
			                                                acos(
				                                                cos(radians({latitude})) *
				                                                cos(radians(latitude)) *
				                                                cos(radians({longitude}) - radians(longitude)) +
				                                                sin(radians({latitude})) *
				                                                sin(radians(latitude))
			                                                )) AS DISTANCIA
	                                                 FROM INDOCORRENCIAS ")            
                             .Where(DISTANCIA => DISTANCIA <=5).ToList();



            return 0;
        }
    }
}
