using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBankingSystem.domain.Paramter
{
    public class PaginationParamter
    {
        private const int MaxPageSize = 40;
        private int _pageSize = MaxPageSize;
        public int PageSize { 
        
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
        public int PageNumper { get; set; } = 1;
    }
}

