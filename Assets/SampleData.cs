using UnityEngine;
using System.Collections;

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
			switch (row) {
			case 0:
				return "1,1,1,MAX232,The MAX220-MAX249 family of line drivers/receivers is ...";
			case 1:
				return "1,1,2,MAX44242,The MAX44242 provides a combination of high voltage, low noise, low input ...";
			}
			return "";
		}

		public static string GetDataOfColumn(int clm) {
			switch (clm) {
			case 0:
				return "1,2,1,HC-SR04,Power supply: 5V DC. Ultrasonic Frequency: 40k Hz\n• Resolution: 1 cm ...";
			case 1:
				return "1,2,2,MPL115A2,an absolute pressure sensor with a digital I2C output targeting low cost applications...";
			}
			return "";
		}

	}
}