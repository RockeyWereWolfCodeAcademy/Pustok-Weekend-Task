using System.Collections;
using System.Drawing.Printing;

namespace Pustok_Weekend_Task.Areas.Admin.ViewModels.AdminCommonVM
{
    public class AdminPaginationVM<T> where T : IEnumerable
    {
        public int TotalCount { get; }
        public int PageSize { get; }
        public int LastPage { get; }
        public int CurrentPage { get; }
        public bool HasPrev { get; }
        public bool HasNext { get; }
        public T Items { get; }
        public int FirstOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, TotalCount); }
        }
        public AdminPaginationVM(int pageSize, int totalCount, int currentPage, int lastPage, T items)
        {
            if (currentPage <= 0)
            {
                throw new ArgumentException();
            }
            PageSize = pageSize;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            LastPage = lastPage;
            Items = items;
            if (currentPage <= lastPage)
            {
                if (currentPage == 1)
                {
                    HasPrev = false;
                }
                else
                {
                    HasPrev = true;
                }
                if (currentPage == lastPage)
                {
                    HasNext = false;
                }
                else
                {
                    HasNext = true;
                }
            }
        }
    }
}
