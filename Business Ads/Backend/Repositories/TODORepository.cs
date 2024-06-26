﻿using System.Xml.Serialization;
using System.Xml;
using Backend.Models;

namespace Backend.Repositories
{
    public class TODORepository : IRepository
    {
        private List<TODOClass> todos;
        private readonly string xmlFilePath;
        private static int _lastId = 0;

        public TODORepository() 
        { 
            todos = new List<TODOClass>();
            string binDirectory = "\\bin";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string pathUntilBin;


            int index = basePath.IndexOf(binDirectory);
            pathUntilBin = basePath.Substring(0, index);
            string s = $"\\XMLFiles\\TODOitems.xml";
            xmlFilePath = pathUntilBin + s;
            LoadFromXml();
        }

        private void LoadFromXml()
        {
            try
            {
                if (File.Exists(xmlFilePath))
                {
                    XmlSerializer serializer = new(typeof(TODOClass), new XmlRootAttribute("TODOClass"));

                    todos = new List<TODOClass>();

                    using (FileStream fileStream = new(xmlFilePath, FileMode.Open))
                    using (XmlReader reader = XmlReader.Create(fileStream))
                    {
                        while (reader.ReadToFollowing("TODOClass"))
                        {
                            TODOClass todo = (TODOClass)serializer.Deserialize(reader);
                            todo.ID = _lastId++;
                            todos.Add(todo);
                        }
                    }
                }
                else
                {
                    todos = new List<TODOClass>();
                }
            }
            catch { }
        }

        private void SaveToXml()
        {
            XmlSerializer serializer = new(typeof(List<TODOClass>), new XmlRootAttribute("TODOs"));

            using (FileStream fileStream = new(xmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, todos);
            }
        }
        public void addingTODO(TODOClass newTODO)
        {
            newTODO.ID = _lastId++;
            todos.Add(newTODO);
            SaveToXml();
        }
        public void removingTODO(TODOClass newTODO)
        {
            todos.Remove(newTODO);
            SaveToXml();

        }

        public List<TODOClass> getTODOS()
        {
            return todos;
        }



    }

    interface IRepository
    {
        public void addingTODO(TODOClass newTODO);
        public void removingTODO(TODOClass newTODO);
        public List<TODOClass> getTODOS();
    }
}
