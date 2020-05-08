using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.Collections;
using DataAccess;
using System.IO;
using System.Reflection;
namespace DMFileManager
{
    public partial class DataFile
    {
        public virtual List<string> GetAllFilesFromFolder()
        {
            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles(this.FolderName));
            return files;
        }

        public void CreateFolder(string folderName)
        {
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);
        }

        public static bool CheckIfFolderExists(string folderName)
        {
            if (Directory.Exists(folderName))
                return true;
            else
                return false;
        } 

        public string CheckIfFileExstsAndGetNewNames(string fullPath)
        {
            string newFileName = fullPath;
            bool found = CheckIfFileExists(fullPath);
            while (found)
            {
                newFileName = newFileName.Substring(0, newFileName.Length - 4) + "_New" + newFileName.Substring(newFileName.Length - 4, 4);
                found = CheckIfFileExists(newFileName);
            }
            return newFileName;
        }

        public bool CheckIfFileExists(string FullPath)
        {
            return File.Exists(FullPath);
        }

        public void MoveFile(string OriginalFileName, string NewFileName)
        {
            if (CheckIfFileExists(NewFileName))
                DeleteFile(NewFileName);
            File.Move(OriginalFileName, NewFileName);
        }

        public void CopyFile(string OriginalFileName, string NewFileName)
        {
            //if (CheckIfFileExists(NewFileName))
            //    DeleteFile(NewFileName);
            System.IO.File.Copy(OriginalFileName, NewFileName, true);
        }

        public void DeleteFile(string FileName)
        {
            File.Delete(FileName);
        }

        public string GetOutputFileName(string FolderName, string FileName)
        {
            string returnFileName = string.Empty;
            string folderName = FolderName;
            string newFileName = FileName;
            string fullPath = folderName + FileName;
            returnFileName = fullPath;

            CreateFolder(FolderName);
            bool found = CheckIfFileExists(fullPath);

            while (found)
            {
                newFileName = newFileName.Substring(0, newFileName.Length - 4) + "_New" + newFileName.Substring(newFileName.Length - 4, 4);
                returnFileName = folderName + newFileName;
                found = CheckIfFileExists(returnFileName);
            }
            return returnFileName;
        }
    }
}
