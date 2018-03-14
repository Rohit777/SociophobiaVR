using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XmlUtil {
	public static void Save(string path) {
		StreamWriter writer = new StreamWriter("NPC_ACTION_LIST.txt");
		writer.WriteLine(path);
		writer.Close();
	}
}