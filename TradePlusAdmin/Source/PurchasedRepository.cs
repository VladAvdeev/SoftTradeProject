using CommonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradePlusAdmin.Source.DataBase;

namespace TradePlusAdmin.Source
{
    public class PurchasedRepository : IRepository<Purchased_Box>
    {
        public IEnumerable<Purchased_Box> FindAll()
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                List<Purchased_Box> products = new List<Purchased_Box>();
                foreach (Purchased_Box product in softDb.Purchased_Box)
                {
                    softDb.Entry(product).Reference(x => x.Client).Load();
                    softDb.Entry(product).Reference(x => x.Product).Load();
                    products.Add(product);
                }
                return products;
            }
        }
       
        public ResponseServer Add(Purchased_Box product)
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                ResponseServer response = new ResponseServer()
                {
                    Action = "Добавление новых товаров в корзину",
                    IsSuccess = false,
                    Message = "Не удалось добавить товар в корзину, проверьте правильность ввода полей"
                };
                if (softDb.Purchased_Box.Find(product.Order_Id) == null)
                {
                    softDb.Purchased_Box.Add(product);
                    response.IsSuccess = true;
                    response.Message = "Товар успешно добавлен";
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
                    Action = "Удаление товаров из корзины",
                    IsSuccess = false,
                    Message = "Не удалось удалить товар из корзины, проверьте правильность ввода полей"
                };
                if (id != null)
                {
                    response.IsSuccess = true;
                    var chosen = softDb.Purchased_Box.Where(x => x.Order_Id == id).FirstOrDefault();
                    softDb.Purchased_Box.Remove(chosen);
                    softDb.SaveChanges();
                    if (softDb.Purchased_Box.Where(x => x.Order_Id == id).FirstOrDefault() == null)
                    {
                        response.Message = "Товар удален";
                    }
                }
                return response;
            }
        }
        public ResponseServer Update(Purchased_Box product)
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                ResponseServer response = new ResponseServer()
                {
                    Action = "Изменение данных товаров",
                    IsSuccess = false,
                    Message = "Не удалось изменить данные о товаре, проверьте правильность ввода полей"
                };
                var oldProduct = softDb.Purchased_Box.Where(x => x.Order_Id == product.Order_Id).FirstOrDefault();
                if (product != null)
                {
                    if (!oldProduct.Equals(product))
                    {
                        softDb.Purchased_Box.Where(y => y.Order_Id == product.Order_Id).FirstOrDefault().Product_Id = product.Product_Id;
                        softDb.Purchased_Box.Where(y => y.Order_Id == product.Order_Id).FirstOrDefault().Client_Id = product.Client_Id;
                        softDb.Purchased_Box.Where(y => y.Order_Id == product.Order_Id).FirstOrDefault().Purchase_Time= product.Purchase_Time;
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
