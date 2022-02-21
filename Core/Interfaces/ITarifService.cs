using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITarifService
    {
        Task<Tarif> CreateTarif(Tarif tarif);
        Task<IReadOnlyList<Tarif>> GetTarife(int? clientId, string cod);
        Task<Tarif> GetTarif(int id);
        Task<Tarif> UpdateTarif(Tarif tarif);
    }
}
