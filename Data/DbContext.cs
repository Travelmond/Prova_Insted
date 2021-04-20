using System;
namespace ProjectoVacinacao.Data
{
    public class DbContext
    {
       public string CaminhoBanco()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"base.json";
        }

    }
}
