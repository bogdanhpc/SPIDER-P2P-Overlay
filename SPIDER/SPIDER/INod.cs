namespace SPIDER
{
    interface INod
    {
        string Id { get; set; }
        bool IsSuperPeer { get; set; }
        int Chain { get; set; }
        int Ring { get; set; }
        //string Content { get; set; }
        Neighbour Status { get; set; }
        double Trust { get; set; }


        void PrintNod();
    }
}