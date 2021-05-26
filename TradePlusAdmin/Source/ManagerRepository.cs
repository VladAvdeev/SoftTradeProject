using CommonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradePlusAdmin.Source.DataBase;

namespace TradePlusAdmin.Source
{
    public class ManagerRepository : IRepository<Manager>
    {
        public IEnumerable<Manager> FindAll()
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                List<Manager> managers = new List<Manager>();
                List<Manager> managersNew = new List<Manager>();
                managersNew = softDb.Managers.Include("Clients").ToList();
                return managersNew;
            }

        }
       
        public ResponseServer Add(Manager manager)
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                ResponseServer response = new ResponseServer()
                {
                    Action = "Добавление новых данных менеджера",
                    IsSuccess = false,
                    Message = "Не удалось добавить данные менеджера, проверьте правильность ввода полей"
                };
                if (softDb.Managers.Find(manager.Id) == null)
                {
                    softDb.Managers.Add(manager);
                    response.IsSuccess = true;
                    response.Message = "Новый менеджер успешно добавлен";
                    softDb.SaveChanges();

                }
                return response;
            }
        }
        public ResponseServer Remove(int? id)
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                ResponseServer response = new ResponseServer()
                {
                    Action = "Удаление данных менеджера",
                    IsSuccess = false,
                    Message = "Не удалось удалить данные работника"
                };
                if (id != null)
                {
                    response.IsSuccess = true;
                    var chosen = softDb.Managers.Where(x => x.Id == id).FirstOrDefault();
                    softDb.Managers.Remove(chosen);
                    softDb.SaveChanges();
                    if (softDb.Managers.Where(x => x.Id == id).FirstOrDefault() == null)
                    {
                        response.Message = "Успешно удалено";
                    }
                }
                return response;
            }
        }
        public ResponseServer Update(Manager manager)
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                ResponseServer response = new ResponseServer()
                {
                    Action = "Изменение текущих данных клиента",
                    IsSuccess = false,
                    Message = "Не удалось изменить данные о клиенте, проверьте правильность ввода полей"
                };
                var oldManager = softDb.Managers.Where(x => x.Id == manager.Id).FirstOrDefault();
                if (manager != null)
                {
                    if (!oldManager.Equals(manager))
                    {
                        softDb.Managers.Where(y => y.Id == manager.Id).FirstOrDefault().Name = manager.Name;
                        softDb.Managers.Where(y => y.Id == manager.Id).FirstOrDefault().Client_Id = manager.Client_Id;
                        response.IsSuccess = true;
                        softDb.SaveChanges();
                    }
                }
                response.Message = "Данные изменены";
                return response;
            }
            
        }
    }
}
