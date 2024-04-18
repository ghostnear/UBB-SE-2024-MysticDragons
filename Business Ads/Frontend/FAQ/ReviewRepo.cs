using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Frontend.FAQ
{
    public class ReviewRepo : IReview
    {
            private string xmlFilePath;
            List<ReviewClass> reviewList;
            public ReviewRepo()
            {
                reviewList = new List<ReviewClass>();
                string binDirectory = "\\bin";
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string pathUntilBin;


                int index = basePath.IndexOf(binDirectory);
                pathUntilBin = basePath.Substring(0, index);
                string s = $"\\XMLFiles\\REVIEWitems.xml";
                xmlFilePath = pathUntilBin + s;
                LoadFromXml();
            }
        private void LoadFromXml()
        {
            try
            {
                if (File.Exists(xmlFilePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ReviewClass), new XmlRootAttribute("ReviewClass"));

                    reviewList = new List<ReviewClass>();
                    using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open))
                    using (XmlReader reader = XmlReader.Create(fileStream))
                    {
                        while (reader.ReadToFollowing("ReviewClass"))
                        {
                            ReviewClass review = (ReviewClass)serializer.Deserialize(reader);
                            reviewList.Add(review);
                        }
                    }
                }
                else
                {
                    reviewList = new List<ReviewClass>();
                }
            }
            catch { }
        }

        private void SaveToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ReviewClass>), new XmlRootAttribute("Reviews"));

            using (FileStream fileStream = new FileStream(xmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, reviewList);
            }
        }

            public List<ReviewClass> GetReviewList()
            {
                return reviewList;
            }

            public void addReview(ReviewClass newR)
            {
                reviewList.Add(newR);
                SaveToXml();
            }


    }
        interface IReview
        {
            public List<ReviewClass> GetReviewList();
            public void addReview(ReviewClass newR);

        }
    }


