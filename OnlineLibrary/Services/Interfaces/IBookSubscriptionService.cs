using OnlineLibrary.Models;
using System;

namespace OnlineLibrary.Services.Interfaces
{
    public interface IBookSubscriptionService
    {
        bool Subscribe(Guid bookId, Guid userId);
        bool IsSubscribed(Guid bookId, Guid userId);
    }
}
