using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragInterfaceGenerator.ViewModels
{
    class Models
    {
    }

    public class Grid
    {
        public bool IS_API { get; set; }
        public string CONTROL_NAME { get; set; }
        public string NAME { get; set; }
        public string CODE { get; set; }

    }

    public class Grids
    {
        public int Level { get; set; }
        public string Identity { get; set; }
        public string PageName { get; set; }
        public string PageCode { get; set; }
        public List<Grid> grids { get; set; }
        public List<string> strs { get; set; }

        public Grids()
        {
            Level = 0;
            grids = new List<Grid>();
            strs = new List<string>();
        }
    }

    public class POSITION
    {
        public double TOP { get; set; }
        public double LEFT { get; set; }
        public double BOTTOM { get; set; }
        public double RIGHT { get; set; }
    }
}
