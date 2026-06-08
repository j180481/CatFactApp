using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactApp
{
    class PreferencesService
    {

        static public int HeaderSize
        {
            get
            {
                return Preferences.Get("font_size_header", 20);
            }
            set
            {
                Preferences.Set("font_size_header", value);
            }
        }

        static public int BodySize
        {
            get
            {
                return Preferences.Get("font_size_body", 14);
            }
            set
            {
                Preferences.Set("font_size_body", value);
            }
        }


    }
}
