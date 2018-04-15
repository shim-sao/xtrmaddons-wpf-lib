using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.Win32;
using System;
using System.Globalization;
using System.IO;


namespace XtrmAddons.Net.SQLiteBundle
{
    /// <summary>
    /// Class XtrmAddons Net SQLite Bundle using SQLite.Net
    /// </summary>
    public abstract class WpfSQLitePCL
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
        private string database;

        #endregion



        #region Properties

        // Le type n'est pas conforme CLS
        /// <summary>
        /// Property SQLite database connection.
        /// </summary>
        public SQLiteConnection Db { get; private set; }

        #endregion



        #region Methods

        /// <summary>
        /// XtrmAddons Common WPF SQLite Core constructor.
        /// </summary>
        public WpfSQLitePCL() { }

        /// <summary>
        /// XtrmAddons Common WPF SQLite Core constructor.
        /// </summary>
        /// <param name="database">The database file name.</param>
        /// <param name="createFile">Create file if not exists ?</param>
        /// <param name="scheme">The path to the database scheme.</param>
        public WpfSQLitePCL(string database, bool createFile = false, string scheme = "")
        {
            this.database = database;
            CreateConnection(database, createFile, scheme);
        }

        /// <summary>
        /// Method to create and connect to a SQLite database.
        /// </summary>
        /// <param name="database">The database file name.</param>
        /// <param name="createFile">Create file if not exists ?</param>
        /// <param name="scheme">The path to the database scheme.</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="SQLiteException"></exception>
        public void CreateConnection(string database, bool createFile = false, string scheme = "")
        {
            try
            {
                log.Debug(@"WPFSQLitePCL connecting : Data Source=" + database + ";Version=3;FailIfMissing=False;UTF8Encoding=True;");

                Db = new SQLiteConnection(new SQLitePlatformWin32(), @"Data Source=" + database + ";Version=3;FailIfMissing=False;UTF8Encoding=True;", SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.ProtectionNone);
                
                if (createFile)
                {
                    CreateDatabase(scheme);
                    InitializeSetting();
                }
            }
            catch (FileNotFoundException e)
            {
                string message = string.Format(CultureInfo.InvariantCulture, "Database file not found : {0}", database);
                log.Fatal(string.Format(message));
                log.Fatal(e);
                throw new Exception("Database file not found : " + database, e);
            }
            catch (SQLiteException e)
            {
                string message = string.Format(CultureInfo.InvariantCulture, "Database file not found : {0}", database);
                log.Fatal(string.Format(message));
                log.Fatal(e);
                throw SQLiteException.New(e.Result, e.Message);
            }
        }

        /// <summary>
        /// Method to create a new database base on a file of scheme.
        /// </summary>
        /// <param name="scheme">An application relative path to the database scheme to create.</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="SQLiteException"></exception>
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
                string message = string.Format(CultureInfo.InvariantCulture, "Database scheme file not found : {0}", scheme);
                log.Fatal(string.Format(message));
                log.Fatal(e);
                throw new FileNotFoundException(message, e);
            }

            try
            {
                Db.RunInTransaction(() => { Db.Execute(query); });
            }
            catch (SQLiteException e)
            {
                string message = string.Format(CultureInfo.InvariantCulture, "Failed to create database scheme : {0}", scheme);
                log.Fatal(string.Format(message));
                log.Fatal(e);
                throw SQLiteException.New(e.Result, message);
            }
        }

        /// <summary>
        /// Method to initialize database data on file creation.
        /// </summary>
        private void InitializeSetting()
        {
            log.Info("WPFSQLitePCL initialization. Child must implement new Method for its own initialization.");
        }

        #endregion
    }
}
