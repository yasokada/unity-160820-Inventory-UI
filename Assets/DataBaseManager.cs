using UnityEngine;
//using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using NS_MyStringUtil;

/*
 *   - rename [kIndex_caseNo] to [kIndex_shelfNo]
 * v0.4 2016 Aug. 25
 *   - fix typo > [Resouce] to [Resource]
 * v0.3 2016 Aug. 24
 *   - GetString() takes [itemName] arg
 * v0.2 2016 Aug. 24
 *   - update getString() to use getElementWithLikeSearch()
 *   - add getElementWithLikeSearch()
 *   - add dictionary [m_dic]
 *   - add [kIndex_checkDate]
 *   - add [kIndex_XXX] such as kIndex_row
 * v0.1 2016 Aug. 23 
 *   - add LoadCsvResouce()
 */

namespace NS_DataBaseManager
{
	public class DataBaseManager {
		Dictionary <string, string> m_dic;

		public const int kIndex_shelfNo = 0;
		public const int kIndex_row = 1;
		public const int kIndex_column = 2;
		public const int kIndex_name = 3;
		public const int kIndex_about = 4;
		public const int kIndex_url = 5;
		public const int kIndex_checkDate = 6;

		public void LoadCsvResource() {
			if (m_dic == null) {
				m_dic = new Dictionary<string, string>();
			}

			TextAsset csv = Resources.Load ("inventory") as TextAsset;
			StringReader reader = new StringReader (csv.text);
			string line = "";
			string itmnm;
			while (reader.Peek () != -1) {
				line = reader.ReadLine ();
				itmnm = MyStringUtil.ExtractCsvColumn (line, kIndex_name);
				m_dic.Add (itmnm, line);
			}
		}
			
		public string GetString(string itemName) {
			string res = getElementWithLikeSearch (m_dic, itemName);
			return res;
		}

		private static string getElementWithLikeSearch(Dictionary<string, string> myDic, string searchKey) {
			//Dictionaryの規定値は｢null, null｣なので､空文字を返したい場合はnull判定を入れる
			return myDic.Where(n => n.Key.Contains(searchKey)).FirstOrDefault().Value;
		}
	}
}
