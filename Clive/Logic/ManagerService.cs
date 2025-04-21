using Clive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clive.Logic
{
    public class ManagerService
    {
        private List<RetrievedFile> files = new List<RetrievedFile>();
        private List<Extesion> selectedExtesions = new List<Extesion>();
        List<string> filteredFilePaths = new List<string>();

        List<string> configFile = File.ReadLines("C:\\Users\\jonhe\\OneDrive\\Documentos\\Clive\\cliveConfig.txt").ToList();

        //Pegar configurações do arquivo de configurações
        public void updateList()
        {
            var fileLine = "";
            foreach (var line in configFile)
                fileLine += line;
            
            string[] extensionLists = fileLine.Split(';')[0].Split(':')[1].Replace("[", string.Empty).Replace("]", string.Empty).Replace('"', ' ').Replace(" ", string.Empty).Split(",");
             
            selectedExtesions.Clear();
            foreach(var extension in extensionLists)
            selectedExtesions.Add(new Extesion() { 
                name = extension,
                isSelected = true,});

            filteredFilePaths.Clear();
            filteredFilePaths = new List<string>(); //POPULATE LIST 
        }

        public void updateConfigFile()
        {

        }



        public void DeleteFiles(List<RetrievedFile> files)
        {
            try
            {
                foreach (var file in files)
                {
                    if (file.isSelected)
                        File.Delete(filteredFilePaths[file.Id]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        
        }
        public List<RetrievedFile> GetFiles() { return files; }
        public List<Extesion> GetExtesions() { return selectedExtesions;}

    }
}
