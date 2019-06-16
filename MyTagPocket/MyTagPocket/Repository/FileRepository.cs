﻿using MyTagPocket.CoreUtil;
using MyTagPocket.CoreUtil.Interface;
using MyTagPocket.Repository.File.Interface;
using MyTagPocket.Repository.Interface;
using System;
using Xamarin.Forms;

namespace MyTagPocket.Repository
{
  /// <summary>
  /// File system repository
  /// </summary>
  public class FileRepository : IFileRepository
  {
    const string classCode = "[1002400]";
    public static MyTagPocket.Interface.ILogger Log = Xamarin.Forms.DependencyService.Get<MyTagPocket.Interface.ILogManager>().GetLog(classCode);
    private IFileHelper _FileHelper;

    /// <summary>
    /// Constructor
    /// </summary>
    public FileRepository()
    {
      _FileHelper = DependencyService.Get<IFileHelper>();
    }

    /// <summary>
    /// Save entity to file system
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Instance entity</param>
    public void Load(IFileEntityBase entity)
    {
      const string methodCode = "[1002402]";
      try
      {
        Log.Trace(methodCode, $"Load {nameof(entity)}");

        string path = _FileHelper.GetLocalFilePath(entity.GetTypeEntity(), entity.GetIdEntity());
        string jsonString = _FileHelper.LoadFile(path);
        //Newtonsoft.Json.JsonConvert.DeserializeObject()
        entity = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString) as dynamic;
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, $"Cant Save {nameof(entity)}");
        entity = default;
      }
    }

    /// <summary>
    /// Load entity from file system
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="entity">Instance entity</param>
    public void Save(IFileEntityBase entity)
    {
      const string methodCode = "[1002401]";
      try
      {
        Log.Trace(methodCode, $"Save {nameof(entity)}");
        string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(entity);
        string path = _FileHelper.GetLocalFilePath(entity.GetTypeEntity(), entity.GetIdEntity());
        _FileHelper.SaveFile(path, jsonString);
      }
      catch (Exception ex)
      {
        Log.Error(ex, methodCode, $"Cant Save {nameof(entity)}");
      }
    }
  }
}
