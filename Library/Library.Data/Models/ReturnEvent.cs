using System;

namespace Library.Data
{
    public class ReturnEvent : BookEvent
    {
        public override DateTime EventDate { get; set; }
    }
}