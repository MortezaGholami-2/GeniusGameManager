using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

using GGM_ClassLibraryStandard.Models;
using GGM_ClassLibraryStandard.Services;

namespace GGM_UWP.Services
{
    /* Install SQLite for Universal Windows Platform from Visual Studio Marketplace in Extensions
     * menu, Manage Extensions.
     * Add SQLite for Universal Windows Platform in References. 
     * Install System.Data.SQLite.Core from NuGet Package Manager.
     * Add System.Data.SQLite namespace in Usings
     */

    /* SQLiteConnection, SQLiteCommand, SQLiteDataReader, SQLiteDataAdapter are the core elements of
       the.NET data provider model.The SQLiteConnection creates a connection to a specific data source.
       The SQLiteCommand object executes an SQL statement against a data source.The SQLiteDataReader
       reads streams of data from a data source. A SQLiteDataAdapter is an intermediary between the
       DataSet and the data source.It populates a DataSet and resolves updates with the data source.

       The DataSet object is used for offline work with a mass of data. It is a disconnected data
       representation that can hold data from a variety of different sources. Both SQLiteDataReader
       and DataSet are used to work with data; they are used under different circumstances. If we only
       need to read the results of a query, the SQLiteDataReader is the better choice. If we need more
       extensive processing of data, or we want to bind a Winforms control to a database table, the
       DataSet is preferred.
     */

    public static class DatabaseService
    {
        // *********** SQLite Database required fields *****************************************
        private static readonly string databaseName = "GGMDatabase.db";
        private static readonly string databasePath = ApplicationData.Current.LocalFolder.Path;
        private static readonly string connectionString = $"Data Source={databaseName};Version=3";
        // *************************************************************************************

        public static async Task InitializeDatabase()
        {
            await CreatDatabaseIfNotExist();
            await CreateDatabaseTablesIfNotExist();
            //await FillDatabaseWithDefaultData();
            //await SaveDummyDataInDatabase();
        }


        // *************** Platforms table database commands ***********************************
        #region Platforms Table Database Commands

        public static async Task<ObservableCollection<Platform>> GetPlatforms()
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                await connection.OpenAsync();

                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = @"SELECT * FROM Platforms";

                SQLiteDataReader reader = command.ExecuteReader();
                ObservableCollection<Platform> platforms = new ObservableCollection<Platform>();
                while (reader.Read())
                {
                    platforms.Add(new Platform()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        //ReleaseDate = Convert.ToDateTime(reader.GetString(2)),
                        ReleaseDate = DateTime.Now,
                        Developer = reader.GetString(3),
                        Manufacturer = reader.GetString(4),
                        MaxControllers = reader.GetInt32(5),
                        Cpu = reader.GetString(6),
                        Memory = reader.GetString(7),
                        Graphics = reader.GetString(8),
                        Sound = reader.GetString(9),
                        Display = reader.GetString(10),
                        Media = reader.GetString(11),
                        Notes = reader.GetString(12),
                        FileType = GameService.GetPlatformFileType(reader.GetString(1))
                        //IncludeInLibrary = Convert.ToBoolean(reader.GetInt32(3)),
                        //FolderChangeTrackerEnabled = Convert.ToBoolean(reader.GetInt32(4))
                    });
                }
                return platforms;
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///// <summary>
        ///// This method get list of all video folders in database (Morteza).
        ///// </summary>
        ///// <returns>Returns enumerable list of video folders (Morteza).</returns>
        //public static async Task<ObservableCollection<VideoFolder>> GetVideoFolders(string contentType)
        //{
        //    try
        //    {
        //        SQLiteConnection connection = new SQLiteConnection(connectionString);
        //        await connection.OpenAsync();

        //        SQLiteCommand command = new SQLiteCommand(connection);
        //        command.CommandText = $"SELECT * FROM VideoFolders WHERE ContentType = '{contentType}'";

