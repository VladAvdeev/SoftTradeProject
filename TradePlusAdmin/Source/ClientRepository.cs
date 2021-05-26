using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using TradePlusAdmin.Source.DataBase;
using CommonLibrary.Models;

namespace TradePlusAdmin.Source
{
    public class ClientRepository : IRepository<Client>
    {
        public IEnumerable<Client> FindAll()
        {
            using(SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                
               
                List<Client> clients = new List<Client>();
                foreach (var client in softDb.Clients)
                {
                    softDb.Entry(client).Reference(c => c.Manager).Load();
                    softDb.Entry(client).Reference(x => x.ClientStatu).Load();
                    softDb.Entry(client).Reference(y => y.ClientType).Load();
                    softDb.Entry(client).Collection(z => z.Purchased_Box).Load();
                    softDb.Entry(client).Collection(h => h.Managers).Load();
                    clients.Add(client);
                }
                return clients;
            }
            
        }
        //public Client FindById(int id)
        //{
        //    using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
        //    {
        //        return softDb.Clients.Where(x => x.Id == id).FirstOrDefault();
        //    }
        //}
        public ResponseServer Add(Client client)
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                ResponseServer response = new ResponseServer()
                {
                    Action = "Добавление новых данных клиента",
                    IsSuccess = false,
                    Message = "Не удалось добавить данные клиента, проверьте правильность ввода полей"
                };
                if (softDb.Clients.Find(client.Id) == null)
                {
                    softDb.Clients.Add(client);
                    response.IsSuccess = true;
                    response.Message = "Новый клиент успешно добавлен";
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
                    Action = "Удаление данных клиента",
                    IsSuccess = false,
                    Message = "Не удалось удалить данные клиента"
                };
                if(id != null)
                {
                    response.IsSuccess = true;
                    var chosen = softDb.Clients.Where(x => x.Id == id).FirstOrDefault();
                    softDb.Clients.Remove(chosen);
                    softDb.SaveChanges();
                    if(softDb.Clients.Where(x => x.Id == id).FirstOrDefault() == null)
                    {
                        response.Message = "Успешно удалено";
                    }
                }
                return response;
            }
        }
        public ResponseServer Update(Client client)
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                ResponseServer response = new ResponseServer()
                {
                    Action = "Изменение текущих данных клиента",
                    IsSuccess = false,
                    Message = "Не удалось изменить данные о клиенте, проверьте правильность ввода полей"
                };
                var oldClient = softDb.Clients.Where(x => x.Id == client.Id);
                if(client != null)
                {
                    if (!oldClient.Equals(client))
                    {
                        softDb.Clients.Where(y => y.Id == client.Id).FirstOrDefault().Name = client.Name;
                        softDb.Clients.Where(y => y.Id == client.Id).FirstOrDefault().Client_Status = client.Client_Status;
                        softDb.Clients.Where(y => y.Id == client.Id).FirstOrDefault().Client_Type = client.Client_Type;
                        softDb.Clients.Where(y => y.Id == client.Id).FirstOrDefault().Manager_Id = client.Manager_Id;
                        response.IsSuccess = true;
                        softDb.SaveChanges();
                    }
                }
              return response;
            }
        }
    }
}
