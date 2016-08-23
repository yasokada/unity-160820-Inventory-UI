﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using NS_SampleData;
using NS_MyStringUtil;
using NS_DataBaseManager;

/*
 *   - move [kIndex_XXX] to DataBaseManager class
 * v0.3 2016 Aug. 23
 *   - move resource load feature to DataBaseManager class
 *   - update debugReadCsv() to use DataBaseManager class
 *   - add [DataBaseManager.csv]
 *   - add debugReadCsv() for test
 *   - add getUniqueIndex()
 * v0.2 2016 Aug. 21
 *   - add UpdateInfo()
 *   - add [MyStringUtil.cs]
 *   - add OpenURL()
 * v0.1 2016 Aug. 21
 *   - add MoveColumn()
 *   - add MoveRow()
 *   - add SampleData.cs
 *   - add UI components (unique ID, Case No, Row, Column, About, DataSheet)
 */

public class InventoryCS : MonoBehaviour {

	public InputField IF_uniqueID;
	public Text T_caseNo;
	public Text T_row;
	public Text T_column;
	public InputField IF_name;
	public Text T_about;
	public Text T_datasheetURL;

	void Start () {
		T_about.text = NS_SampleData.SampleData.GetDataOfRow (0);	
		debugReadCsv ();
	}
		
	void Update () {
	
	}

	private void UpdateInfo(string datstr) {
		T_caseNo.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_caseNo);
		T_row.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_row);
		T_column.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_column);
		IF_uniqueID.text = getUniqueIndex (T_caseNo.text, T_row.text, T_column.text);
		IF_name.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_name);
		T_about.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_about);
		T_datasheetURL.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_url);
	}

	private string getUniqueIndex(string caseNo, string rowNo, string columnNo) {
		int wrkCase = int.Parse (caseNo);
		int wrkRow = int.Parse (rowNo);
		int wrkCol = int.Parse (columnNo);

		string res = 
			string.Format ("{0:0000}", wrkCase)
			+ string.Format("{0:00}", wrkRow)
			+ string.Format("{0:00}", wrkCol);
		return res;
	}

	public void MoveRow(bool next) {
		if (next == false) { // previous
			string dtstr = NS_SampleData.SampleData.GetDataOfRow (0);	
			UpdateInfo (dtstr);
		} else {
			string dtstr = NS_SampleData.SampleData.GetDataOfRow (1);
			UpdateInfo (dtstr);
		}
	}

	public void MoveColumn(bool next) {
		if (next == false) { // previous
			string dtstr = NS_SampleData.SampleData.GetDataOfColumn(0);
			UpdateInfo (dtstr);
		} else {
			string dtstr = NS_SampleData.SampleData.GetDataOfColumn (1);
			UpdateInfo (dtstr);
			T_caseNo.text = MyStringUtil.ExtractCsvColumn (dtstr, DataBaseManager.kIndex_caseNo);
			T_about.text = dtstr;
		}
	}

	public void OpenURL() {
		Application.OpenURL (T_datasheetURL.text);
	}

	public void debugReadCsv() {
		DataBaseManager dbm = new DataBaseManager ();
		dbm.LoadCsvResouce ();
		T_about.text = dbm.GetString ("2SK4017");
		dbm = null;
	}
}