        //        SQLiteDataReader reader = command.ExecuteReader();
        //        ObservableCollection<VideoFolder> videoFolders = new ObservableCollection<VideoFolder>();
        //        while (reader.Read())
        //        {
        //            videoFolders.Add(new VideoFolder()
        //            {
        //                Id = reader.GetInt32(0),
        //                FolderPath = reader.GetString(1),
        //                ContentType = reader.GetString(2),
        //                IncludeInLibrary = Convert.ToBoolean(reader.GetInt32(3)),
        //                FolderChangeTrackerEnabled = Convert.ToBoolean(reader.GetInt32(4))
        //            });
        //        }
        //        return videoFolders;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static async Task<ObservableCollection<VideoFolder>> GetVideoFolders(string contentType, bool includeInLibrary)
        //{
        //    try
        //    {
        //        SQLiteConnection connection = new SQLiteConnection(connectionString);
        //        await connection.OpenAsync();

        //        SQLiteCommand command = new SQLiteCommand(connection);
        //        command.CommandText = $"SELECT * FROM VideoFolders WHERE ContentType = '{contentType}' AND IncludeInLibrary = '{Convert.ToInt32(includeInLibrary)}'";

        //        SQLiteDataReader reader = command.ExecuteReader();
        //        ObservableCollection<VideoFolder> videoFolders = new ObservableCollection<VideoFolder>();
        //        while (reader.Read())
        //        {
        //            videoFolders.Add(new VideoFolder()
        //            {
        //                Id = reader.GetInt32(0),
        //                FolderPath = reader.GetString(1),
        //                ContentType = reader.GetString(2),
        //                IncludeInLibrary = Convert.ToBoolean(reader.GetInt32(3)),
        //                FolderChangeTrackerEnabled = Convert.ToBoolean(reader.GetInt32(4))
        //            });
        //        }
        //        return videoFolders;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public static async Task<VideoFolder> GetVideoFolderByFolderPath(string folderPath)
        //{
        //    try
        //    {
        //        SQLiteConnection connection = new SQLiteConnection(connectionString);
        //        await connection.OpenAsync();

        //        SQLiteCommand command = new SQLiteCommand(connection);
        //        command.CommandText = $"SELECT * FROM VideoFolders WHERE FolderPath = '{folderPath}'";

        //        SQLiteDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            VideoFolder videoFolder = new VideoFolder()
        //            {
        //                Id = reader.GetInt32(0),
        //                FolderPath = reader.GetString(1),
        //                ContentType = reader.GetString(2),
        //                IncludeInLibrary = Convert.ToBoolean(reader.GetInt32(3)),
        //                FolderChangeTrackerEnabled = Convert.ToBoolean(reader.GetInt32(4))
        //            };
        //            return videoFolder;
        //        }
        //        return default;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        /// <summary>
        /// This method adds a platform to "Platforms" table in database (Morteza).
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        public static async Task AddPlatform(Platform platform)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                await connection.OpenAsync();

                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO Platforms(PlatformName, ReleaseDate, Developer, Manufacturer, MaxControllers, Cpu, Memory, Graphics, Sound, Display, Media, Notes, FileType) " +
                    $"VALUES('{platform.Name}', '{platform.ReleaseDate}', '{platform.Developer}', '{platform.Manufacturer}', {platform.MaxControllers}, '{platform.Cpu}', '{platform.Memory}', '{platform.Graphics}', '{platform.Sound}', '{platform.Display}', '{platform.Media}', '{platform.Notes}', '{platform.FileType}')";
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public static async Task<bool> IsVideoFolderExistInDatabase(string folderPath)
        //{
        //    try
        //    {
        //        VideoFolder videoFolder = await GetVideoFolderByFolderPath(folderPath);
        //        if (videoFolder != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static async Task UpdateVideoFolder(VideoFolder videoFolder)
        //{
        //    try
        //    {
        //        SQLiteConnection connection = new SQLiteConnection(connectionString);
        //        await connection.OpenAsync();

        //        SQLiteCommand command = new SQLiteCommand(connection);
        //        command.CommandText = $"UPDATE VideoFolders SET IncludeInLibrary = {Convert.ToInt32(videoFolder.IncludeInLibrary)}, FolderChangeTrackerEnabled = {Convert.ToInt32(videoFolder.FolderChangeTrackerEnabled)} " +
        //             $"WHERE FolderPath = '{videoFolder.FolderPath}'";
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        ///// <summary>
        ///// This method will remove a video folder from database (Morteza).
        ///// </summary>
        ///// <param name="videoFolder">A video folder that you want to delete from database (Morteza).</param>
        //public static async Task DeleteVideoFolder(VideoFolder videoFolder)
        //{
        //    try
        //    {
        //        SQLiteConnection connection = new SQLiteConnection(connectionString);
        //        await connection.OpenAsync();

