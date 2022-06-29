using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAPI.Models
{
    public class DummyContentRepo
    {
        //dummy data repo
        private static List<Content> contentList = new List<Content>()
        {
            new Content() {ID = 1, contentType = "Prefab", screenSpace = "Full", name = "MyPrefab", shape = "Cube", metaTransform = new MetaTransform()},
            new Content() {ID = 2, contentType = "InstantiateAtRuntime", screenSpace = "Quarter", name = "Runtime", shape = "Capsule", metaTransform = new MetaTransform()},
            new Content() {ID = 3, contentType = "InHierarchy", screenSpace = "Variable", name = "Editor", shape = "Sphere", metaTransform = new MetaTransform()}
        };

        public List<Content> GetAll()
        {
            return contentList;
        }

        public Content GetByID(int contentID)
        {
            return contentList.FirstOrDefault(c => c.ID == contentID);
        }

        public List<Content> GetByContentType(string _contentType)
        {
            return (from content in contentList
                    where _contentType == content.contentType
                    select content).ToList();
        }

        public List<Content> GetByScreenSpace(string _space)
        {
            return (from content in contentList
                    where _space == content.screenSpace
                    select content).ToList();
        }

        public List<Content> GetByName(string _name)
        {
            return (from content in contentList
                    where _name == content.name
                    select content).ToList();
        }

        public List<Content> GetByShape(string _shape)
        {
            return (from content in contentList
                    where _shape == content.shape
                    select content).ToList();
        }

        public void CreateContent(Content _newContent)
        {
            _newContent.ID = contentList.Max(c => c.ID) + 1;
            contentList.Add(_newContent);
        }

        public void UpdateContent(Content _updatedContent)
        {
            var found = contentList.FirstOrDefault(c => c.ID == _updatedContent.ID);
            if (found != null)
                found = _updatedContent;
        }

        public void DeleteContent(int _contentID)
        {
            contentList.RemoveAll(c => c.ID == _contentID);
        }

    }
}