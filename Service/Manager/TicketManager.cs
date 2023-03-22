using Model;
using Service.Entities;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manager
{
   public  class TicketManager : ITicket
    {
         HelpdeskEntities db1 = new HelpdeskEntities();
        
        public TicketTable GetTicketById(int id)
        {
            var row = db1.TicketTables.Where(model=>model.Ticket_Id == id).FirstOrDefault();
            return row;
        }

        public int UpdateTicket(TicketTable newTicket)
        {
            db1.Entry(newTicket).State = EntityState.Modified;
          return  db1.SaveChanges();
        }

       public int CreateTicket(TicketTable newTicket)
        {
            db1.TicketTables.Add(newTicket);
          return  db1.SaveChanges();
        }

       public int DeleteTicket(int Id)
        {
            TicketTable product = db1.TicketTables.Find(Id);
            db1.TicketTables.Remove(product);
           return db1.SaveChanges();
        }
        public int DeleteTicket(TicketTable product)
        {
            db1.TicketTables.Remove(product);
           return db1.SaveChanges();
        }


        public List<TicketTable> GetAllTicket()
        {
            var data = db1.TicketTables.ToList();
            return data;
        }


      





    }
}
