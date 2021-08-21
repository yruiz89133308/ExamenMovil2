using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using Examen3PMO2;

namespace Examen3PMO2.controller
{
    public class conexion
    {
       
            private string pathdb;
            public conexion() { }


            public string Conector()
            {
                string dbname = "db.sqlite";
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                pathdb = Path.Combine(path, dbname);
                return pathdb;
            }

            public SQLiteConnection Conn()
            {
                SQLiteConnection conn = new SQLiteConnection(App.UbicacionDB);
                return conn;
            }


            public SQLiteAsyncConnection GetConnectionAsync()
            {
                return new SQLiteAsyncConnection(App.UbicacionDB);
            }


        }
    }

