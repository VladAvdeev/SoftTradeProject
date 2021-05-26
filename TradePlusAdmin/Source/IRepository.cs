using CommonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradePlusAdmin.Source
{
    public interface IRepository<T> where T : BaseEntity
    {
        ResponseServer Add(T item);
        ResponseServer Remove(int? id);
        ResponseServer Update(T item);
        //T FindById(int id);
        IEnumerable<T> FindAll();
    }
}
