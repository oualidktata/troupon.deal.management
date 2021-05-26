using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Troupon.DealManagement.Core.Domain.InputModels;

namespace Troupon.DealManagement.Core.Application.Utility
{
  public static class UtilityMethods
  {
    public static string ToHash(
      SearchDealsFilter filter)
    {
      using (var algorithm = MD5.Create())
      {
        var json = JsonConvert.SerializeObject(filter);
        var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(json));

        return Convert.ToBase64String(hash);
      }
    }
  }
}
