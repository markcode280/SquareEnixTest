using SquareEnixTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SquareEnixTest.Services.Interfaces
{
    public interface IPlatformService
    {
        IList<Platform> getAllPlatform();
        Platform getPlatformByName(string name);
        Platform getPlatformById(int id);

      
    }
}
