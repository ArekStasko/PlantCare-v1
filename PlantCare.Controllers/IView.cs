using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantCare.Controllers
{
    public interface IView
    {
        public void DisplayMessage(string msg);
        public void DisplayErrorMessage(string msg);
    }
}
