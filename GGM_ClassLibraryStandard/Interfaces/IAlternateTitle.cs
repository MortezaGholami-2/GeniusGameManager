using System;
using System.Collections.Generic;
using System.Text;

using GGM_ClassLibraryStandard.Models;

namespace GGM_ClassLibraryStandard.Interfaces
{
    public interface IAlternateTitle
    {
        int Id { get; set; }
        string Title { get; set; }
        Region Region { get; set; }
    }
}
