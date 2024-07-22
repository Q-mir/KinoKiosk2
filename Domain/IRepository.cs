using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLib.DTO;

namespace Domain
{
    public interface IRepository
    {
        bool Exist(string title);
        bool AddMovie(MovieDTO obj);
    }
}
