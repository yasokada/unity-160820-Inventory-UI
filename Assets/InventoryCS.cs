using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NS_SampleData;
using NS_MyStringUtil;

/*
 *   - add [MyStringUtil.cs]
 *   - add OpenURL()
 * v0.1 2016 Aug. 21
 *   - add MoveColumn()
 *   - add MoveRow()
 *   - add SampleData.cs
 *   - add UI components (unique ID, Case No, Row, Column, About, DataSheet)
 */

public class InventoryCS : MonoBehaviour {

	public InputField ID_uniqueID;
	public Text T_caseNo;
	public Text T_row;
	public Text T_column;
	public InputField IF_name;
	public Text T_about;
	public Text T_datasheetURL;

	const int kIndex_dataSheetURL = 5; // TODO: put other place to declare

	void Start () {
		T_about.text = NS_SampleData.SampleData.GetDataOfRow (0);	
	}
		
	void Update () {
	
	}

	public void MoveRow(bool next) {
		if (next == false) { // previous
			string dtstr = NS_SampleData.SampleData.GetDataOfRow (0);	
			T_about.text = dtstr;
			T_datasheetURL.text = MyStringUtil.ExtractCsvColumn (dtstr, kIndex_dataSheetURL);
			T_about.text = T_datasheetURL.text; // test
		} else {
			string dtstr = NS_SampleData.SampleData.GetDataOfRow (1);
			T_about.text = dtstr;
			T_datasheetURL.text = MyStringUtil.ExtractCsvColumn (dtstr, kIndex_dataSheetURL);
			T_about.text = T_datasheetURL.text; // test
		}
	}

	public void MoveColumn(bool next) {
		if (next == false) { // previous
			string dtstr = NS_SampleData.SampleData.GetDataOfColumn(0);
			T_about.text = dtstr;
			T_datasheetURL.text = MyStringUtil.ExtractCsvColumn (dtstr, kIndex_dataSheetURL);
			T_about.text = T_datasheetURL.text; // test
		} else {
			string dtstr = NS_SampleData.SampleData.GetDataOfColumn (1);
			T_about.text = dtstr;
			T_datasheetURL.text = MyStringUtil.ExtractCsvColumn (dtstr, kIndex_dataSheetURL);
			T_about.text = T_datasheetURL.text; // test
		}
	}

	public void OpenURL() {
		Application.OpenURL (T_datasheetURL.text);
	}
}