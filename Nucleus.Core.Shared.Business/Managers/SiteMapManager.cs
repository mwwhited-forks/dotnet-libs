using Nucleus.Blog.Contracts.Managers;
using Nucleus.Blog.Contracts.Models;
using Nucleus.Core.Shared.Contracts.Managers;
using Nucleus.Project.Contracts.Managers;
using Nucleus.Project.Contracts.Models;
using Nucleus.Vlog.Contracts.Managers;
using Nucleus.Vlog.Contracts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Nucleus.Core.Shared.Business.Managers
{
    public class SiteMapManager : ISiteMapManager
    {
        private IPublicBlogManager _publicBlogManager { get; set; }
        private IPublicLessonManager _publicVlogManager { get; set; }
        private IPublicProjectManager _publicProjectManager { get; set; }

        public SiteMapManager(
                  IPublicBlogManager publicBlogManager,
                  IPublicLessonManager publicVlogManager, 
                  IPublicProjectManager publicProjectManager
            ) 
        { 
            _publicBlogManager = publicBlogManager;
            _publicVlogManager = publicVlogManager;
            _publicProjectManager = publicProjectManager;
        }

        public async Task<string> RenderSiteMap()
        {
            // Not many good ways to do this because it is reflection of the UI Routing files

           string host = "https://nucleusaccnetapi.azurewebsites.net";

           StringBuilder output = new StringBuilder();

            using (var xml = XmlWriter.Create(output, new XmlWriterSettings { Indent = true }))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

                // Home Page
                xml.WriteStartElement("url");
                xml.WriteElementString("loc", host);
                xml.WriteEndElement();

                // Blogs
                xml.WriteStartElement("url");
                xml.WriteElementString("loc", host + "/blogs");
                xml.WriteEndElement();

                foreach (BlogModel blog in await _publicBlogManager.GetBlogs())
                {
                    xml.WriteStartElement("url");
                    xml.WriteElementString("loc", host + "/blog/" + blog.Slug);
                    xml.WriteEndElement();
                }

                // Vlogs
                xml.WriteStartElement("url");
                xml.WriteElementString("loc", host + "/vlogs");
                xml.WriteEndElement();

                foreach (LessonModel vlog in await _publicVlogManager.GetLessons())
                {
                    xml.WriteStartElement("url");
                    xml.WriteElementString("loc", host + "/vlog/" + vlog.Slug);
                    xml.WriteEndElement();
                }

                // Projects
                xml.WriteStartElement("url");
                xml.WriteElementString("loc", host + "/projects");
                xml.WriteEndElement();

                foreach (ProjectModel project in await _publicProjectManager.GetProjects())
                {
                    xml.WriteStartElement("url");
                    xml.WriteElementString("loc", host + "/project/" + project.Slug);
                    xml.WriteEndElement();
                }

                xml.WriteEndElement();
            }

            return output.ToString();
        }
    }
}
