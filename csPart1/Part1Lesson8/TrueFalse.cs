using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AndreyTedeev.Part1Lesson8
{
    [Serializable]
    public class Question
    {
        public string Text { get; set; }
        public bool Answer { get; set; }
        public Question()
        {
        }
        public Question(string text, bool answer)
        {
            Text = text;
            Answer = answer;
        }
    }

    class TrueFalse
    {
        List<Question> list;
        public string FileName { get; set; }
        
        public TrueFalse(string fileName)
        {
            FileName = fileName;
            list = new List<Question>();
        }
        
        public void Add(string text, bool answer)
        {
            list.Add(new Question(text, answer));
        }
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }
        public Question this[int index]
        {
            get { return list[index]; }
        }
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        public int Count
        {
            get { return list.Count; }
        }
    }
}

