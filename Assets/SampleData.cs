using UnityEngine;
using System.Collections;

/*
 * v0.2 2016 Aug. 21
 *   - update GetDataOfRow()
 *      + add datasheet URL
 * v0.1 2016 Aug. 21
 *   - add GetDataOfColumn()
 *   - add GetDataOfRow()
 */

namespace NS_SampleData
{
	public static class SampleData
	{
		// 1: caseNo
		// 2: row
		// 3: column
		// 4: name (key)
		// 5: about
		// 6: datasheet URL (TODO)

		public static string GetDataOfRow(int row) {
			string res; 
			switch (row) {
			case 0:
				res = "1,1,1,MAX232,The MAX220-MAX249 family of line drivers/receivers is ...";
				res = res + ",http://www.yahoo.co.jp";
				return res;
			case 1:
				res = "1,1,2,MAX44242,The MAX44242 provides a combination of high voltage, low noise, low input ...";
				res = res + ",http://www.google.co.jp";
				return res;
			}
			return "";
		}

		public static string GetDataOfColumn(int clm) {
			string res;
			switch (clm) {
			case 0:
				res = "1,2,1,HC-SR04,Power supply: 5V DC. Ultrasonic Frequency: 40k Hz\n• Resolution: 1 cm ...";
				res = res + ",http://unity3d.com";
				return res;
			case 1:
				res = "1,2,2,MPL115A2,an absolute pressure sensor with a digital I2C output targeting low cost applications...";
				res = res + ",http://github.com";
				return res;
			}
			return "";
		}

	}
}