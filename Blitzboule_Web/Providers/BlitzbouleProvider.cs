using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Blitzboule_Web.Providers
{
    public class BlitzbouleProvider : IDisposable
    {
        private MySqlConnection mySqlConnection;
        private bool isOpen;

        public BlitzbouleProvider()
        {
            string blitzbouleConnectionString =
                ConfigurationManager.ConnectionStrings["BlitzbouleConnection"].ConnectionString;
            
            mySqlConnection = new MySqlConnection(blitzbouleConnectionString);
            isOpen = false;
        }

        public void Dispose()
        {
            if (isOpen)
            {
                mySqlConnection.Close();
                isOpen = false;
            }
        }

        public MySqlConnection GetConnection()
        {
            if (!isOpen)
            {
                mySqlConnection.Open();
                isOpen = true;
            }

            return mySqlConnection;
        }
    }
}