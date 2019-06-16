using System;
using System.Collections.Generic;
using System.Text;

namespace MyTagPocket.Dal.Upgrade.Interface
{
  /// <summary>
  /// Base interface for upgrade database
  /// </summary>
  public interface IUpgradeDbBase
  {
    /// <summary>
    /// Check and if necessary upgrade database
    /// </summary>
    void CheckAndUpgrade();

    /// <summary>
    /// Remove / drop the specified table from the DB
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    bool DropTable<T>() where T : class;

    /// <summary>
    /// Check exists table in database
    /// </summary>
    /// <typeparam name="T">Class of Table</typeparam>
    /// <returns>True = exists</returns>
    bool IsExistsTable<T>() where T : class;

    /// <summary>
    /// Create table
    /// </summary>
    /// <typeparam name="T">Class of Table</typeparam>
    /// <returns></returns>
    void CreateTable<T>() where T : class;

    /// <summary>
    /// Generic method to determine is an object type exists within the DB
    /// </summary>
    /// <param name="type"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    bool IsTypeExistst(string type, string name);

    /// <summary>
    /// Get version table from Entity class
    /// </summary>
    /// <param name="t">Entity table class</param>
    /// <returns>Version actual table entity</returns>
    int GetVersionTableFromEntity(Type t);
  }
}