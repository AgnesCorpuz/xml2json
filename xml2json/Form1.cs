using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace xml2json
{
    public partial class frmXml2Json : Form
    {        
        public class XML
        {
            public string uuid { get; set; }
            public string name { get; set; }
            public string blurb { get; set; }
            public string splashTitle { get; set; }
            public string splashDescription { get; set; }
            public string[] header { get; set; }
            public string[] description { get; set; }
            public string[] categoriesId { get; set; }
            public string myAppLogoIconUrl { get; set; }
            public string companyName { get; set; }
            public string[] demoUrl { get; set; }
            public string[] language { get; set; }
            //public string version { get; set; }
            public string email { get; set; }
            public string termsUrl { get; set; }
            public string knowledgebaseUrl { get; set; }
            public string[] imageUrl { get; set; }
            public string[] categoriesName { get; set; }
            public string referUrl { get; set; }
        }

        [XmlRoot("categories")]
        public class Categories
        {
            [XmlElement("product-category")]
            public ProductCategoryObj[] productCategory { get; set; }
        }

        [XmlRoot("category")]
        public class CategoryObj
        {
            [XmlElement("properties-translations")]
            public string propertiesTranslations { get; set; }
            [XmlElement("id")]
            public string id { get; set; }
            [XmlElement("name")]
            public string name { get; set; }
        }

        [XmlRoot("subCategory")]
        public class SubCategoryObj
        {
            [XmlElement("properties-translations")]
            public string propertiesTranslations { get; set; }
            [XmlElement("id")]
            public string id { get; set; }
            [XmlElement("name")]
            public string name { get; set; }
        }

        public class ProductCategoryObj
        {
            [XmlElement("id")]
            public string id { get; set; }
            [XmlElement("category")]
            public CategoryObj category { get; set; }
            [XmlElement("subCategory")]
            public SubCategoryObj subcategory { get; set; }
        }

        public class JSON
        {
            public string id { get; set; }
            public string registryId { get; set; }
            public JsonObj name { get; set; }
            public JsonObj tagline { get; set; }
            public JsonObj briefDescription { get; set; }
            public JsonObj fullDescription { get; set; }
            public List<NameObj> platforms { get; set; }
            public string companyLogo { get; set; }
            public string appLogo { get; set; }
            public JsonObj companyName { get; set; }
            public JsonObj website { get; set; }
            public string[] videoLinks { get; set; }
            public string[] languages { get; set; }
            //public string version { get; set; }
            public string vendorEmail { get; set; }
            public string termsOfService { get; set; }
            public string helpDocumentationURL { get; set; }
            public string[] screenshots { get; set; }
            public JsonObj marketingURL { get; set; }
            public string[] industries { get; set; }
            public string cid { get; set; }
        }

        public class JsonObj
        {
            public string enus { get; set; }
        }

        public class NameObj
        {
            public string name { get; set; }
            public string[] subcategories { get; set; }
        }

        public class BusinessOptimiztion
        {
            public string name { get; set; }
            public string[] workloadManagement { get; set; }
            public string[] analytics { get; set; }
            public string[] platformIntegration { get; set; }
            public string[] platformEnhancement { get; set; }
        }

        public class CustomerEngagement
        {
            public string name { get; set; }
            public string[] digital { get; set; }
            public string[] selfService { get; set; }
            public string[] outbound { get; set; }
            public string[] artificialIntelligence { get; set; }
        }

        public class EmployeeEngagement
        {
            public string name { get; set; }
            public string[] workforceOptimization { get; set; }
            public string[] omniChannel { get; set; }
            public string[] collaboration { get; set; }
            public string[] knowledgeManagement { get; set; }
        }

        public class CategoriesJson
        {
            public BusinessOptimiztion BusinessOptimiztion { get; set; }
            public CustomerEngagement CustomerEngagement { get; set; }
            public EmployeeEngagement EmployeeEngagement { get; set; }
        }

        public frmXml2Json()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML Document (.xml)|*.xml";
            fileDialog.FilterIndex = 1;
            fileDialog.Multiselect = false;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Put file path in textbox
                string sFileName = fileDialog.FileName;
                string sFilePath = sFileName.Substring(0, sFileName.LastIndexOf('\\'));
                txtFilePath.Text = sFileName;

                // Get folder path
                string sFolderPath = sFilePath.Substring(0, sFilePath.LastIndexOf('\\'));
                string newFolder = Path.GetPathRoot(sFolderPath);

                // Get Folder Name
                var length = sFilePath.Length;
                var index = sFilePath.LastIndexOf("-") + 1;
                var ind = sFilePath.LastIndexOf("\\") + 1;                
                string sFolderName = sFilePath.Substring(index, length - index);
                string folderName = sFilePath.Substring(ind, length - ind);

                // Get App Number
                var ind1 = folderName.LastIndexOf("-");                
                string appNum = folderName.Substring(0, ind1);
                var ind2 = appNum.LastIndexOf("-") + 1;
                var foldLeng = appNum.Length;
                string appNum1 = appNum.Substring(ind2, foldLeng - ind2);

                // Create new folder
                string pathString = System.IO.Path.Combine(sFolderPath, "external-" + sFolderName);
                System.IO.Directory.CreateDirectory(pathString);
                string imagefolder = System.IO.Path.Combine(pathString, "images");
                System.IO.Directory.CreateDirectory(imagefolder);
                string addtlFiles = string.Empty;

                // Copy images and PDF files
                string appFolder = sFilePath + "\\app_resources";
                string screenshotFolder = sFilePath + "\\app_resources\\" + appNum1 + "\\screenshot";
                string[] imgfiles = Directory.GetFiles(appFolder, "*.png*", SearchOption.AllDirectories);
                string[] pdffiles = Directory.GetFiles(appFolder, "*.pdf*", SearchOption.AllDirectories);
                string[] screenshotfiles = null;
                string myAppLogoIcon = sFilePath + "\\app_resources\\" + appNum1 + "\\myAppIcon";
                //string[] myAppLogoIconFiles = Directory.GetFiles(myAppLogoIcon, "*.png*", SearchOption.AllDirectories);
                string[] myAppLogoIconFiles = null;

                if (Directory.Exists(myAppLogoIcon))
                {
                    myAppLogoIconFiles = Directory.GetFiles(myAppLogoIcon, "*.png*", SearchOption.AllDirectories);

                    foreach (string s in myAppLogoIconFiles)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(imagefolder, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }

                //if (Directory.Exists(screenshotFolder))
                //{
                //    screenshotfiles = Directory.GetFiles(screenshotFolder, "*.png*", SearchOption.AllDirectories);
                //}

                //foreach (string s in imgfiles)
                //{
                //    string fileName = System.IO.Path.GetFileName(s);
                //    string destFile = System.IO.Path.Combine(imagefolder, fileName);
                //    System.IO.File.Copy(s, destFile, true);
                //}                

                if (pdffiles.Length > 0)
                {
                    // Create additionalfiles folder if ther are PDF files
                    addtlFiles = System.IO.Path.Combine(pathString, "additionalfiles");
                    System.IO.Directory.CreateDirectory(addtlFiles);

                    foreach (string s in pdffiles)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(addtlFiles, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }

                // Display XML file contents
                XmlDocument doc = new XmlDocument();
                doc.Load(fileDialog.FileName);
                txtXmlText.Text = XElement.Parse(doc.OuterXml).ToString();

                // Get XML elements by tag name
                XML xml = new XML();
                
                if (doc.SelectSingleNode(".//uuid") != null)
                {
                    XmlNode uuid = doc.SelectSingleNode(".//uuid");
                    xml.uuid = uuid.InnerText;
                }
                                
                if (doc.SelectSingleNode(".//name") != null)
                {
                    XmlNode name = doc.SelectSingleNode(".//name");
                    xml.name = name.InnerText;
                }
                                
                if (doc.SelectSingleNode(".//listing/blurb") != null)
                {
                    XmlNode blurb = doc.SelectSingleNode(".//listing/blurb");
                    xml.blurb = blurb.InnerText;
                }
                                
                if (doc.SelectSingleNode(".//overview/splashTitle") != null)
                {
                    XmlNode splashTitle = doc.SelectSingleNode(".//overview/splashTitle");
                    xml.splashTitle = splashTitle.InnerText;
                }
                                
                if (doc.SelectSingleNode(".//overview/splashDescription") != null)
                {
                    XmlNode splashDescription = doc.SelectSingleNode(".//overview/splashDescription");
                    xml.splashDescription = splashDescription.InnerText;
                }
                                
                if (doc.SelectSingleNode(".//listing/myAppLogoIconUrl") != null)
                {
                    XmlNode myAppLogoIconUrl = doc.SelectSingleNode(".//listing/myAppLogoIconUrl");
                    xml.myAppLogoIconUrl = myAppLogoIconUrl.InnerText;
                }
                
                if (doc.SelectSingleNode(".//listing/companyName") != null)
                {
                    XmlNode companyName = doc.SelectSingleNode(".//listing/companyName");
                    xml.companyName = companyName.InnerText;
                }
                
                if (doc.SelectSingleNode(".//support/email") != null)
                {
                    XmlNode email = doc.SelectSingleNode(".//support/email");
                    xml.email = email.InnerText;
                }

                if (doc.SelectSingleNode(".//termsUrl") != null)
                {
                    XmlNode termsUrl = doc.SelectSingleNode(".//termsUrl");
                    xml.termsUrl = termsUrl.InnerText;
                }
                                
                if (doc.SelectSingleNode(".//support/knowledgebaseUrl") != null)
                {
                    XmlNode knowledgebaseUrl = doc.SelectSingleNode(".//support/knowledgebaseUrl");
                    xml.knowledgebaseUrl = knowledgebaseUrl.InnerText;
                }
                                
                if (doc.SelectSingleNode(".//referUrl") != null)
                {
                    XmlNode referUrl = doc.SelectSingleNode(".//referUrl");
                    xml.referUrl = referUrl.InnerText;
                }                

                XDocument xdoc = XDocument.Load(fileDialog.FileName);
                XElement root = XElement.Parse(xdoc.ToString());
                //var version = (from n in root.Descendants("version")
                //                select n).ToString();

                //if (version != null || version != string.Empty)
                //{
                //    xml.version = version;
                //}

                if (doc.SelectSingleNode(".//listing/languages/language") != null)
                {
                    XmlNodeList language = doc.SelectNodes(".//listing/languages/language");
                    List<string> list = new List<string>();

                    foreach (XmlNode n in language)
                    {
                        list.Add(n.InnerText);
                    }

                    xml.language = list.ToArray();
                }

                List<string> headerList = new List<string>();
                List<string> descList = new List<string>();

                if (doc.SelectNodes(".//overview/benefits/benefit/title") != null)
                {
                    XmlNodeList header = doc.SelectNodes(".//overview/benefits/benefit/title");
                    
                    foreach (XmlNode n in header)
                    {
                        headerList.Add(n.InnerText);
                    }  
                }

                if (doc.SelectNodes(".//overview/benefits/benefit/description") != null)
                {
                    XmlNodeList description = doc.SelectNodes(".//overview/benefits/benefit/description");

                    foreach (XmlNode n in description)
                    {
                        descList.Add(n.InnerText);
                    }
                }

                if (doc.SelectNodes(".//features/feature/header") != null)
                {
                    XmlNodeList header = doc.SelectNodes(".//features/feature/header");

                    foreach (XmlNode n in header)
                    {
                        headerList.Add(n.InnerText);
                    }
                }

                if (doc.SelectNodes(".//features/feature/description") != null)
                {
                    XmlNodeList description = doc.SelectNodes(".//features/feature/description");

                    foreach (XmlNode n in description)
                    {
                        descList.Add(n.InnerText);
                    }
                }

                xml.header = headerList.ToArray();
                xml.description = descList.ToArray();

                if (doc.SelectNodes(".//tags/tag/id") != null)
                {
                    XmlNodeList categoriesId = doc.SelectNodes(".//tags/tag/id");
                    List<string> list = new List<string>();

                    foreach (XmlNode n in categoriesId)
                    {
                        list.Add(n.InnerText);
                    }

                    xml.categoriesId = list.ToArray();
                }

                var imageUrl = (from n in root.Descendants("imageUrl")
                                select n).ToList();

                if (imageUrl != null)
                {
                    List<string> list = new List<string>();

                    foreach (XElement n in imageUrl)
                    {
                        list.Add(n.Value);
                    }

                    xml.imageUrl = list.ToArray();
                }

                if (doc.SelectNodes(".//tags/tag/name") != null)
                {
                    XmlNodeList categoriesName = doc.SelectNodes(".//tags/tag/name");
                    List<string> list = new List<string>();

                    foreach (XmlNode n in categoriesName)
                    {
                        list.Add(n.InnerText);
                    }

                    xml.categoriesName = list.ToArray();
                }

                if (doc.SelectSingleNode(".//overview/demoUrl") != null)
                {
                    XmlNodeList demoUrl = doc.SelectNodes(".//overview/demoUrl");
                    List<string> list = new List<string>();

                    foreach (XmlNode n in demoUrl)
                    {
                        list.Add(n.InnerText);
                    }

                    xml.demoUrl = list.ToArray();
                }

                Categories result = new Categories();

                if (doc.SelectSingleNode(".//categories") != null)
                {
                    XmlNode categories = doc.SelectSingleNode(".//categories");

                    string text = categories.OuterXml;

                    XmlSerializer serializer = new XmlSerializer(typeof(Categories));
                    using (TextReader reader = new StringReader(text))
                    {
                        result = (Categories)serializer.Deserialize(reader);
                    }

                    // Call GenerateCategories(xml.uuid, categories)
                }

                // Convert XML to JSON string
                JSON json = new JSON();
                List<NameObj> JsonPlatformsList = new List<NameObj>();
                List<string> catList = new List<string>();
                List<string> images = new List<string>();
                List<JsonObj> pdfs = new List<JsonObj>();
                string fullDesc = string.Empty;
                string subLoc = string.Empty;

                JsonObj jsonName = new JsonObj();
                JsonObj jsonTagline = new JsonObj();
                JsonObj jsonBriefDesc = new JsonObj();
                JsonObj jsonFullDesc = new JsonObj();
                JsonObj jsonCompanyName = new JsonObj();
                JsonObj jsonWebsite = new JsonObj();
                JsonObj jsonMarketingURL = new JsonObj();

                for (int x = 0; x < xml.header.Length; x++)
                {                    
                    fullDesc = fullDesc + "**" + xml.header[x] + "** \n\n " + xml.description[x] + "\n\n ";                    
                }                

                foreach (var catName in xml.categoriesName)
                {
                    if (catName == "PureEngage Cloud" || catName == "PureEngage on Premises" || catName == "PureConnect Cloud" || catName == "PureConnect on Premises")
                    {
                        NameObj jsonPlatforms = new NameObj();
                        NameObj PureEngage = (from x in JsonPlatformsList where x.name == "PureEngage" select x).FirstOrDefault();
                        NameObj PureConnect = (from x in JsonPlatformsList where x.name == "PureConnect" select x).FirstOrDefault();

                        if (catName.Contains("PureEngage"))
                        {
                            if (PureEngage != null)
                            {
                                if (catName.Contains("Premise"))
                                {
                                    List<string> sub = PureEngage.subcategories.ToList();
                                    sub.Add("Premise");
                                    PureEngage.subcategories = sub.ToArray();
                                }
                                else if (catName.Contains("Cloud"))
                                {
                                    List<string> sub = PureEngage.subcategories.ToList();
                                    sub.Add("Cloud");
                                    PureEngage.subcategories = sub.ToArray();
                                }
                            }
                            else
                            {
                                jsonPlatforms.name = "PureEngage";

                                if (catName.Contains("Premise"))
                                {
                                    List<string> sub = new List<string>();
                                    sub.Add("Premise");
                                    jsonPlatforms.subcategories = sub.ToArray();
                                }
                                else if (catName.Contains("Cloud"))
                                {
                                    List<string> sub = new List<string>();
                                    sub.Add("Cloud");
                                    jsonPlatforms.subcategories = sub.ToArray();
                                }

                                JsonPlatformsList.Add(jsonPlatforms);
                            }                                
                        }
                        else if (catName.Contains("PureConnect"))
                        {
                            if (PureConnect != null)
                            {
                                if (catName.Contains("Premise"))
                                {
                                    List<string> sub = PureConnect.subcategories.ToList();
                                    sub.Add("Premise");
                                    PureConnect.subcategories = sub.ToArray();
                                }
                                else if (catName.Contains("Cloud"))
                                {
                                    List<string> sub = PureConnect.subcategories.ToList();
                                    sub.Add("Cloud");
                                    PureConnect.subcategories = sub.ToArray();
                                }
                            }
                            else
                            {
                                jsonPlatforms.name = "PureConnect";

                                if (catName.Contains("Premise"))
                                {
                                    List<string> sub = new List<string>();
                                    sub.Add("Premise");
                                    jsonPlatforms.subcategories = sub.ToArray();
                                }
                                else if (catName.Contains("Cloud"))
                                {
                                    List<string> sub = new List<string>();
                                    sub.Add("Cloud");
                                    jsonPlatforms.subcategories = sub.ToArray();
                                }

                                JsonPlatformsList.Add(jsonPlatforms);
                            }                                
                        }
                    }                                        
                }
                
                jsonTagline.enus = xml.blurb;
                jsonBriefDesc.enus = xml.splashDescription;
                jsonCompanyName.enus = xml.companyName;
                jsonWebsite.enus = "";
                jsonFullDesc.enus = fullDesc;
                
                json.id = xml.uuid;
                json.registryId = "";                
                jsonName.enus = xml.name;
                json.name = jsonName;                
                json.tagline = jsonTagline;
                json.briefDescription = jsonBriefDesc;
                json.fullDescription = jsonFullDesc;
                json.platforms = JsonPlatformsList;                               
                json.companyName = jsonCompanyName;
                json.website = jsonWebsite;
                json.videoLinks = xml.demoUrl;
                json.vendorEmail = xml.email;
                json.termsOfService = xml.termsUrl;
                json.helpDocumentationURL = xml.knowledgebaseUrl;

                List<string> lang = new List<string>();
                foreach (string l in xml.language)
                {
                    if (l == "en")
                    {
                        lang.Add("english");
                    }
                    else if (l == "fr")
                    {
                        lang.Add("french");
                    }
                    else if (l == "de")
                    {
                        lang.Add("german");
                    }
                    else if (l == "sv")
                    {
                        lang.Add("swedish");
                    }
                }
                json.languages = lang.ToArray();

                foreach (string s in pdffiles)
                {
                    string fileName = System.IO.Path.GetFileName(s);
                    string pdf = addtlFiles + "\\" + fileName;
                    int len = pdf.Length;
                    int i = pdf.LastIndexOf("external");
                    subLoc = pdf.Substring(i, len - i);
                    subLoc = subLoc.Replace("\\", "/");
                    jsonMarketingURL.enus = subLoc;
                }

                json.marketingURL = jsonMarketingURL;

                if (xml.categoriesId.Length > 3)
                {
                    string cat = "universal";
                    catList.Add(cat);
                    json.industries = catList.ToArray();
                }
                else
                {
                    json.industries = xml.categoriesId;
                }

                if (xml.referUrl != null)
                {
                    int pos = xml.referUrl.IndexOf("cid");
                    string cid = xml.referUrl.Substring(pos + 4, 15);
                    json.cid = cid;
                }
                
                if (screenshotfiles != null)
                {
                    // Uncomment once Zach has final requirement

                    //foreach (string s in screenshotfiles)
                    //{
                    //    string fileName = System.IO.Path.GetFileName(s);
                    //    string image = imagefolder + "\\" + fileName;
                    //    int len = image.Length;
                    //    int i = image.LastIndexOf("external");
                    //    subLoc = image.Substring(i, len - i);
                    //    subLoc = subLoc.Replace("\\", "/");
                    //    images.Add(subLoc);
                    //}

                    json.screenshots = images.ToArray();
                }
                
                int a = xml.myAppLogoIconUrl.Length;
                int b = xml.myAppLogoIconUrl.LastIndexOf("/") + 1;
                string file = xml.myAppLogoIconUrl.Substring(b, a - b);
                string myAppLogoImage = imagefolder + "\\" + file;
                int appLogLen = myAppLogoImage.Length;
                int i1 = myAppLogoImage.LastIndexOf("external");
                subLoc = myAppLogoImage.Substring(i1, appLogLen - i1);
                subLoc = subLoc.Replace("\\", "/");
                json.companyLogo = subLoc;
                json.appLogo = subLoc;

                var jsonCon = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);
                jsonCon = jsonCon.Replace("enus","en-us");
                jsonCon = jsonCon.Replace("null", "\"\"");
                jsonCon = jsonCon.Replace("\"registryId\": \"\",", "\"registryId\": {},");
                jsonCon = jsonCon.Replace("\"videoLinks\": \"\",", "\"videoLinks\": [],");
                jsonCon = jsonCon.Replace("\"screenshots\": \"\",", "\"screenshots\": [],");
                txtJsonText.Text = jsonCon;

                // Write JSON to file
                File.WriteAllText(pathString + "\\data.json", jsonCon);                
            }
        }

        private void GenerateCategories(string ProductId, Categories categories)
        {
            foreach (var category in categories.productCategory)
            {

            }
        }

        private void txtClose_Click(object sender, EventArgs e)
        {
            txtFilePath.Clear();
            txtXmlText.Clear();
            txtJsonText.Clear();
            this.Close();
        }

        private void txtClear_Click(object sender, EventArgs e)
        {
            txtFilePath.Clear();
            txtXmlText.Clear();
            txtJsonText.Clear();
        }
    }
}
