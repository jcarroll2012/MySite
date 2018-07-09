using System;
using System.Threading.Tasks;
using MySiteCore.Models;

namespace MySiteCore.Interfaces

{
    public interface IMyRepository
    {
        Task<MyDbModel> getWebUrl(int IdDescriptor);
    }
}