        //        //VideoFolder deletedVideoFolder = await GetVideoFolderByFolderPath(videoFolder.FolderPath);

        //        SQLiteCommand command = new SQLiteCommand(connection);
        //        command.CommandText = $"DELETE FROM VideoFolders WHERE FolderPath = '{videoFolder.FolderPath}'";
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        #endregion
        // ***************************************************************************************

        // *************** Games table database commands ****************************************
        #region Games Table Database Commands

        public static async Task<ObservableCollection<Game>> GetGames()
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                await connection.OpenAsync();

                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = @"SELECT * FROM Games";

                SQLiteDataReader reader = command.ExecuteReader();
                ObservableCollection<Game> games = new ObservableCollection<Game>();
                while (reader.Read())
                {
                    games.Add(new Game()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        //ReleaseDate = Convert.ToDateTime(reader.GetString(2)),
                        //ReleaseDate = DateTime.Now,
                        //Developer = reader.GetString(3),
                        Platform = reader.GetString(2),
                        //Manufacturer = reader.GetString(4),
                        //MaxControllers = reader.GetInt32(5),
                        //Cpu = reader.GetString(6),
                        //Memory = reader.GetString(7),
                        //Graphics = reader.GetString(8),
                        //Sound = reader.GetString(9),
                        //Display = reader.GetString(10),
                        //Media = reader.GetString(11),
                        Notes = reader.GetString(3)
                        //IncludeInLibrary = Convert.ToBoolean(reader.GetInt32(3)),
                        //FolderChangeTrackerEnabled = Convert.ToBoolean(reader.GetInt32(4))
                    });
                }
                return games;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task AddGame(Game game)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                await connection.OpenAsync();

                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = $"INSERT INTO Games('Title', 'Platform', 'Notes') " +
                     $"VALUES('{game.Title}', '{game.Platform}', '{game.Notes}')";
                     //$", '{plot}', '{Convert.ToString(releaseDate)}', {runtime})";
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
        // ***************************************************************************************




        // ******************** Videos table database commands ***********************************
        /// <summary>
        /// This method get list of all books in database (Morteza).
        /// </summary>
        /// <returns>Returns enumerable list of books (Morteza).</returns>
        //public IEnumerable<AdultVideo> GetAdultVideos()
        //{
        //    return database.Query<AdultVideo>("SELECT * FROM AdultVideos").AsEnumerable();
        //}

        //public IEnumerable<AdultVideo> GetAdultVideos(AdultVideo video)
        //{
        //    return database.Query<AdultVideo>("SELECT * FROM AdultVideos WHERE AdultVideos.Path = '" + video.Path + "'").AsEnumerable();
        //}

        //public void AddAdultVideo(
        //    string title,
        //    string folderPath,
        //    string path,
        //    bool isNew,
        //    bool isScraped,
        //    DateTime additionDate)
        //{
        //database.Insert(new AdultVideo()
        //{
        //    Title = title,
        //    FolderPath = folderPath,
        //    Path = path,
        //    ISNew = isNew,
        //    IsScraped = isScraped,
        //    AdditionDate = additionDate
        //});
        //}

        //public void UpdateAdultVideo(AdultVideo video)
        //{
        //    //database.Update(video);
        //}
        // ***************************************************************************************

        // ******************** Movies table database commands ***********************************
        //public IEnumerable<AdultVideo> GetMovies(AdultVideo movie)
        //{
        //    return database.Query<AdultMovie>("SELECT * FROM Movies WHERE AdultMovie.MovieID = '" + movie.MovieID + "'").AsEnumerable();
        //}

        //public void AddMovie(
        //    string title,
        //    string originalTitle,
        //    string movieID,
        //    string posterUrl,
        //    string moviePageUrl)
        //{
        //database.Insert(new AdultVideo()
        //{
        //    Title = title,
        //    MovieID=movieID,
        //    PosterUrl=posterUrl,
        //    MoviePageUrl=moviePageUrl});
        //}

        // ******************** Videos and Movies tables database commands ***********************
        //public IEnumerable<T> GetAdultVideos(AdultVideo video)
        //{
        //    //return database.Query<T>("SELECT * FROM AdultVideos WHERE AdultVideos.Path = '" + video.Path + "'").AsEnumerable();
        //}
        // ***************************************************************************************

        //public void AddBook(string title, string path)
        //{
        //    database.Insert(new Book()
        //    {
        //        Title=title,
        //        Path = path
        //    });
        //}

        //public void DeleteBook(Book book)
        //{
        //    int id = GetBooks(book).Single().Id;
        //    lock (collisionLock)
        //    {
        //        database.Delete<Book>(id);
        //    }
        //}





        //---------------------------------------
        ///// <summary>
        ///// using LINQ against the result of an invocation to the Table<T> method,
        ///// which is an object of type TableQuery<T> and implements the IEnumerable<T> interface
        ///// </summary>
        ///// <param name="countryName"></param>
        ///// <returns></returns>
        //public IEnumerable<Customer> GetFilteredCustomers(string countryName)
        //{
        //    lock (collisionLock)
        //    {
        //        var query = from cust in database.Table<Customer>()
        //                    where cust.Country == countryName
        //                    select cust;
        //        return query.AsEnumerable();
        //    }
        //}

        ///// <summary>
        ///// invoking a method called SQLiteConnection.Query<T>, which takes an argument
        ///// of type strings that represents a query written in SQL.
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<Customer> GetFilteredCustomers()
        //{
        //    lock (collisionLock)
        //    {
        //        return database.Query<Customer>(
        //          "SELECT * FROM Item WHERE Country = 'Italy'").AsEnumerable();
        //    }
        //}

        //public Customer GetCustomer(int id)
        //{
        //    lock (collisionLock)
        //    {
        //        return database.Table<Customer>().
        //          FirstOrDefault(customer => customer.Id == id);
        //    }
        //}


        //public int SaveCustomer(Customer customerInstance)
        //{
        //    lock (collisionLock)
        //    {
        //        if (customerInstance.Id != 0)
        //        {
        //            database.Update(customerInstance);
        //            return customerInstance.Id;
        //        }
        //        else
        //        {
        //            database.Insert(customerInstance);
        //            return customerInstance.Id;
        //        }
        //    }
        //}

        //public void SaveAllCustomers()
        //{
        //    lock (collisionLock)
        //    {
        //        foreach (var customerInstance in this.Customers)
        //        {
        //            if (customerInstance.Id != 0)
        //            {
        //                database.Update(customerInstance);
        //            }
        //            else
        //            {
        //                database.Insert(customerInstance);
        //            }
        //        }
        //    }
        //}


        //public void DeleteAllCustomers()
        //{
        //    lock (collisionLock)
        //    {
        //        database.DropTable<Customer>();
        //        database.CreateTable<Customer>();
        //    }
        //    this.Customers = null;
        //    this.Customers = new ObservableCollection<Customer>
        //      (database.Table<Customer>());
        //}

        #region Database Initializing

        private static async Task CreatDatabaseIfNotExist()
        {
            // ******** Create SQLite database in app folder APPX *************
            // ******** [Project Folder]\bin\x86\Debug\AppX *******************
            await ApplicationData.Current.LocalFolder.CreateFileAsync(databaseName, CreationCollisionOption.OpenIfExists);
        }

        private static async Task CreateDatabaseTablesIfNotExist()
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                await connection.OpenAsync();

                // ******** Create Platforms Data Table **************************************
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = @"CREATE TABLE IF NOT EXISTS Platforms(" +
                    @"ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    @"PlatformName TEXT NOT NULL," +
                    @"ReleaseDate TEXT," +
                    @"Developer TEXT NOT NULL," +
                    @"Manufacturer TEXT NOT NULL," +
                    @"MaxControllers INTEGER NOT NULL," +
                    @"Cpu TEXT NOT NULL," +
                    @"Memory TEXT NOT NULL," +
                    @"Graphics TEXT NOT NULL," +
                    @"Sound TEXT NOT NULL," +
                    @"Display TEXT NOT NULL," +
                    @"Media TEXT NOT NULL," +
                    @"Notes TEXT NOT NULL," +
                    @"FileType TEXT NOT NULL)";
                await command.ExecuteNonQueryAsync();
                // ***************************************************************************

                // ******** Create Games Data Table ******************************************
                command = new SQLiteCommand(connection);
                command.CommandText = @"CREATE TABLE IF NOT EXISTS Games(" +
                    @"ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    @"Title TEXT NOT NULL," +
                    @"Platform TEXT NOT NULL," +
                    //    @"AlternateName TEXT NOT NULL," +

                    //    @"ReleaseDate TEXT NOT NULL" +
                    //    @"GameType TEXT NOT NULL" +
                    //    @"ESRB TEXT NOT NULL" +
                    //    @"Developers TEXT NOT NULL" +
                    //    @"Publishers TEXT NOT NULL" +
                    //    @"Genres TEXT NOT NULL" +
                    //    @"MaxPlayers INTEGER NOT NULL," +
                    //    @"Cooperative TEXT NOT NULL" +
                    @"Notes TEXT NOT NULL)";
                await command.ExecuteNonQueryAsync();
                // ***************************************************************************

                // ******** Create MovieIds Data Table *****************************************
                //command = new SQLiteCommand(connection);
                //command.CommandText = @"CREATE TABLE IF NOT EXISTS MovieIds(" +
                //    @"ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                //    @"MovieServiceId INTEGER NOT NULL," +
                //    @"MovieIdText TEXT NOT NULL)";
                //await command.ExecuteNonQueryAsync();
                // ***************************************************************************

                // ******** Create Movies Data Table *****************************************
                //command = new SQLiteCommand(connection);
                //command.CommandText = @"CREATE TABLE IF NOT EXISTS MovieServices(" +
                //    @"ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                //    @"MovieService TEXT NOT NULL," +
                //    @"MovieServiceUrl TEXT NOT NULL)";
                //await command.ExecuteNonQueryAsync();
                // ***************************************************************************

                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static async Task FillDatabaseWithDefaultData()
        {
            try
            {
                //SQLiteConnection connection = new SQLiteConnection(connectionString);
                //await connection.OpenAsync();

                //// ******** Fill tables with default data ********************************************
                //SQLiteCommand command = new SQLiteCommand(connection);
                //command.CommandText = @"INSERT INTO MovieServices(MovieService, MovieServiceUrl) VALUES('IMDB', 'https://www.imdb.com/title/')";
                //command.ExecuteNonQuery();

                //command.CommandText = @"INSERT INTO MovieServices(MovieService, MovieServiceUrl) VALUES('R18', 'https://www.r18.com/videos/vod/movies/detail/-/id=')";
                //command.ExecuteNonQuery();
                //// ***********************************************************************************

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion



        private static async Task SaveDummyDataInDatabase()
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connectionString);
                await connection.OpenAsync();

                // ******** Create dummy data in Platforms Data Table *****************************
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO Platforms(PlatformName, ReleaseDate, Developer, Manufacturer, MaxControllers, Cpu, Memory, Graphics, Sound, Display, Media, Notes, FileType) VALUES('mort', '', 'sdsf', 'dfsdf', 1, 'ewer', 'sdfsdfs', 'dsfsdfsdf', '424234', 'xczxczx', 'xczxc', 'ljkllkjlk', 'NES')";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Platforms(PlatformName, ReleaseDate, Developer, Manufacturer, MaxControllers, Cpu, Memory, Graphics, Sound, Display, Media, Notes, FileType) VALUES('mort', '', 'sdsf', 'dfsdf', 1, 'ewer', 'sdfsdfs', 'dsfsdfsdf', '424234', 'xczxczx', 'xczxc', 'ljkllkjlk', 'NES')";
                command.ExecuteNonQuery();
                // ***********************************************************************************

                // ******** Create dummy data in Platforms Data Table *****************************
                command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO Games(Title, Platform, Notes) VALUES('mort', 'Nes', 'fgdfg')";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Games(Title, Platform, Notes) VALUES('mort', 'Nes', 'fgdfg')";
                command.ExecuteNonQuery();
                // ***********************************************************************************
            }
            catch (Exception error)
            {
                await NotificationService.DisplaySimpleMessageDialog("", error.Message);
                throw;
            }
        }


        public static async Task ClearDatabase()
        {
            try
            {
                // ******** Create dummy data in VideoFolders Data Table *****************************
                // ***********************************************************************************
            }
            catch (Exception)
            {

                throw;
            }
            //    //using var con = new SQLiteConnection(cs);
            //    //con.Open();

            //    //using var cmd = new SQLiteCommand(con);

            //    //cmd.CommandText = "DROP TABLE IF EXISTS cars";
            //    //cmd.ExecuteNonQuery();
        }


    }
}
