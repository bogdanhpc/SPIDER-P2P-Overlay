namespace SPIDER
{
    public interface ISpiderOverlay
    {
        void CreateOverlay();
        void DisplayOverlay();
        //Nod GetLastNode();
        int getMaximumNumberOfPeers();
        int getNoOfRings();
        int getNoOfChains();
        //int getNrHops(Nod a, Nod b);
        //bool IsNodeInOverlay(Nod node);
        //void JoinOverlay(Nod existingNode);
        //void LeaveOverlay(Nod node);
        void PopulateOverlay();
        //void UpdateAllNeihhbours(Nod node);
    }
}