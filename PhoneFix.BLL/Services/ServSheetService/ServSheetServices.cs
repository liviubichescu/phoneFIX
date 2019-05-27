using PhoneFix.BLL.Services.ServSheetService.ServSheetModelDTO;
using PhoneFix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneFix.BLL.Services.ServSheetService
{
    public class ServSheetServices : BaseService
    {

        public IEnumerable<ServSheetListDTO> GetServiceSheetList()
        {
            var qry = DbContext.ServiceSheets.Select(dto => new ServSheetListDTO()
            {
                ID_Service = dto.ID_Service,
                phoneID = dto.phoneID,
                owner = "",
                phoneBrand = "",
                claimed_defect = dto.claimed_defect,
                date = dto.date               
                
            });
            // add query to a list for modeling;
            IEnumerable<ServSheetListDTO> rsp = qry.ToList();

            // add owner and phone brand to rsp list
            foreach (ServSheetListDTO servSheet in rsp)
            {
                var phone = DbContext.Phones.FirstOrDefault(p => p.phoneID == servSheet.phoneID);
                var client = DbContext.Clients.FirstOrDefault(c=>c.clientID == phone.clientID);

                servSheet.owner = client.firstname +" " + client.lastname;
                servSheet.phoneBrand = phone.brand + " " + phone.type; ;
            }
            
            return rsp;
        }

        public ServSheetDTO GetDetailsServiceSheet(int id)
        {
            var rsp = DbContext.ServiceSheets.Find(id);
            var phone = DbContext.Phones.FirstOrDefault(p => p.phoneID == rsp.phoneID);
            var client = DbContext.Clients.FirstOrDefault(c => c.clientID == phone.clientID);

            return new ServSheetDTO {
                ID_Service = rsp.ID_Service,
                phoneID = rsp.phoneID,
                claimed_defect = rsp.claimed_defect,
                phone_description_on_reception = rsp.phone_description_on_reception,
                accesories = rsp.accesories,
                date = rsp.date,
                ownerFirstname = client.firstname,
                ownerLastname = client.lastname,
                phoneBrand = phone.brand,
                phoneType = phone.type
            };
        }


        public void AddServiceSheet(ServSheetBaseDTO dto)
        {

            ServiceSheet serviceSheet = new ServiceSheet()
            {
                ID_Service = dto.ID_Service,
                phoneID = dto.phoneID,
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
                service.phoneID = dto.phoneID;
                service.claimed_defect = dto.claimed_defect;
                service.phone_description_on_reception = dto.phone_description_on_reception;
                service.accesories = dto.accesories;
                service.date = dto.date;

                DbContext.SaveChanges();
            }

        }


        public ICollection<ServSheetDTO> GetServiceSheetByPhoneId(int id)
        {

            var services = from service in DbContext.ServiceSheets
                         join client in DbContext.Clients on service.phoneID equals client.clientID
                         where client.clientID == id
                         select service;


            List<ServiceSheet> serviceSheetList = services.ToList();

            var res = new List<ServSheetDTO>();

            foreach (ServiceSheet dto in serviceSheetList)
            {
                res.Add(new ServSheetDTO()
                {
                    ID_Service = dto.ID_Service,
                    phoneID = dto.phoneID,
                    claimed_defect = dto.claimed_defect,
                    phone_description_on_reception = dto.phone_description_on_reception,
                    accesories = dto.accesories,
                    date = dto.date
                });
            }

            return res.ToList();
        }

    }



}
