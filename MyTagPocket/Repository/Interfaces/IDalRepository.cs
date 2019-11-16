using LiteDB;
using MyTagPocket.Repository.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTagPocket.Repository.Interfaces
{
  /// <summary>
  /// Interface Database repository
  /// </summary>
  public interface IDalRepository
  {
    /// <summary>
    /// Initialize database
    /// </summary>
    Task InitilizeDbAsync();
    /// <summary>
    /// Instance LiteDb
    /// </summary>
    LiteDatabase Db { get;}

    void Save(IDalBase entity);

    IDalBase Load(string entityId);
  }
}
