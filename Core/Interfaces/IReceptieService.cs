using Core.Entities;
using Core.Specifications.Receptii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IReceptieService
    { 
        Task<Receptie> GetReceptie(int id, string specification);

        Task<Receptie> GetReceptieWithMaxNir();

        Task<Receptie> CreateReceptie(Receptie receptie);

        Task<IReadOnlyList<Receptie>> GetReceptii(ReceptieSpecParams receptieParams);

        Task<IReadOnlyList<Receptie>> GetReceptiiInStoc(ReceptieSpecParams receptieParams);

        Task<int> GetNumberOfReceptii(ReceptieSpecParams receptieParams);

        Task<Receptie> DeleteReceptie(int id);

        Task<Receptie> UpdateReceptie(Receptie receptie);
    }
};
