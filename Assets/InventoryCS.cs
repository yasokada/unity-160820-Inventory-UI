using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using NS_SampleData;
using NS_MyStringUtil;
using NS_DataBaseManager;

/*
 * v0.7 2016 Aug. 27
 *   - MyStringUtil: v0.4
 *   - display [T_amount] from database
 *   - display [T_checkDate] from database
 *   - add [L_checkDate],[T_checkDate]
 *   - add [L_amount],[T_amount]
 *   - update [Inventory.csv]
 * v0.6 2016 Aug. 26
 *   - can move prev/next for column
 *   - can move prev/next for row
 *   - DataBaseManager: v0.7
 *   - remove debugReadCsv()
 * v0.5 2016 Aug. 25
 *   - add null check in SearchWithUniqueIndex()
 *   - add SearchWithUniqueIndex()
 *   - DataBaseManager: v0.6
 *   - rename [T_caseNo] to [T_shelfNo]
 *   - enlarge height and width of [T_datasheetURL]
 *   - DataBaseManager: v0.4
 * v0.4 2016 Aug. 24
 *   - impl B_search button
 *   - add SerachWithItemName()
 *   - DataBaseManager: v0.2
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
	public Text T_shelfNo;
	public Text T_row;
	public Text T_column;
	public InputField IF_name;
	public Text T_about;
	public Text T_datasheetURL;
	public Text T_amount;
	public Text T_checkDate;

	DataBaseManager m_dbm;

	void Start () {
		T_about.text = NS_SampleData.SampleData.GetDataOfRow (0);	

		m_dbm = new DataBaseManager ();
		m_dbm.LoadCsvResource ();
	}
		
	void Update () {
	
	}

	private void UpdateInfo(string datstr) {
		T_shelfNo.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_shelfNo);
		T_row.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_row);
		T_column.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_column);
		IF_uniqueID.text = getUniqueIndex (T_shelfNo.text, T_row.text, T_column.text);
		IF_name.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_name);
		T_about.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_about);
		T_datasheetURL.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_url);
		T_amount.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_amount);
		T_checkDate.text = MyStringUtil.ExtractCsvColumn (datstr, DataBaseManager.kIndex_checkDate);
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
		string dtstr = m_dbm.GetUniqueIndexString_moveRow (
			               T_shelfNo.text,
			               T_row.text,
			               T_column.text,
			/* nextRow=*/next);

		if (dtstr != null) {
			UpdateInfo (dtstr);
		}
	}

	public void MoveColumn(bool next) {
		string dtstr = m_dbm.GetUniqueIndexString_moveColumn (
			T_shelfNo.text,
			T_row.text,
			T_column.text,
			/* nextColumn=*/next);

		if (dtstr != null) {
			UpdateInfo (dtstr);
		}
	}

	public void SerachWithItemName() {
		string itmnm = IF_name.text;
		string dtstr = m_dbm.GetStringOfName (itmnm);
		if (dtstr != null) {
			UpdateInfo (dtstr);
		}
	}

	public void SearchWithUniqueIndex() {
		string unqidx = IF_uniqueID.text;
		string dtstr = m_dbm.GetStringOfUniqueIndex (unqidx);
		if (dtstr != null) {
			UpdateInfo (dtstr);
		}
	}

	public void OpenURL() {
		Application.OpenURL (T_datasheetURL.text);
	}
}