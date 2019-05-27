using PhoneFix.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PhoneFix.BLL.Services.WorkmanshipService
{
    public class WorkmanshipService : BaseService
    {

        public IEnumerable<WorkmanshipGetModel> GetWorkmanships()
        {
            var res = DbContext.Workmanships.Select(work => new WorkmanshipGetModel()
            {
                workmanshipID = work.workmanshipID,
                time = work.time,
                price = work.price,
                operations = work.operations,
                //ID_repair = work.ID_repair
            });

            return res.ToList();
        }

        public void AddWorkmanship(WorkmanshipPostModel work)
        {
            Workmanship workmanship = new Workmanship()
            {
                time = work.time,
                price = work.price,
                operations = work.operations,
                ID_repair = work.ID_repair
            };

            DbContext.Workmanships.Add(workmanship);
            DbContext.SaveChanges();

        }

        public void UpdateWorkmanship(int id, WorkmanshipPostModel work)
        {
            var workmanship = DbContext.Workmanships.SingleOrDefault(b => b.workmanshipID == id);

            if (workmanship != null)
            {
                workmanship.time = work.time;
                workmanship.price = work.price;
                workmanship.operations = work.operations;
                workmanship.ID_repair = work.ID_repair;

                DbContext.SaveChanges();
            }
        }

        public WorkmanshipGetModel GetWorkmanship(int id)
        {
            var work = DbContext.Workmanships.Find(id);

            if (work == null)
            {
                return null;
            }

            return new WorkmanshipGetModel()
            {
                workmanshipID = work.workmanshipID,
                time = work.time,
                price = work.price,
                operations = work.operations,
                ID_repair = work.ID_repair
            };
        }

        public void RemoveWorkmanship(int id)
        {
            var work = DbContext.Workmanships.Find(id);

            if (work==null)
            {
                return;
            }

            DbContext.Workmanships.Remove(work);
            DbContext.SaveChanges();
        }
    }
}
