using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_ViewModel
{
    public class PagingParameter
    {
        //giới hạn số sản phẩm hiển thị lớn nhất
        const int MaxPageSize = 10;
        //mặc định set trang đầu 
        public int PageNumber { get; set; } = 1;
        //set số sản phẩm 1 trang là 4
        private int _pageSize = 4;
        //Encalsulate để get set ra _pageSize với đk nếu > MaxPage thì chỉ lấy MaxPagesize
        public int Pagesize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
    }
}
