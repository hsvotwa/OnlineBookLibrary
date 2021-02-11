using OnlineLibrary.Models;
using OnlineLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<UserBookViewModel> GetAll(Guid userId);
        bool Create(Book book);
        bool Clear();
    }
}