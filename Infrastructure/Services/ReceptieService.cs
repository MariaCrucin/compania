using Core.Entities;
using Core.Interfaces;
using Core.Specifications.Receptii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ReceptieService : IReceptieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReceptieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Receptie> CreateReceptie(Receptie receptie)
        {
            _unitOfWork.Repository<Receptie>().Add(receptie);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
                return null;
            return receptie;
        }

        public async Task<Receptie> DeleteReceptie(int id)
        {
            var spec = new ReceptiiWithMaterialeSpecification(id);
            var existing = await _unitOfWork.Repository<Receptie>().GetEntityWithSpec(spec);
            if (existing == null)
            {
                return null;
            }
            _unitOfWork.Repository<Receptie>().Delete(existing);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
                return null;
            return existing;
        }

        public async Task<int> GetNumberOfReceptii(ReceptieSpecParams receptieParams)
        {
            var countSpec = new ReceptiiWithFurnizorAndTipDocumentForCountSpecification(receptieParams);
            return await _unitOfWork.Repository<Receptie>().CountAsync(countSpec);
        }

        public async Task<Receptie> GetReceptie(int id, string specification)
        {
            switch (specification)
            {
                case "ReceptiiWithMaterialeAndFurnizorSpecification":
                    var spec1 = new ReceptiiWithMaterialeAndFurnizorSpecification(id);
                    return await _unitOfWork.Repository<Receptie>().GetEntityWithSpec(spec1);

                case "ReceptiiWithMaterialeSpecification":
                    var spec2 = new ReceptiiWithMaterialeSpecification(id);
                    return await _unitOfWork.Repository<Receptie>().GetEntityWithSpec(spec2);
            }
            return null;
        }

        public async Task<Receptie> GetReceptieWithMaxNir()
        {
            var spec = new ReceptiiMaxNir();
            return await _unitOfWork.Repository<Receptie>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Receptie>> GetReceptii(ReceptieSpecParams receptieParams)
        {
                var spec = new ReceptiiWithFurnizorAndTipDocumentSpecification(receptieParams);
                return await _unitOfWork.Repository<Receptie>().ListAsync(spec);
        }

        public async Task<IReadOnlyList<Receptie>> GetReceptiiInStoc(ReceptieSpecParams receptieParams)
        {
            var spec = new ReceptiiInStocSpecification(receptieParams);
            return await _unitOfWork.Repository<Receptie>().ListAsync(spec);
        }

        public async Task<Receptie> UpdateReceptie(Receptie receptie)
        {
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;
            return receptie;
        }
    }
}
