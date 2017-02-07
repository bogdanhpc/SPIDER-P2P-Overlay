using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIDER.VOD
{
    public interface IFrameManager
    {
        //Frame MyFrame { get; set; }
        void ReceiveSlot(Slot slot);

        void AskForSlot(int id, int frameId);

        
    }

    public class FrameCreater : IFrameManager
    {
        private Slot[] frame;

        public FrameCreater(int nrSlots)
        {
            frame = new Slot[nrSlots];

            LookForSlotInOwnList();
            LookForSlotInNeighborList();
            LookForSlotInCache();

            
        }

        private void LookForSlotInCache()
        {
            Console.WriteLine("Ma uit inlista cache");

        }

        private void LookForSlotInNeighborList()
        {
            Console.WriteLine("Ma uit in lista vecinului");

        }

        private void LookForSlotInOwnList()
        {
            Console.WriteLine("Ma uit in lista proprie");
        }

        public void AskForSlot(int id, int frameId)
        {
            throw new NotImplementedException();
        }

        public void ReceiveSlot(Slot slot)
        {
            throw new NotImplementedException();
        }
    }
}
