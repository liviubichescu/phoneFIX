using PhoneFix.BLL.Services.ServSheetService.ServSheetModelDTO;
using PhoneFix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneFix.BLL.Services.ServSheetService
{
    public class ServSheetServices : BaseService
    {
        
        public IEnumerable<ServSheetDTO> GetAllServiceSheet()
        {
            var rsp = DbContext.ServiceSheets.Select(dto => new ServSheetDTO()
            {
                ID_Service = dto.ID_Service,
                clientID = dto.clientID,
                claimed_defect = dto.claimed_defect,
                phone_description_on_reception = dto.phone_description_on_reception,
                accesories = dto.accesories,
                date = dto.date
            });

            return rsp.ToList();
        }


        public void AddServiceSheet(ServSheetDTO dto)
        {

            ServiceSheet serviceSheet = new ServiceSheet()
            {
                ID_Service = dto.ID_Service,
                clientID = dto.clientID,
                claimed_defect = dto.claimed_defect,
                phone_description_on_reception = dto.phone_description_on_reception,
                accesories = dto.accesories,
                date = dto.date

            };

            DbContext.ServiceSheets.Add(serviceSheet);
            DbContext.SaveChanges();
        }


        public void DeleteServiceSheet(int id)
        {
            var serv = DbContext.ServiceSheets.Find(id);

            if (serv != null)
            {
                DbContext.ServiceSheets.Remove(serv);
            }
            else
            {
                throw new NotImplementedException();
            }

            DbContext.SaveChanges();
        }


        public void UpdateServiceSheet(int id, ServSheetDTO dto)
        {
            var service = DbContext.ServiceSheets.SingleOrDefault(b => b.ID_Service == id);

            if (service != null)
            {
                service.ID_Service = dto.ID_Service;
                service.clientID = dto.clientID;
                service.claimed_defect = dto.claimed_defect;
                service.phone_description_on_reception = dto.phone_description_on_reception;
                service.accesories = dto.accesories;
                service.date = dto.date;

                DbContext.SaveChanges();
            }

        }


        public ICollection<ServSheetDTO> GetServiceSheetByClientId(int id)
        {

            var services = from service in DbContext.ServiceSheets
                         join client in DbContext.Clients on service.clientID equals client.clientID
                         where client.clientID == id
                         select service;


            List<ServiceSheet> serviceSheetList = services.ToList();

            var res = new List<ServSheetDTO>();

            foreach (ServiceSheet dto in serviceSheetList)
            {
                res.Add(new ServSheetDTO()
                {
                    ID_Service = dto.ID_Service,
                    clientID = dto.clientID,
                    claimed_defect = dto.claimed_defect,
                    phone_description_on_reception = dto.phone_description_on_reception,
                    accesories = dto.accesories,
                    date = dto.date
                });
            }

            return res.ToList();
        }

        //// method for finding a client name based on my client ID
        //public string findClientName(int clientId)
        //{
        //    var qry = (from client in DbContext.Clients
        //               where client.clientID == clientId
        //               select client.firstname
        //            );

        //    return qry.First();
        //}

    }



}
