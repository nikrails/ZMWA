using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZMWA.Models
{
    public class ImageSource
    {
        private string m_ImagePath;
        public string ImagePath
        {
            get
            {
                return m_ImagePath;
            }
            set
            {
                m_ImagePath = value;
            }
        }
    }
}