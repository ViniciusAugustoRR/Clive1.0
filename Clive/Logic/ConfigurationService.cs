using Clive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clive.Logic
{
    public class ConfigurationService
    {

        List<RetrievedFile> files = new List<RetrievedFile>();
        private List<Extesion> selectedExtesions = new List<Extesion>();
        List<string> filteredFilePaths = new List<string>();

        List<string> configFile =  File.ReadLines("C:\\Users\\jonhe\\OneDrive\\Documentos\\Clive\\cliveConfig.txt").ToList();

        //Pegar configurações do arquivo de configurações
        public void updateList()
        {
            var s = "";
            foreach (var line in configFile) {
                s += line;
            }
            return;
            selectedExtesions.Clear();
            selectedExtesions = new List<Extesion>() { };  //POPULATE LIST
            
            filteredFilePaths.Clear();
            filteredFilePaths = new List<string>(); //POPULATE LIST 
        }


        public void DeleteFiles()
        {

        }
    
    }


}
