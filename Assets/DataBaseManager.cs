﻿using UnityEngine;
//using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using NS_MyStringUtil;

/*
 * v0.6 2016 Aug. 25
 *   - update GetUniqueIndexString() to use int.TryParse() instead of int.Parse()
 *   - add GetStringOfUniqueIndex()
 *   - rename GetString() to GetStringOfName()
 *   - add [m_dic_uniqueIndexKey]
 *     - update LoadCsvResource()
 *   - add GetUniqueIndexString(string)
 *   - rename [m_dic] to [m_dic_nameKey]
 *   - add GetUniqueIndexString(int, int, int)
 * v0.5 2016 Aug. 25
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
		Dictionary <string, string> m_dic_nameKey; // SearchKey is item name
		Dictionary <string, string> m_dic_uniqueIndexKey; // SearchKey is UniqueIndex

		public const int kIndex_shelfNo = 0;
		public const int kIndex_row = 1;
		public const int kIndex_column = 2;
		public const int kIndex_name = 3;
		public const int kIndex_about = 4;
		public const int kIndex_url = 5;
		public const int kIndex_checkDate = 6;

		public void LoadCsvResource() {
			if (m_dic_nameKey == null) {
				m_dic_nameKey = new Dictionary<string, string>();
			}
			if (m_dic_uniqueIndexKey == null) {
				m_dic_uniqueIndexKey = new Dictionary<string, string> ();
			}

			TextAsset csv = Resources.Load ("inventory") as TextAsset;
			StringReader reader = new StringReader (csv.text);
			string line = "";
			string itmnm;
			string unqidx;

			while (reader.Peek () != -1) {
				line = reader.ReadLine ();
				//1.
				itmnm = MyStringUtil.ExtractCsvColumn (line, kIndex_name);
				m_dic_nameKey.Add (itmnm, line);
				// 2.
				unqidx = GetUniqueIndexString(line);
				m_dic_uniqueIndexKey.Add (unqidx, line);
			}
		}

		public string GetUniqueIndexString(string dtstr) {
			string shlf = MyStringUtil.ExtractCsvColumn (dtstr, kIndex_shelfNo);
			string rw = MyStringUtil.ExtractCsvColumn (dtstr, kIndex_row);
			string clmn = MyStringUtil.ExtractCsvColumn (dtstr, kIndex_column);

			int shelf, row, column;
			int.TryParse (shlf, out shelf);
			int.TryParse (rw, out row);
			int.TryParse (clmn, out column);

			return GetUniqueIndexString (shelf, row, column);
		}

		public string GetUniqueIndexString(int shelfNo, int row, int column) {
			string res;
			res = string.Format ("{0:0000}", shelfNo);
			res = res + string.Format ("{0:00}", row);
			res = res + string.Format ("{0:00}", column);
			return res;
		}
			
		public string GetStringOfName(string itemName) {
			string res = getElementWithLikeSearch (m_dic_nameKey, itemName);
			return res;
		}

		public string GetStringOfUniqueIndex(string uniqueIdx) {
			string res = getElementWithLikeSearch (m_dic_uniqueIndexKey, uniqueIdx);
			return res;
		}

		private static string getElementWithLikeSearch(Dictionary<string, string> myDic, string searchKey) {
			//Dictionaryの規定値は｢null, null｣なので､空文字を返したい場合はnull判定を入れる
			return myDic.Where(n => n.Key.Contains(searchKey)).FirstOrDefault().Value;
		}
	}
}
