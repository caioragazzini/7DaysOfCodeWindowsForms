using GameofThronesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofThronesAPI.Services
{
    public interface IThronesApiService
    {
        Task<List<Characters>> GetCharacter();
        Task<Characters> GetCharacterById(int id);

    }
}
