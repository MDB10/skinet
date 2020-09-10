using System.Collections.Generic;
using API.Dtos;

namespace API.Helpers
{
    public class Pagination<T> where T : class
    {
        private int totalItems;
        //private IReadOnlyList<ProductToReturnDto> data;

        public Pagination(int pageIndex, int pageSize, int Count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            this.Count = Count;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }

        public IReadOnlyList<T> Data  { get; set; }
        
    }
}