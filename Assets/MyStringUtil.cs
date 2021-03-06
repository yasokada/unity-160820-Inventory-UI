﻿using UnityEngine;
using System.Linq;
using System; // for StringSplitOptions.RemoveEmptyEntries
using System.Collections.Generic;
using System.Text.RegularExpressions; // for Regex

/*
 * v0.4 2016 Aug. 27
 *   - handle csv with cells having comma inside the item
 *     + update ExtractCsvColumn() to use SplitCSV()
 *     + add SplitCSV()
 * v0.3 2016 Aug. 21
 *   - add ExtractCsvColumn()
 * v0.2 2015/11/21
 *   - add replaceNonAsciiToAscii()
 */

namespace NS_MyStringUtil
{
	public static class MyStringUtil {
		public static string removeLine(string src, int numRemove)
		{
			string work = src;
			for(int loop=0; loop < numRemove; loop++) {
				int pos = work.IndexOf('\n');
				work = work.Substring(pos+1);
			}
			return work;
		}
		public static string addToRingBuffer(string src, string addStr, int maxline) 
		{
			string work = src + addStr;
			int numline = work.Count( c => c == '\n') + 1;
			int numRemove = numline - maxline;
			work = removeLine(work, numRemove);     
			return work;
		}

		public static string replaceNonAsciiToAscii(string srcstr)
		{
			string work = srcstr;
			bool hasNewLine = false;

			if (srcstr.IndexOf ("\r") >= 0) {
				hasNewLine = true;
			}
			if (srcstr.IndexOf ("\n") >= 0) {
				hasNewLine = true;
			}

			work = work.Replace ("\r", "<CR>");
			work = work.Replace ("\n", "<LF>");

			if (hasNewLine) {
				work = work + System.Environment.NewLine;
			}
			return work;
		}

		public static string[] SplitCSV(string input)
		{
			Regex csvSplit = new Regex ("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
			List<string> list = new List<string> ();
			string curr = null;
			foreach (Match match in csvSplit.Matches(input)) {        
				curr = match.Value;
				if (0 == curr.Length) {
					list.Add ("");
				}

				list.Add (curr.TrimStart (','));
			}

			return list.ToArray<string> ();
		}

		public static string ExtractCsvColumn(string src, int idx) {
			string [] elements = SplitCSV(src);
			if (elements.Length <= idx) {
				return "";
			}
			return elements [idx];
		}
	}
}