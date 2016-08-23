using UnityEngine;
using System.Collections;
using System.IO;

/*
 *   - add [kIndex_XXX] such as kIndex_row
 * v0.1 2016 Aug. 23 
 *   - add LoadCsvResouce()
 */

namespace NS_DataBaseManager
{
	public class DataBaseManager {
		string m_dataString;

		public const int kIndex_caseNo = 0;
		public const int kIndex_row = 1;
		public const int kIndex_column = 2;
		public const int kIndex_name = 3;
		public const int kIndex_about = 4;
		public const int kIndex_dataSheetURL = 5;

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
