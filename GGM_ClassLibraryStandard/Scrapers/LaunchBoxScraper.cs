using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

using GGM_ClassLibraryStandard.Models;

namespace GGM_ClassLibraryStandard.Scrapers
{
    public static class LaunchBoxScraper
    {
        public static async Task<ObservableCollection<Platform>> GetAllPlatforms()
        {
            try
            {
                ObservableCollection<Platform> allPlatforms = new ObservableCollection<Platform>();
                string path = $"https://gamesdb.launchbox-app.com/platforms";
                HtmlAgilityPack.HtmlDocument document = await HtmlDocumentScraper.GetHtmlDocumentByWebPageUrlAsync(path);

                HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//div[@class='col-sm-10']");
                if (nodes.Count > 0)
                {
                    foreach (HtmlNode searchNode in nodes)
                    {
                        allPlatforms.Add(new Platform()
                        {
                            Name = searchNode.ChildNodes[1].InnerText,
                            Notes = searchNode.ChildNodes[3].InnerText
                        });
                    }
                }

                nodes = document.DocumentNode.SelectNodes("//a[@class='list-item']");
                if (nodes.Count > 0)
                {
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        allPlatforms[i].PlatformUrl = $"https://gamesdb.launchbox-app.com{nodes[i].Attributes["href"].Value.Replace("games", "details")}";
                    }
                }

                nodes = document.DocumentNode.SelectNodes("//div[@class='col-sm-2']");
                if (nodes.Count > 0)
                {
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        if (nodes[i].ChildNodes.Count > 1)
                        {
                            allPlatforms[i].PictureUrl = nodes[i].ChildNodes[1].Attributes["src"].Value;
                        }
                        else
                        {
                            //allPlatforms[i].PictureUrl = "";
                            allPlatforms[i].PictureUrl = allPlatforms[0].PictureUrl;
                        }
                    }
                }

                int j = allPlatforms.Count;

                path = $"https://gamesdb.launchbox-app.com/platforms/index/2";
                document = await HtmlDocumentScraper.GetHtmlDocumentByWebPageUrlAsync(path);
                nodes = document.DocumentNode.SelectNodes("//div[@class='col-sm-10']");
                if (nodes.Count > 0)
                {
                    foreach (HtmlNode searchNode in nodes)
                    {
                        allPlatforms.Add(new Platform()
                        {
                            Name = searchNode.ChildNodes[1].InnerText,
                            Notes = searchNode.ChildNodes[3].InnerText
                        });
                    }
                }

                nodes = document.DocumentNode.SelectNodes("//a[@class='list-item']");
                if (nodes.Count > 0)
                {
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        allPlatforms[j + i].PlatformUrl = $"https://gamesdb.launchbox-app.com{nodes[i].Attributes["href"].Value}";
                    }
                }

