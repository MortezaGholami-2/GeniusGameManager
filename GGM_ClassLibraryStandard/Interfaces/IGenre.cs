using System;
using System.Collections.Generic;
using System.Text;

using GGM_ClassLibraryStandard.Models;

namespace GGM_ClassLibraryStandard.Interfaces
{
    public interface IGenre
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
