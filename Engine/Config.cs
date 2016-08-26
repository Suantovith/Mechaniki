using System.IO;
using System.Xml.Serialization;

namespace Engine
{
    public class Config
    {
        XmlSerializer serializer;
        StreamWriter writer;
        StreamReader reader;
        string file;
        public Config(Variables variables)
        {
            serializer = new XmlSerializer(typeof(Variables));
            file = variables.configFile;    
        }
        public Variables LoadConfig(Variables variables)
        {
            if (File.Exists(file))
            {
                reader = new StreamReader(file);
                Variables newVariables = (Variables)serializer.Deserialize(reader);
                reader.Close();
                return newVariables;
            }
            else
            {
                SaveConfig(variables);
                return variables;
            }     
        }
        public void SaveConfig(Variables variables)
        {
            writer = new StreamWriter(file);
            serializer.Serialize(writer, variables);
            writer.Close();
        }
    }
}
