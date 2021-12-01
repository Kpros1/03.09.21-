using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public class Class1
        
    {
        public Class1(Agent agent)
        {
            ID = agent.ID;
            Title = agent.Title;
            AgentTypeID = agent.AgentTypeID;
            Address = agent.Address;
            INN = agent.INN;
            KPP = agent.KPP;
            DirectorName = agent.DirectorName;
            Phone = agent.Phone;
            Email = agent.Email;
            Logo = agent.Logo;
            Priority = agent.Priority;
               
        }
        public int ID { get; set; }
        public string Title { get; set; }
        public int AgentTypeID { get; set; }
        public string Address { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string DirectorName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public int Priority { get; set; }





    }
}