using System;
using System.Data.SQLite;
using System.IO;
using XtrmAddons.Net.Application.Tools;

namespace XtrmAddons.Net.SQLiteBundle
{
    /// <summary>
    /// Class XtrmAddons Net SQLite Bundle using System.Data.SQLite.
    /// </summary>
    public class WPFSQLiteData : IDisposable
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

        /// <summary>
        /// Variable SQLite database connection.
        /// </summary>
        public SQLiteConnection Db { get; private set; }

        #endregion



        #region Methods

        /// <summary>
        /// XtrmAddons Common WPF SQLite Data constructor.
        /// </summary>
        /// <param name="database">The database file name.</param>
        /// <param name="createFile">Create file if not exists ?</param>
        /// <param name="scheme">The path to the database scheme.</param>
        public WPFSQLiteData(string database, bool createFile = false, string scheme = "")
        {
            this.database = database;
            CreateConnection(database, createFile, scheme);
        }

        /// <summary>
        /// Method to create and to connect to a SQLite database.
        /// </summary>
        /// <param name="database">The database file name (full path).</param>
        /// <param name="createFile">Create file if not exists ?</param>
        /// <param name="scheme">The path to the database scheme.</param>
        public void CreateConnection(string database, bool createFile = false, string scheme = "")
        {
            try
            {
                if(createFile)
                {
                    CreateFile(database);
                }

                log.Debug("WPFSQLiteData Connecting : Data Source=" + database + ";Version=3;");

                Db = new SQLiteConnection("Data Source=" + database + ";Version=3;");
                Db.Open();

                if (createFile)
                {
                    CreateDatabase(scheme);
                    InitializeSetting();
                }
            }
            catch (FileNotFoundException e)
            {
                log.Fatal(string.Format("Filename : {0}", database));
                log.Fatal(string.Format("Cannot connect to database : {0}", e.Message));
                log.Fatal(e.StackTrace);
                throw new Exception("Cannot connect to database : " + database, e);
            }
            catch (SQLiteException e)
            {
                log.Fatal(string.Format("Filename : {0}", database));
                log.Fatal(string.Format("Cannot connect to database : {0}", e.Message));
                log.Fatal(e.StackTrace);
                throw new Exception("Cannot connect to database : " + database, e);
            }
        }

        /// <summary>
        /// Method to create a database file.
        /// </summary>
        /// <param name="filename">A database file name (full path).</param>
        public static void CreateFile(string filename)
        {
            SQLiteConnection.CreateFile(filename);
            ApplicationTools.GrantAccess(filename);
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
            catch(Exception e)
            {
                log.Fatal(string.Format("Filename : {0}", scheme));
                log.Fatal(string.Format("Cannot scheme not found : {0}", e.Message));
                log.Fatal(e.StackTrace);
                throw new FileNotFoundException("Database scheme not found : " + scheme, e);
            }

            try
            {
                SQLiteCommand command = Db.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
            catch (SQLiteException e)
            {
                log.Fatal(string.Format("Filename : {0}", scheme));
                log.Fatal(string.Format("Cannot create database scheme : {0}", e.Message));
                log.Fatal(e.StackTrace);
                throw new SQLiteException("Cannot create database scheme : " + scheme, e);
            }
        }

        /// <summary>
        /// Method to initialize database data.
        /// </summary>
        protected virtual void InitializeSetting() { }
        
        #endregion Methods


        #region IDisposable Support
        /// <summary>
        /// Variable to detect recursive call.
        /// </summary>
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Db.Close();
                    Db.Dispose();
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~WPFSQLiteData() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            // TODO: supprimer les marques de commentaire pour la ligne suivante si le finaliseur est remplacé ci-dessus.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}