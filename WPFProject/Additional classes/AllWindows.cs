using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject.Additional_classes
{
    class AllWindows
    {
        public static MainWindow mainWindow { get; set; }
        public static Windows.Registration registration { get; set; }
        public static Windows.MainAdmin mainAdmin { get; set; }
        public static Windows.MainEmployee mainEmployee { get; set; }
        public static Windows.MainClient mainClient { get; set; }
    }
}
