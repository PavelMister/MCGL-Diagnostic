using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;

namespace MCGL_Diagnostic
{
    public class InternetCS
    {
        //Creating the extern function...  
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static bool IsConnectedToInternet()
        {
            return InternetGetConnectedState(out int Desc, 0);
        }

    }

    public class Library
    {
        public string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        static async Task<string[]> ProcessUrlAsync(string url, HttpClient client)
        {
            string content = "";
            string result = "Доступен";
            string available = "1";
            try
            {
                content = await client.GetStringAsync(url);
            } catch {
                return new string[] { url, "Недоступен", "0" };
            }

            if (content.Length <= 0)  {
                result = "Недоступен";
                available = "0";
            }
            return new string[] { url, result, available };
        }

        static readonly HttpClient httpClient = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000,
            Timeout = new TimeSpan(0, 0, 10)
        };

        public async Task<int> SumPageSizesAsync()
        {
            if ( ! InternetCS.IsConnectedToInternet())
            {
                MCGLForm._MCGLForm.UpdateResult("Отсутствует интернет-соединение\r\n");
                return 0;
            }
            var stopwatch = Stopwatch.StartNew();

            IEnumerable<Task<string[]>> downloadTasksQuery =
                from url in testUrls select ProcessUrlAsync(url, httpClient);

            List<Task<string[]>> downloadTasks = downloadTasksQuery.ToList();

            int availableUrls = 0;
            int availableMcglUrls = 0;
            while (downloadTasks.Any())
            {
                Task<string[]> finishedTask = await Task.WhenAny(downloadTasks);
                downloadTasks.Remove(finishedTask);
                string[] result = await finishedTask;
                if (result[2] == "1")
                {
                    availableUrls++;
                    if ( ! result[0].Contains("pavelstudio")){
                        availableMcglUrls++;
                    }
                }
                MCGLForm._MCGLForm.UpdateResult(result[0] + " - " + result[1] + "\r\n");
            }

            if (availableUrls == 0) {
                MCGLForm._MCGLForm.UpdateResult("Ни один URL недоступен, возможно у Вас отсутствует интернет-соединение\r\n");
            }

            stopwatch.Stop();
            return availableMcglUrls;
        }

        static readonly IEnumerable<string> testUrls = new string[]
        {
            "http://f1.mcgl.ru",
            "http://f2.mcgl.ru",
            "http://f3.mcgl.ru",
            "https://forum.minecraft-galaxy.ru",
            "https://minecraft-galaxy.ru",
            "https://pavelstudio.com"
        };
        

        public HttpClient InitHttpClient(int timeout = 10, string proxyIp = "", string ProxyPort = "")
        {
            // First create a proxy object
            var proxy = new System.Net.WebProxy
            {
                Address = new Uri($"http://{proxyIp}:{ProxyPort}"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };

            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy
            };

            HttpClient client = new HttpClient();

            // Finally, create the HTTP client object
            if (!String.IsNullOrEmpty(proxyIp))
            {
                client = new HttpClient(handler: httpClientHandler, disposeHandler: true);
            }
            client.Timeout = new System.TimeSpan(0, 0, timeout);
            return client;
        }


        public string GetOnline(int type = 0)
        {
            string path;
            string content;
            switch (type) {
                case 1: path = "online-garants";
                    break;
                case 2: path = "online-helpers";
                    break;
                case 3: path = "online-profis";
                    break;
                default: path = "online-players";
                    break;
            }

            try
            {
                using (HttpClient client = new HttpClient
                {
                    Timeout = new System.TimeSpan(0, 0, 10)
                })
                {
                    var result = client.GetStringAsync("https://pavelstudio.com/api/" + path + "?type=html");
                    content = result.Result;
                }
            }
            catch (Exception Ex)
            {
                content = "Ошибка подключения к серверу мониторинга" + Ex.ToString();
            }

            return content;
        }

