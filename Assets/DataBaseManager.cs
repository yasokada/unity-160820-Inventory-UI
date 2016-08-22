using UnityEngine;
using System.Collections;
using System.IO;

namespace NS_DataBaseManager
{
	public class DataBaseManager {
		string m_dataString;

		public void LoadCsvResouce() {
			TextAsset csv = Resources.Load ("inventory") as TextAsset;
			StringReader reader = new StringReader (csv.text);
			string line = "";
			while (reader.Peek () != -1) {
				line = line + reader.ReadLine ();
				// TODO: add CRLF
			}
			m_dataString = line;
		}

		public string getString() {
			return m_dataString;
		}
	}
}
