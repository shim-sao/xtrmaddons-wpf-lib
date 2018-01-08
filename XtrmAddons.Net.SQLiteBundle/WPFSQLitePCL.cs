using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.Win32;
using System;
using System.IO;

namespace XtrmAddons.Net.SQLiteBundle
{
    /// <summary>
    /// Class to provide SQLite management using System.Data.SQLite.
    /// </summary>
    abstract public class WPFSQLitePCL
    {
        #region Variables

        /// <summary>
        /// Variable logger.
        /// </summary>
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Variable database filename.
        /// </summary>
        private string _database { get; set; }

        /// <summary>
        /// Variable SQLite database connection.
        /// </summary>
        private SQLiteConnection _conn { get; set; }

        #endregion Variables


        #region Accessors

        /// <summary>
        /// Accessors SQLite database connection.
        /// </summary>
        public SQLiteConnection Db
        {
            get
            {
                return _conn;
            }

            set
            {
                _conn = value;
            }
        }

        #endregion Accessors


        #region Methods

        /// <summary>
        /// XtrmAddons Common WPF SQLite Core constructor.
        /// </summary>
        /// <param name="database">The database file name.</param>
        /// <param name="createFile">Create file if not exists ?</param>
        /// <param name="scheme">The path to the database scheme.</param>
        public WPFSQLitePCL(string database, bool createFile = false, string scheme = "")
        {
            _database = database;
            _createConnection(database, createFile, scheme);
        }
        
        /// <summary>
        /// Method to create and connect to a SQLite database.
        /// </summary>
        /// <param name="database">The database file name.</param>
        /// <param name="createFile">Create file if not exists ?</param>
        /// <param name="scheme">The path to the database scheme.</param>
        protected void _createConnection(string database, bool createFile = false, string scheme = "")
        {
            CreateConnection(database, createFile, scheme);
        }

        /// <summary>
        /// Method to create and connect to a SQLite database.
        /// </summary>
        /// <param name="database">The database file name.</param>
        /// <param name="createFile">Create file if not exists ?</param>
        /// <param name="scheme">The path to the database scheme.</param>
        public void CreateConnection(string database, bool createFile = false, string scheme = "")
        {
            try
            {
                log.Debug(@"WPFSQLitePCL connecting : Data Source=" + database + ";Version=3;FailIfMissing=False;UTF8Encoding=True;");

                _conn = new SQLiteConnection(new SQLitePlatformWin32(), @"Data Source="+database+ ";Version=3;FailIfMissing=False;UTF8Encoding=True;", SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.ProtectionNone);
                
                if (createFile)
                {
                    CreateDatabase(scheme);
                    InitializeSetting();
                }
            }
            catch (FileNotFoundException e)
            {
                log.Fatal(string.Format("Filename : {0}", database));
                log.Fatal(string.Format("Database file not found : {0}", e.Message));
                log.Fatal(e.StackTrace);
                throw new Exception("Database file not found : " + database, e);
            }
            catch (SQLiteException e)
            {
                log.Fatal(string.Format("Filename : {0}", database));
                log.Fatal(string.Format("Database file not found : {0}", e.Message));
                log.Fatal(e.StackTrace);
                throw SQLiteException.New(e.Result, e.Message);
            }
        }

        /// <summary>
        /// Method to create a new database base on a file of scheme.
        /// </summary>
        /// <param name="scheme">An application relative path to the database scheme to create.</param>
        protected void CreateDatabase(string scheme)
        {
            string query = "";
            string path = Path.Combine(Environment.CurrentDirectory, scheme);

            try
            {
                query = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                log.Fatal(string.Format("Filename : {0}", scheme));
                log.Fatal(string.Format("Database scheme not found : {0}", e.Message));
                log.Fatal(e.StackTrace);
                throw new FileNotFoundException("Database scheme not found : " + scheme, e);
            }

            try
            {
                Db.RunInTransaction(() => { Db.Execute(query); });
            }
            catch (SQLiteException e)
            {
                log.Fatal(string.Format("Filename : {0}", scheme));
                log.Fatal(string.Format("Database create database scheme : {0}", e.Message));
                log.Fatal(e.StackTrace);
                throw SQLiteException.New(e.Result, "Cannot create database scheme : " + scheme);
            }
        }

        /// <summary>
        /// Method to initialize database data.
        /// </summary>
        abstract protected void InitializeSetting();

        #endregion Methods
    }
}
