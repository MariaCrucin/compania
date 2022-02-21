using Core.Entities;
using Core.Interfaces;
using Core.Specifications.Tarife;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TarifService : ITarifService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TarifService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Tarif> CreateTarif(Tarif tarif)
        {
            var spec = new TarifeSpecification(tarif.ClientId, tarif.ServiciuId);
            var tarifExistent = await _unitOfWork.Repository<Tarif>().GetEntityWithSpec(spec);
            if (tarifExistent != null)
                return null;
            
            var client = await _unitOfWork.Repository<Client>().GetByIdAsync(tarif.ClientId);
            if (client == null)
                return null;

            var serviciu = await _unitOfWork.Repository<Serviciu>().GetByIdAsync(tarif.ServiciuId);
            if (serviciu == null)
                return null;

            _unitOfWork.Repository<Tarif>().Add(tarif);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;

            return tarif;

        }

        public async Task<Tarif> GetTarif(int id)
        {
            var spec = new TarifeSpecification(id);
            return await _unitOfWork.Repository<Tarif>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Tarif>> GetTarife(int? clientId, string cod)
        {
            var spec = new TarifeSpecification(clientId, cod);
            return await _unitOfWork.Repository<Tarif>().ListAsync(spec);
            //return await _unitOfWork.Repository<Tarif>().ListAllAsync();
        }

        public async Task<Tarif> UpdateTarif(Tarif tarif)
        {
            var result = await _unitOfWork.Complete();
            if (result <=0) return null;

            return tarif;
        }
    }
}

