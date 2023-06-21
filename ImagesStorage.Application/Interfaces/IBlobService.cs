using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagesStorage.Application.Interfaces
{
    public interface IBlobService
    {
        string Upload(string base64Image);
    }
}