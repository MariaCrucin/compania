using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications.Magazine
{
    public class MagazinSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize 
        { 
            get => _pageSize; 
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; 
        }

        public int? ClientId { get; set; }
        public string Sort { get; set; }

        private string _searchDen;
        public string SearchDen 
        { 
            get => _searchDen; 
            set => _searchDen = value.ToLower(); 
        }

        public int? SearchNr { get; set; }
    }
}
