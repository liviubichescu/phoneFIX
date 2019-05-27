using Microsoft.EntityFrameworkCore;
using PhoneFix.BLL.Services.PartService;
using PhoneFix.BLL.Services.RepairSheetService.RepairSheetDTO;
using PhoneFix.BLL.Services.WorkmanshipService;
using PhoneFix.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneFix.BLL.Services.RepairSheetService
{
    public class RepairService: BaseService
    {
        public IEnumerable<RepairSheetGetModel> GetRepairList()
        {
            var result = from repair in DbContext.RepairSheets
                      join service in DbContext.ServiceSheets
                      on repair.service_ID equals service.ID_Service
                      join phone in DbContext.Phones
                      on service.phoneID equals phone.phoneID
                      select new RepairSheetGetModel()
                      {
                          ID_repair = repair.ID_repair,
                          phone = phone.brand +" "+ phone.type,
                          IMEI = phone.IMEI,
                          date = service.date,
                          status = repair.status
                      };

            return result.ToList();
        }

        
        public RepairSheetPostModel GetRepairSheetUpdateModel(int id)
        {
            var result = (from repair in DbContext.RepairSheets

                          join service in DbContext.ServiceSheets
                          on repair.service_ID equals service.ID_Service

                          where repair.ID_repair == id

                          select new RepairSheetPostModel()
                          {
                              ID_repair = repair.ID_repair,
                              status = repair.status,
                              defect_conclusion = repair.defect_conclusion,
                              totalCost = repair.totalCost,
                              estimatedDate = repair.estimatedDate,
                              service_ID = repair.service_ID,
                              workmanships = repair.Workmanships.Select(x => new WorkmanshipGetModel()
                              {
                                  workmanshipID = x.workmanshipID,
                                  time = x.time,
                                  operations = x.operations,
                                  price = x.price
                              }),
                              parts = repair.Parts.Select(x => new PartGetModel()
                              {
                                  partName = x.partName,
                                  price = x.price
                              })
                          }).SingleOrDefault();

            if (result == null)
            {
                return null;
            }
            return result;
        }
        public RepairSheetDetailsModel GetDetailsRepairSheet(int id)
        {
            var result = (from repair in DbContext.RepairSheets

                          join service in DbContext.ServiceSheets
                          on repair.service_ID equals service.ID_Service

                          join phone in DbContext.Phones
                          on service.phoneID equals phone.phoneID

                          join client in DbContext.Clients
                          on phone.clientID equals client.clientID

                          where repair.ID_repair == id

                          select new RepairSheetDetailsModel()
                          {
                              ID_repair = repair.ID_repair,
                              owner = client.firstname + " " + client.lastname,
                              phone = phone.brand + " " + phone.type,
                              IMEI = phone.IMEI,
                              status = repair.status,
                              defect_conclusion = repair.defect_conclusion,
                              totalCost = repair.totalCost,
                              date = service.date,
                              estimatedDate = repair.estimatedDate,
                              service_ID = repair.service_ID,
                              workmanships = repair.Workmanships.Select(x => new WorkmanshipGetModel()
                              {
                                  workmanshipID = x.workmanshipID,
                                  time = x.time,
                                  operations = x.operations,
                                  price = x.price
                              }),
                              parts = repair.Parts.Select(x => new PartGetModel()
                              {
                                  partName = x.partName,
                                  price = x.price
                              })
                          }).SingleOrDefault();

            if (result == null)
            {
                return null;
            }
            return result;
        }

        public void UpdateRepairSheet(int id, RepairSheetPostModel repair)
        {
            var repairRes = DbContext.RepairSheets.SingleOrDefault(b => b.ID_repair == id);

            if (repairRes != null)
            {
                repairRes.defect_conclusion = repair.defect_conclusion;
                repairRes.totalCost = repair.totalCost;
                repairRes.estimatedDate = repair.estimatedDate;
                repairRes.status = repair.status;
                repairRes.service_ID = repair.service_ID;
                
                DbContext.SaveChanges();
            }
        }

        public void AddRepairSheet(RepairSheetPostModel repair)
        {
            RepairSheet repairSheet = new RepairSheet()
            {
                defect_conclusion = repair.defect_conclusion,
                totalCost = repair.totalCost,
                estimatedDate = repair.estimatedDate,
                status = repair.status,
                service_ID = repair.service_ID,
                Workmanships = repair.workmanships.Select(work => new Workmanship()
                {
                    time = work.time,
                    operations = work.operations,
                    price = work.price
                }).ToArray(),
                Parts = repair.parts.Select(part => new Part()
                {
                    partName = part.partName,
                    price = part.price
                }).ToArray()
            };
            DbContext.RepairSheets.Add(repairSheet);
            DbContext.SaveChanges();
        }

        public void DeleteRepairSheet(int id)
        {
            RepairSheet repair = DbContext.RepairSheets.Include(w => w.Workmanships).Include(p => p.Parts).FirstOrDefault(r => r.ID_repair == id);
            if (repair == null)
            {
                return;
            }
            DbContext.RepairSheets.Remove(repair);
            DbContext.SaveChanges();
        }

    }
}