                nodes = document.DocumentNode.SelectNodes("//div[@class='col-sm-2']");
                if (nodes.Count > 0)
                {
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        if (nodes[i].ChildNodes.Count > 1)
                        {
                            allPlatforms[j + i].PictureUrl = nodes[i].ChildNodes[1].Attributes["src"].Value;
                        }
                        else
                        {
                            //allPlatforms[i].PictureUrl = "";
                            allPlatforms[j + i].PictureUrl = allPlatforms[0].PictureUrl;
                        }
                    }
                }

                return allPlatforms;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<Platform> GetPlatformDetails(Platform selectedPlatform)
        {
            try
            {
                Platform platform = new Platform();

                HtmlAgilityPack.HtmlDocument platformPageDocument = await HtmlDocumentScraper.GetHtmlDocumentByWebPageUrlAsync(selectedPlatform.PlatformUrl);

                HtmlNodeCollection platformDetailsNodes = platformPageDocument.DocumentNode.SelectNodes("//td[@class='row-header']");
                // **************** PlatformUrl *************
                platform.PlatformUrl = selectedPlatform.PlatformUrl;
                // ******************************************

                // **************** Name ********************
                platform.Name = platformDetailsNodes[0].NextSibling.NextSibling.ChildNodes[1].InnerText;
                // ******************************************

                // **************** Release Date ************
                string releaseDateText = platformDetailsNodes[1].NextSibling.NextSibling.ChildNodes[3].InnerText;
                platform.ReleaseDate = Convert.ToDateTime(releaseDateText);
                // ******************************************

                // **************** Developer ***************
                platform.Developer = platformDetailsNodes[2].NextSibling.NextSibling.ChildNodes[3].InnerText;
                // ******************************************

                // **************** Manufacturer ************
                platform.Manufacturer = platformDetailsNodes[3].NextSibling.NextSibling.ChildNodes[3].InnerText;
                // ******************************************

                // **************** MaxControllers **********
                string maxControllers = platformDetailsNodes[4].NextSibling.NextSibling.ChildNodes[3].InnerText;
                if (!string.IsNullOrEmpty(maxControllers))
                    platform.MaxControllers = Convert.ToInt32(maxControllers);
                else
                    platform.MaxControllers = 5;
                // ******************************************

                // **************** Cpu *********************
                platform.Cpu = platformDetailsNodes[5].NextSibling.NextSibling.ChildNodes[3].InnerText;
                // ******************************************

                // **************** Memory ******************
                platform.Memory = platformDetailsNodes[6].NextSibling.NextSibling.ChildNodes[3].InnerText;
                // ******************************************

                // **************** Graphics ****************
                platform.Graphics = platformDetailsNodes[7].NextSibling.NextSibling.ChildNodes[3].InnerText;
                // ******************************************

                // **************** Sound *******************
                platform.Sound = platformDetailsNodes[8].NextSibling.NextSibling.ChildNodes[3].InnerText;
                // ******************************************

                // **************** Display *****************
                platform.Display = platformDetailsNodes[9].NextSibling.NextSibling.ChildNodes[3].InnerText;
                // ******************************************

                // **************** Media *******************
                platform.Media = platformDetailsNodes[10].NextSibling.NextSibling.ChildNodes[3].InnerText;
                // ******************************************

                // **************** Notes *******************
                platform.Notes = platformDetailsNodes[11].NextSibling.NextSibling.ChildNodes[3].InnerText;
                // ******************************************

                //    string directorText = productDetailsNodes1.ChildNodes[11].InnerText.Replace("\t", "").Replace("\n", "");
                //    //string directorText = adultMoviePageDocument.DocumentNode.SelectNodes("//dd[@itemprop='director']").FirstOrDefault().InnerText;
                //    directorText = directorText.Replace("\t", "").Replace("\n", "");
                //    //crew.Add(new Crew() { Job = "Director", FullName = directorText });
                //    adultMovie.Crew = crew;
                //.Replace("\t", "").Replace("\n", "")
                //    //string releaseDateText = adultMoviePageDocument.DocumentNode.SelectNodes("//dd[@itemprop='dateCreated']").FirstOrDefault().InnerText;
                //    DateTime convertedReleaseDate;
                //    if (DateTime.TryParse(releaseDateText, out convertedReleaseDate))
                //    {
                //        adultMovie.ReleaseDate = convertedReleaseDate;
                //    }

                //    HtmlNodeCollection productDetailsNodes = adultMoviePageDocument.DocumentNode.SelectNodes("//div[@class='product-details']");
                //    HtmlNode productDetailsNodes1 = productDetailsNodes.FirstOrDefault().ChildNodes[1];
                //    HtmlNode productDetailsNodes2 = productDetailsNodes.FirstOrDefault().ChildNodes[3];
                //    HtmlNode productDetailsNodes3 = productDetailsNodes.FirstOrDefault().ChildNodes[5];

                //    // **************** Runtime *****************
                //    string runTimeText = productDetailsNodes1.ChildNodes[7].InnerText.Replace("\t", "").Replace("\n", "");
                //    //string runTimeText = adultMoviePageDocument.DocumentNode.SelectNodes("//dd[@itemprop='duration']").FirstOrDefault().InnerText;
                //    runTimeText = runTimeText.Replace("\t", "").Replace("\n", "");
                //    string[] runTimeSeparatingStrings = { "min" };
                //    string[] runTimeArray = runTimeText.Split(runTimeSeparatingStrings, StringSplitOptions.RemoveEmptyEntries);
                //    adultMovie.Runtime = int.Parse(runTimeArray[0]);
                //    // ******************************************


                //    // **************** Studio ******************
                //    //adultMovie.Studio = productDetailsNodes1.ChildNodes[15].InnerText.Replace("\t", "").Replace("\n", "");
                //    //adultMovie.Studio = adultMoviePageDocument.DocumentNode.SelectNodes("//dd[@itemprop='productionCompany']").FirstOrDefault().InnerText.Replace("\t", "").Replace("\n", "");
                //    // ******************************************

                //    // **************** Label *******************
                //    //adultMovie.Label= productDetailsNodes1.ChildNodes[19].InnerText.Replace("\t", "").Replace("\n", "");
                //    // ******************************************

                //    // **************** Channel *****************
                //    List<string> channels = null;
                //    string channelText = productDetailsNodes2.ChildNodes[3].InnerText.Replace("\t", "").Replace("\n", "");
                //    string[] channelsSeparatingStrings = { ", " };
                //    string[] channelsArray = channelText.Split(channelsSeparatingStrings, StringSplitOptions.RemoveEmptyEntries);
                //    //adultMovie.Channel = channelsArray.ToList();
                //    // ******************************************

                //    // **************** ContentID ***************
                //    //adultMovie.ContentID = productDetailsNodes2.ChildNodes[7].InnerText.Replace("\t", "").Replace("\n", "");
                //    ////adultMovie.ContentID = adultMoviePageDocument.DocumentNode.SelectNodes("//a[@class='js-view-sample']").FirstOrDefault().Attributes["data-id"].Value;
                //    // ******************************************

                //    // **************** DVDID *******************
                //    //adultMovie.DVDID = productDetailsNodes2.ChildNodes[11].InnerText.Replace("\t", "").Replace("\n", "");
                //    // ******************************************

                //    // **************** Series ******************
                //    //adultMovie.Series = adultMovie.ContentID = productDetailsNodes2.ChildNodes[15].InnerText.Replace("\t", "").Replace("\n", "");
                //    //if (adultMovie.Series == "----")
                //    //    adultMovie.Series = "";
                //    // ******************************************

                //    // **************** Languages ***************
                //    List<string> languages = new List<string>();
                //    string languageText = productDetailsNodes2.ChildNodes[19].InnerText.Replace("\t", "").Replace("\n", "");
                //    languages.Add(languageText);
                //    //adultMovie.Languages = languages;
                //    // ******************************************

                //    // **************** Cast ********************
                //    HtmlNodeCollection castNodes = adultMoviePageDocument.DocumentNode.SelectNodes("//span[@itemtype='http://schema.org/Person']");
                //    List<Cast> cast = new List<Cast>();
                //    foreach (HtmlNode node in castNodes)
                //    {
                //        if (node.InnerText.Replace("\t", "").Replace("\n", "") != "----")
                //        {
                //            //cast.Add(new Cast()
                //            //{
                //            //    Role = "",
                //            //    FullName = node.InnerText.Replace("\t", "").Replace("\n", "")
                //            //});
                //        }
                //    }
                //    adultMovie.Cast = cast;
                //    // ******************************************

                //    // **************** Categories **************
                //    HtmlNodeCollection categoryNodes = adultMoviePageDocument.DocumentNode.SelectNodes("//a[@itemprop='genre']");
                //    List<string> categories = new List<string>();
                //    foreach (HtmlNode node in categoryNodes)
                //    {
                //        categories.Add(node.InnerText.Replace("\t", "").Replace("\n", ""));
                //    }
                //    //adultMovie.Categories = categories;
                //    // ******************************************

                //    // **************** Page Url ****************
                //    adultMovie.PageUrl = inputAdultMovie.PageUrl;
                //    // ******************************************

                //    // **************** Poster Url **************
                //    adultMovie.PosterUrl = adultMoviePageDocument.DocumentNode.SelectNodes("//img[@itemprop='image']").FirstOrDefault().Attributes["src"].Value;
                //    // ******************************************

                //    // **************** Cover Url ***************
                //    HtmlNode coverrUrlNode = adultMoviePageDocument.DocumentNode.SelectNodes("//section[@id='product-gallery']").FirstOrDefault().NextSibling.NextSibling.NextSibling.NextSibling.ChildNodes["div"].ChildNodes["img"];
                //    adultMovie.CoverUrl = coverrUrlNode.Attributes["src"].Value;
                //    // ******************************************

                //    // **************** Trailers ****************
                //    HtmlNode trailersNode = adultMoviePageDocument.DocumentNode.SelectNodes("//a[@class='js-view-sample']").FirstOrDefault();
                //    string[] trailers = new string[3];
                //    trailers[0] = trailersNode.Attributes["data-video-low"].Value;
                //    trailers[1] = trailersNode.Attributes["data-video-med"].Value;
                //    trailers[2] = trailersNode.Attributes["data-video-high"].Value;
                //    adultMovie.Trailers = trailers.ToList();
                //    // ******************************************

                return platform;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<ObservableCollection<Game>> SearchGame(string title)
        {
            ObservableCollection<Game> searchResult = new ObservableCollection<Game>();
            string path = $"https://gamesdb.launchbox-app.com/games/results?id={title}";
            HtmlAgilityPack.HtmlDocument document = await HtmlDocumentScraper.GetHtmlDocumentByWebPageUrlAsync(path);

            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//div[@class='col-sm-10']");
            if (nodes.Count > 0)
            {
                foreach (HtmlNode searchNode in nodes)
                {
                    searchResult.Add(new Game()
                    {
                        Title = searchNode.ChildNodes[1].InnerText,
                        Notes = searchNode.ChildNodes[5].InnerText
                    });
                }
            }

            //nodes = document.DocumentNode.SelectNodes("//a[@class='list-item']");
            //if (nodes.Count > 0)
            //{
            //    for (int i = 0; i < nodes.Count; i++)
            //    {
            //        allPlatforms[i].PlatformUrl = $"https://gamesdb.launchbox-app.com{nodes[i].Attributes["href"].Value.Replace("games", "details")}";
            //    }
            //}

            //nodes = document.DocumentNode.SelectNodes("//div[@class='col-sm-2']");
            //if (nodes.Count > 0)
            //{
            //    for (int i = 0; i < nodes.Count; i++)
            //    {
            //        if (nodes[i].ChildNodes.Count > 1)
            //        {
            //            allPlatforms[i].PictureUrl = nodes[i].ChildNodes[1].Attributes["src"].Value;
            //        }
            //        else
            //        {
            //            //allPlatforms[i].PictureUrl = "";
            //            allPlatforms[i].PictureUrl = allPlatforms[0].PictureUrl;
            //        }
            //    }
            //}

            return searchResult;
        }
    


        //public static async Task<Game> GetGameDetails(Game selectedGame)
        //{

        //}
    }
}
