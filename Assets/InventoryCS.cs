using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NS_SampleData;

/*
 * v0.1 2016 Aug. 21
 *   - add MoveColumn()
 *   - add MoveRow()
 *   - add SampleData.cs
 *   - add UI components (unique ID, Case No, Row, Column, About, DataSheet)
 * /

public class InventoryCS : MonoBehaviour {

	public InputField ID_uniqueID;
	public Text T_caseNo;
	public Text T_row;
	public Text T_column;
	public InputField IF_name;
	public Text T_about;
	string datasheetURL;

	void Start () {
		T_about.text = NS_SampleData.SampleData.GetDataOfRow (0);	
	}
		
	void Update () {
	
	}

	public void MoveRow(bool next) {
		if (next == false) { // previous
			T_about.text = NS_SampleData.SampleData.GetDataOfRow (0);	
		} else {
			T_about.text = NS_SampleData.SampleData.GetDataOfRow (1);
		}
	}

	public void MoveColumn(bool next) {
		if (next == false) { // previous
			T_about.text = NS_SampleData.SampleData.GetDataOfColumn(0);
		} else {
			T_about.text = NS_SampleData.SampleData.GetDataOfColumn (1);
		}
	}

}
