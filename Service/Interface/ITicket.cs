using Service.Entities;
using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITicket
    {
        List<TicketTable> GetAllTicket();
        TicketTable GetTicketById(int id);
        int CreateTicket(TicketTable product);
        int UpdateTicket(TicketTable product);
        int DeleteTicket(int Id);
        int DeleteTicket(TicketTable product);


    }
}
