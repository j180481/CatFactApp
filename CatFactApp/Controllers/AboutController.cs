using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatFactApp.Models;
using CatFactApp.Services;

namespace CatFactApp.Controllers
{
    public class AboutController
    {
        public int GetHeaderSize()
        {
            return PreferencesService.HeaderSize;
        }

        public int GetBodySize()
        {
            return PreferencesService.BodySize;
        }
    }
}
