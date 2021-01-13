using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject.Additional_classes
{
    class AllWindows
    {
        public static MainWindow MainWindow { get; set; }
        public static Windows.Registration Registration { get; set; }
        public static Windows.MainAdmin MainAdmin { get; set; }
        public static Windows.MainEmployee MainEmployee { get; set; }
        public static Windows.MainClient MainClient { get; set; }
        public static Windows.Cart Cart { get; set; }
    }
}
