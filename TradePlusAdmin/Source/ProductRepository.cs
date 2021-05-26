using CommonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradePlusAdmin.Source.DataBase;

namespace TradePlusAdmin.Source
{
    public class ProductRepository : IRepository<Product>
    {
        public IEnumerable<Product> FindAll()
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                List<Product> products = new List<Product>();
                foreach(Product product in softDb.Products)
                {
                    softDb.Entry(product).Reference(x => x.Product_Type).Load();
                    products.Add(product);
                }
                return products;
            }
        }
        //public Product FindById(int id)
        //{
        //    using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
        //    {
        //        return softDb.Products.Where(x => x.Id == id).FirstOrDefault();
        //    }
        //}
        public ResponseServer Add(Product product)
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                ResponseServer response = new ResponseServer()
                {
                    Action = "Добавление новых товаров",
                    IsSuccess = false,
                    Message = "Не удалось добавить товары, проверьте правильность ввода полей"
                };
                if(softDb.Products.Find(product.Id) == null)
                {
                    softDb.Products.Add(product);
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
                    Action = "Удаление товаров",
                    IsSuccess = false,
                    Message = "Не удалось удалить товар, проверьте правильность ввода полей"
                };
                if(id != null)
                {
                    response.IsSuccess = true;
                    var chosen = softDb.Products.Where(x => x.Id == id).FirstOrDefault();
                    softDb.Products.Remove(chosen);
                    softDb.SaveChanges();
                    if(softDb.Products.Where(x => x.Id == id).FirstOrDefault() == null)
                    {
                        response.Message = "Товар удален";
                    }
                }
                return response;
            }
        }
        public ResponseServer Update(Product product)
        {
            using (SoftTradePlusEntities softDb = new SoftTradePlusEntities())
            {
                ResponseServer response = new ResponseServer()
                {
                    Action = "Изменение данных товаров",
                    IsSuccess = false,
                    Message = "Не удалось изменить данные о товаре, проверьте правильность ввода полей"
                };
                var oldProduct = softDb.Products.Where(x => x.Id == product.Id).FirstOrDefault();
                if (product != null)
                {
                    if (!oldProduct.Equals(product))
                    {
                        softDb.Products.Where(y => y.Id == product.Id).FirstOrDefault().Name = product.Name;
                        softDb.Products.Where(y => y.Id == product.Id).FirstOrDefault().Period = product.Period;
                        softDb.Products.Where(y => y.Id == product.Id).FirstOrDefault().Price = product.Price;
                        softDb.Products.Where(y => y.Id == product.Id).FirstOrDefault().Product_Type = product.Product_Type;
                        softDb.Products.Where(y => y.Id == product.Id).FirstOrDefault().Subscribe_Type = product.Subscribe_Type;
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
