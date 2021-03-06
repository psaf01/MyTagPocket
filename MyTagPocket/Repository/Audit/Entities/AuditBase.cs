﻿using MyTagPocket.Repository.Dal.Interface;
using System;

namespace MyTagPocket.Repository.Audit.Entities
{
  /// <summary>
  /// Base object for audit collection in LiteDb
  /// </summary>
  public abstract class AuditBase : IDalBase
  {
    protected private string nameCollection;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="nameCollection"></param>
    public AuditBase(string nameCollectionEntity)
    {
      nameCollection = nameCollectionEntity;
    }

    /// <summary>
    /// Identification entity in database
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get name collection
    /// </summary>
    public virtual string GetNameCollection()
    {
        return nameCollection;
    }
  }
}
