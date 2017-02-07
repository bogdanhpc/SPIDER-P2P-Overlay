using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIDER.VOD
{
    public interface IManageStorage
    {
        double Size { get; set; }

        void Decrease(Slot slot);
        void Increase(Slot slot);
    }
}
