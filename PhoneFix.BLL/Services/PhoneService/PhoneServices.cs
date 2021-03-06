﻿
using PhoneFix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneFix.BLL.Services.PhoneService
{
    public class PhoneServices : BaseService
    {

        public IEnumerable<PhoneDTO> GetPhones()
        {
            var rsp = DbContext.Phones.Select(dto => new PhoneDTO()
            {   
                phoneID = dto.phoneID,
                clientID = dto.clientID,
                brand = dto.brand,
                type = dto.type,
                IMEI = dto.IMEI
            });

            return rsp.ToList();
        }

        public IEnumerable<PhoneAndClientDTO> getPhonesWithOwnerName()
        {
            var qry = from phone in DbContext.Phones
                       join client in DbContext.Clients
                       on phone.clientID equals client.clientID
                       select new PhoneAndClientDTO()
                       {
                           phoneID = phone.phoneID,
                           clientID = phone.clientID,
                           brand = phone.brand,
                           type = phone.type,
                           IMEI = phone.IMEI,
                           owner = client.firstname + " " + client.lastname
                        };
            return qry.ToList();
        }

        public void AddPhone(PhoneDTO dto)
        {

            Phone phone = new Phone()
            {
                clientID = dto.clientID,
                brand = dto.brand,
                type = dto.type,
                IMEI = dto.IMEI
            };
            
            DbContext.Phones.Add(phone);
            DbContext.SaveChanges();
        }

        public void UpdatePhone(int id, PhoneDTO phone)
        {
            var tel = DbContext.Phones.SingleOrDefault(b => b.phoneID == id);

            System.Diagnostics.Debug.WriteLine("In PhoneServices - UpdatePhone(); id -> " + id + " phone.phoneID -> " + phone.phoneID);

            if (tel != null)
            { 
                tel.brand = phone.brand;
                tel.type = phone.type;
                tel.IMEI = phone.IMEI;

                DbContext.SaveChanges();
            }
            
        }

        public ICollection<PhoneDTO> GetClientPhones(int id)
        {


            var phones = from client in DbContext.Clients
                         join phone in DbContext.Phones
                         on client.clientID equals phone.clientID
                         where client.clientID == id
                         select new PhoneDTO()
                         {
                             clientID = phone.clientID,
                             brand = phone.brand,
                             type = phone.type,
                             IMEI = phone.IMEI
                         };

            //from client in DbContext.Clients
            //join phons in DbContext.Phones 
            //on client.clientID equals phons.clientID
            //where client.clientID == id
            //select phons;

            //List<Phone> phon = phones.ToList();

            //var res = new List<PhoneDTO>();

            //foreach (Phone phone in phones)
            //{
            //    res.Add(new PhoneDTO()
            //    {
            //        clientID = phone.clientID,
            //        brand = phone.brand,
            //        type = phone.type,
            //        IMEI = phone.IMEI
            //    });
            //}

            return phones.ToList();
        }


        public void DeletePhone(int id)
        {
            var phone = DbContext.Phones.Find(id);

            if (phone != null)
            {
                DbContext.Phones.Remove(phone);
            }
            else
            {
                throw new NotImplementedException();
            }

            DbContext.SaveChanges();
        }

        public PhoneDTO findPhoneById(int id)
        {
            var res = DbContext.Phones.Find(id);

            return new PhoneDTO() { phoneID = res.phoneID,
                                    clientID = res.clientID,
                                    brand = res.brand,
                                    type = res.type,
                                    IMEI = res.IMEI,
                                  };
        }

    
    }
}