        public void CheckUpdate(int type = 0)
        {
            string currentHash;
            string currentDir = Environment.CurrentDirectory;
            string fullPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string exeName = System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);

            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = System.IO.File.OpenRead(fullPath))
                {
                    currentHash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                }
            }

            using (System.IO.StreamWriter sw = System.IO.File.CreateText(currentDir + @"\md5.hash"))
            {
                sw.Flush();
                sw.Write(currentHash);
                sw.Close();
            }

            if (System.Diagnostics.Debugger.IsAttached)
            {
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(currentDir + @"\version.inf"))
                {
                    sw.Flush();
                    sw.Write(MCGLForm._MCGLForm.version);
                    sw.Close();
                }
            }

            if (System.Diagnostics.Debugger.IsAttached) {
                //return;
            }

            string serverHash;
            try
            {
                using (HttpClient client = new HttpClient
                {
                    Timeout = new System.TimeSpan(0, 0, 10)
                })
                {
                    serverHash = client.GetStringAsync("https://raw.githubusercontent.com/PavelMister/MCGL-Diagnostic/master/bin/Debug/md5.hash?nocache=" + System.DateTime.Now.ToString()).Result;
                }
            } catch {
                MessageBox.Show("Ошибка подключения к серверу обновления");
                return;
            }

            if (currentHash == null)
            {
                MessageBox.Show("Ошибка, обновление на Вашем устройстве недоступно. (Отсутствует NET.Framework 4.6.1)");
                return;
            }
            else
            {
                string version = "0.0.1";
                try
                {
                    using (HttpClient client = new HttpClient
                    {
                        Timeout = new System.TimeSpan(0, 0, 10)
                    })
                    {
                        version = client.GetStringAsync("https://raw.githubusercontent.com/PavelMister/MCGL-Diagnostic/master/bin/Debug/version.inf?nocache=" + System.DateTime.Now.ToString()).Result;
                    }
                }
                catch { };
                if (serverHash.Trim() != currentHash.Trim())
                {
                    DialogResult result = MessageBox.Show("Обнаружено обновление приложения (v" + version + "), обновить сейчас?", "Обнаружено обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            var p = new System.Diagnostics.Process();
                            p.StartInfo.FileName = "MCGL-DiagnosticUpdater.exe";
                            p.StartInfo.Arguments = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
                            p.Start();
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                        }
                        catch (Exception ex) {
                            MessageBox.Show("Произошла непредвиденная ошибка при запуске MCGL-DiagnosticUpdater.exe\r\n" + "\r\n" + ex.ToString());
                        }
                    }
                }
            }
        }

        public async Task<int[]> TestRepositoryConnection()
        {
            MCGLForm._MCGLForm.ClearResult();
            MCGLForm._MCGLForm.SetUnsetReadonlyResult();
            var repositoryUrls = new[] { "http://f1.mcgl.ru", "http://f2.mcgl.ru", "http://f3.mcgl.ru" };

            int countAvailableRepServer = 0;
            int countAvaiableRepUser = 0;
            MCGLForm._MCGLForm.UpdateResult("======= Тест запущен =======" + Environment.NewLine);
            foreach (string repositoryUrl in repositoryUrls)
            {
                bool server = await this.StartTestByUrl(repositoryUrl);

                if (server == false)
                {
                    bool availableByApi = false;
                    try
                    {
                        using (HttpClient client = new HttpClient
                        {
                            Timeout = new System.TimeSpan(0, 0, 10)
                        })
                        {
                            if (await client.GetStringAsync("https://pavelstudio.com/api/check-available-url?url=" + repositoryUrl + "&type=plaintext") == "1")
                            {
                                availableByApi = true;
                            }
                        }
                    } catch { }

                    if (availableByApi)
                    {
                        countAvailableRepServer++;
                        MCGLForm._MCGLForm.UpdateResult("Репозиторий '" + repositoryUrl + "' - недоступен только у Вас" + Environment.NewLine);
                    } else {
                        MCGLForm._MCGLForm.UpdateResult("Репозиторий '" + repositoryUrl + "' - сейчас недоступен для всех, повторите позже" + Environment.NewLine);
                    }
                }
                else
                {
                    countAvaiableRepUser++;
                    MCGLForm._MCGLForm.UpdateResult("Репозиторий '" + repositoryUrl + "' - доступен ;)" + Environment.NewLine);
                }
            }
            MCGLForm._MCGLForm.UpdateResult("======= Тест завершен =======" + Environment.NewLine);
            MCGLForm._MCGLForm.SetUnsetReadonlyResult();
            return new int[2] { countAvailableRepServer, countAvaiableRepUser };
        }
        

        public void TestConnectionForum()
        {
            var tasks = new System.Collections.Generic.List<Task>();
            var repositoryUrls = new[] { "https://forum.minecraft-galaxy.ru", "https://minecraft-galaxy.ru" };

            List<string> results = new List<string> { };
            foreach (string repositoryUrl in repositoryUrls)
            {

                int failed = 0;
                tasks.Add(Task.Run(() => {
                    try
                    {
                        var stopwatch = Stopwatch.StartNew();
                        bool server = false;
                        using (HttpClient client = new HttpClient
                        {
                            Timeout = new System.TimeSpan(0, 0, 10)
                        })
                        {
                            {
                                try
                                {
                                    string content = client.GetStringAsync(repositoryUrl).Result;
                                    if (!String.IsNullOrEmpty(content))
                                        server = true;
                                }
                                catch { }
                            }
                        }

                        bool availableByApi = false;
                        using (HttpClient client = new HttpClient
                        {
                            Timeout = new System.TimeSpan(0, 0, 10)
                        })
                        {
                            if (client.GetStringAsync("https://pavelstudio.com/api/check-available-url?url=" + repositoryUrl + "&type=plaintext").Result == "1")
                            {
                                availableByApi = true;
                            }
                        }

                        if (server == false)
                        {
                            string errorMessage = "Сайт '" + repositoryUrl + "' - сейчас недоступен для всех, повторите позже" + Environment.NewLine;
                            if (availableByApi)
                            {
                                errorMessage = "Сайт '" + repositoryUrl + "' - недоступен только у Вас" + Environment.NewLine;
                            }

                            results.Add(errorMessage + Environment.NewLine);
                        }
                        else
                        {
                            results.Add(repositoryUrl + "' - доступен ;)" + Environment.NewLine);
                        }

                        stopwatch.Stop();
                    }
                    catch
                    {
                        Interlocked.Increment(ref failed);
                        throw;
                    }
                }));
            }
            Task t = Task.WhenAll(tasks);
            try
            {
                t.Wait();
            }
            catch { }
           // await Task.CompletedTask;

            foreach (string result in results)
            {
                MCGLForm._MCGLForm.UpdateResult(result);
            }
        }

        private async Task<bool> StartTestByUrl(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient
                {
                    Timeout = new System.TimeSpan(0, 0, 10)
                })
                {
                    await client.GetStringAsync(url);
                }
            } catch {
                return false;
            }
            return true;
        }

        public async Task<bool> GetDecision(string decisionMessage)
        {
            string content;
            try
            {
                using (HttpClient client = new HttpClient
                {
                    Timeout = new System.TimeSpan(0, 0, 10)
                }) {
                    content = await client.GetStringAsync("https://pavelstudio.com/mcgl_reason/" + decisionMessage + ".txt");
                }
            }
            catch {
                content = "ERROR GET DECISION MESSAGE.";
            }

            Popup popup = new Popup();
            popup.SetMessage(content);
            DialogResult dialogresult = popup.ShowDialog();
            return true;
        }
    }
}
