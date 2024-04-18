using System.Xml;
using System.Xml.Serialization;
using Backend.Models;

namespace Backend.Repositories
{
    public class FAQRepository : IFAQ
    {

        private string xmlFilePath;
        private List<FAQ> faqList;

        public FAQRepository()
        {
            faqList = new List<FAQ>();
            string binDirectory = "\\bin";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string pathUntilBin;


            int index = basePath.IndexOf(binDirectory);
            pathUntilBin = basePath.Substring(0, index);
            string s = $"\\XMLFiles\\FAQitems.xml";
            xmlFilePath = pathUntilBin + s;
            LoadFAQsFromXml();
        }

        public List<FAQ> GetFAQList()
        {
            return faqList;
        }

        private void LoadFAQsFromXml()
        {
            try
            {
                if (File.Exists(xmlFilePath))
                {
                    XmlSerializer serializer = new(typeof(FAQ), new XmlRootAttribute("FAQ"));

                    faqList = new List<FAQ>();

                    using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open))
                    using (XmlReader reader = XmlReader.Create(fileStream))
                    {
                        while (reader.ReadToFollowing("FAQ"))
                        {
                            FAQ faq = (FAQ)serializer.Deserialize(reader);
                            faqList.Add(faq);
                        }
                    }
                }
                else
                {
                    faqList = new List<FAQ>();
                }
            }
            catch { }
        }

        private void SaveFAQsToXml()
        {
            XmlSerializer serializer = new(typeof(List<FAQ>), new XmlRootAttribute("FAQs"));

            using (FileStream fileStream = new(xmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, faqList);
            }
        }

        public void addFAQ(Backend.Models.FAQ newQ)
        {
            faqList.Add(newQ);
            SaveFAQsToXml();
        }

        public void deleteFAQ(Backend.Models.FAQ q)
        {
            faqList.Remove(q);
            SaveFAQsToXml();
        }
    }

    interface IFAQ
    {
        List<Backend.Models.FAQ> GetFAQList();
        void addFAQ(Backend.Models.FAQ newQ);
        void deleteFAQ(Backend.Models.FAQ q);
    }
}
