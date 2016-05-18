using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using Google.Apis.Download;
using Google.Apis.Requests;

namespace GoogleDrive
{
    public enum UploadFileType
    {
        None,
        ImageJPG,
        ImagePNG,
        Doc,
        MsWord,
        Excel,
        Text,
        PDF,
        Folder,
        File,
        JSON
    }
    public class MyFile
    {
        public string ID { get; set; }
        public string linkView { get; set; }
        public string link { get; set; }
    }
    public class GDrive
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "Drive API .NET Quickstart";

        public GDrive()
        {
            try
            {
                UserCredential credential;

                using (var stream =
                    new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }

                // Create Drive API service.
                driveService = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        DriveService driveService;
        public string CreateFolder(string name)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = name;
            fileMetadata.MimeType = "application/vnd.google-apps.folder";
            var request = driveService.Files.Create(fileMetadata);
            request.Fields = "id";
            var file = request.Execute();
            return file.Id;
        }
        public string GetIDFolder(string name)
        {
            var listFile = new List<string>();
            string pageToken = null;
            do
            {
                var request = driveService.Files.List();
                request.Q = "mimeType='application/vnd.google-apps.folder' and name='" + name + "'";
                request.Spaces = "drive";
                request.Fields = "nextPageToken, files(id, name)";
                request.PageToken = pageToken;
                var result = request.Execute();
                foreach (var file in result.Files)
                {
                    listFile.Add(file.Id);
                }
                pageToken = result.NextPageToken;
            } while (pageToken != null);
            if (listFile.Count > 0)
            {
                return listFile[0];
            }
            else
            {
                return CreateFolder(name);
            }
        }
        
        
        public MyFile Upload(string filePath, string name,UploadFileType type, string folder)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = name;
            fileMetadata.Permissions = new List<Permission> { };
            var realFolderId = GetIDFolder(folder);
            fileMetadata.Parents = new List<string> { realFolderId };
            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(filePath,
                System.IO.FileMode.Open))
            {
                request = driveService.Files.Create(
                    fileMetadata, stream, getFileType(type));
                request.Fields = "id,webContentLink,webViewLink";
                request.Upload();
            }
            var file = request.ResponseBody;
            setPermission(file.Id);
            var kq = new MyFile();
            kq.ID = file.Id;
            kq.link = file.WebContentLink;
            kq.linkView = file.WebViewLink;
            return kq;
        }
        public void Download(string filePath,string fileName,string folder)
        {
            var l = findFile(fileName, folder);
            if (l.Count>0)
            {
                download(filePath, l[0].Id);
            }
        }
        public void setPermission(string fileId)
        {
            var batch = new BatchRequest(driveService);
            BatchRequest.OnResponse<Permission> callback = delegate (
                Permission permission,
                RequestError error,
                int index,
                System.Net.Http.HttpResponseMessage message)
            {
                if (error != null)
                {
                    // Handle error
                    Console.WriteLine(error.Message);
                }
                else
                {
                    Console.WriteLine("Permission ID: " + permission.Id);
                }
            };
            Permission userPermission = new Permission();
            userPermission.Type = "anyone";
            userPermission.Role = "reader";
            //userPermission.EmailAddress = "example@appsrocks.com";
            var request = driveService.Permissions.Create(userPermission, fileId);
            request.Fields = "id";
            batch.Queue(request, callback);

            var task = batch.ExecuteAsync();
        }

        private void download(string filePath,string fileID)
        {
            var request = driveService.Files.Get(fileID);
            var stream = new FileStream(filePath,FileMode.OpenOrCreate);

            request.MediaDownloader.ProgressChanged +=
                (IDownloadProgress progress) =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                            {
                                Console.WriteLine(progress.BytesDownloaded);
                                break;
                            }
                        case DownloadStatus.Completed:
                            {
                                Console.WriteLine("Download complete.");
                                break;
                            }
                        case DownloadStatus.Failed:
                            {
                                Console.WriteLine("Download failed.");
                                break;
                            }
                    }
                };
            request.Download(stream);
        }
        private List<Google.Apis.Drive.v3.Data.File> findFile(string name,string folder)
        {
            var l = new List<Google.Apis.Drive.v3.Data.File>();
            string pageToken = null;
            do
            {
                var request = driveService.Files.List();
                var fol = getFolder(folder);
                if (fol.Count==0)
                {
                    return l;
                }
                string query = "name=" + "'" + name + "'" + " and " +
                                "'" + fol[0].Id +"'" + " in parents";
                request.Q = query;
                request.Spaces = "drive";
                request.Fields = "nextPageToken, files(id, name)";
                request.PageToken = pageToken;
                var result = request.Execute();
                foreach (var file in result.Files)
                {
                    l.Add(file);
                }
                pageToken = result.NextPageToken;
            } while (pageToken != null);
            return l;
        }
        private string getFileType(UploadFileType type)
        {
            switch (type)
            {
                case UploadFileType.ImageJPG:
                    return "image/jpeg";
                case UploadFileType.ImagePNG:
                    return "image/png";
                case UploadFileType.Doc:
                    return "application/vnd.oasis.opendocument.text";
                case UploadFileType.MsWord:
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case UploadFileType.Excel:
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case UploadFileType.Text:
                    return "text/plain";
                case UploadFileType.PDF:
                    return "application/pdf";
                case UploadFileType.Folder:
                    return "application/vnd.google-apps.folder";
                case UploadFileType.File:
                    return "application/vnd.google-apps.drive-sdk";
                case UploadFileType.JSON:
                    return "application/vnd.google-apps.script+json";
                default:
                    return "";
            }
        }
        private List<Google.Apis.Drive.v3.Data.File> getFolder(string folder)
        {
            var listFile = new List<Google.Apis.Drive.v3.Data.File>();
            string pageToken = null;
            do
            {
                var request = driveService.Files.List();
                request.Q = "mimeType='application/vnd.google-apps.folder' and name='" + folder + "'";
                request.Spaces = "drive";
                request.Fields = "nextPageToken, files(id, name)";
                request.PageToken = pageToken;
                var result = request.Execute();
                foreach (var file in result.Files)
                {
                    listFile.Add(file);
                }
                pageToken = result.NextPageToken;
            } while (pageToken != null);
            return listFile;
        }
    }
}
