using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using WideWorldImporters.DataAccess;
using WideWorldImporters.BusinessLogic;

namespace WideWorldImporters
{
    public partial class GetStockItems : System.Web.UI.Page
    {
        private DataSet ds = new DataSet();
        private ArrayList sis = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack) 
            //{
            TableRow trow;
            TableCell tcellStockItemName, 
                      tcellSupplierName, 
                      tcellPackageType, 
                      tcellUnitPrice, 
                      tcellStockItemCheck, 
                      bcellUpdate, 
                      bcellDelete;

            try
            {

                using (DataSet dsStockItems = DataAccess.DataAccess.GetStockItems())
                {
                    DataTable dtStockItems = new DataTable();
                    for (int t = 0; t < dsStockItems.Tables.Count; t++)
                    {
                        dtStockItems = dsStockItems.Tables[t];
                        lblStockItemsCount.Text = dtStockItems.Rows.Count.ToString();

                        ddlStockItemName.DataSource = dtStockItems;
                        ddlStockItemName.DataValueField = "StockItemName";
                        ddlStockItemName.DataTextField = "StockItemName";
                        ddlStockItemName.DataBind();

                        int i = 0;
                        foreach (DataRow dtRow in dtStockItems.Rows)
                        {
                            trow = new TableRow();
                            tcellStockItemName = new TableCell();
                            tcellStockItemName.Controls.Add(RenderTextBox("StockItemName" + i.ToString(), dtRow["StockItemName"].ToString()));
                            tcellSupplierName = new TableCell();
                            tcellSupplierName.Controls.Add(RenderTextBox("SupplierName" + i.ToString(), dtRow["SupplierName"].ToString()));
                            tcellPackageType = new TableCell();
                            tcellPackageType.Controls.Add(RenderTextBoxSmall("PackageTypeName" + i.ToString(), dtRow["PackageTypeName"].ToString()));
                            tcellUnitPrice = new TableCell();
                            tcellUnitPrice.Controls.Add(RenderTextBoxSmall("UnitPrice" + i.ToString(), dtRow["UnitPrice"].ToString()));
                            tcellStockItemCheck = new TableCell();
                            tcellStockItemCheck.Controls.Add(RenderCheckBox("StockItemCheck" + i.ToString(), ""));
                            trow.Cells.Add(tcellStockItemName);
                            trow.Cells.Add(tcellSupplierName);
                            trow.Cells.Add(tcellPackageType);
                            trow.Cells.Add(tcellUnitPrice);
                            trow.Cells.Add(tcellStockItemCheck);
                            tblStoskItem.Rows.Add(trow);
                            StockItem si = new StockItem(dtRow["StockItemName"].ToString(), dtRow["SupplierName"].ToString(), dtRow["PackageTypeName"].ToString(), dtRow["UnitPrice"].ToString());
                            sis.Add(si);
                            i++;
                        }
                    }
                    trow = new TableRow();
                    bcellUpdate = new TableCell();
                    bcellUpdate.Controls.Add(RenderButton("UpdateStockItems", "Update"));
                    bcellDelete = new TableCell();
                    bcellDelete.Controls.Add(RenderButton("DeleteStockItems", "Delete"));
                    trow.Cells.Add(bcellUpdate);
                    trow.Cells.Add(bcellDelete);
                    tblStoskItem.Rows.Add(trow);

                    ds.Tables.Add(dtStockItems.Copy());
                    ds.Tables[0].TableName = "StockItems";
                }

            }
            catch (SqlException ex)
            {
                Label1.Text = SqlExceptionHelper.GetErrorExplanation(ex);
            }
            catch (EmptyTableException ex)
            {
                lblStockItemsCount.Text = "0";
                Label1.Text = ex.Message() + ex.Text();
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }// Page_Load(object sender, EventArgs e)

        private void WriteRows()
        {
            TableRow trow;
            TableCell tcellStockItemName,
                      tcellSupplierName,
                      tcellPackageType,
                      tcellUnitPrice,
                      tcellStockItemCheck,
                      bcellUpdate,
                      bcellDelete;

            using (DataSet dsStockItems = DataAccess.DataAccess.GetStockItems())
            {
                DataTable dtStockItems = new DataTable();
                for (int t = 0; t < dsStockItems.Tables.Count; t++)
                {
                    dtStockItems = dsStockItems.Tables[t];
                    lblStockItemsCount.Text = dtStockItems.Rows.Count.ToString();

                    ddlStockItemName.DataSource = dtStockItems;
                    ddlStockItemName.DataValueField = "StockItemName";
                    ddlStockItemName.DataTextField = "StockItemName";
                    ddlStockItemName.DataBind();

                    int i = 0;
                    foreach (DataRow dtRow in dtStockItems.Rows)
                    {
                        trow = new TableRow();
                        tcellStockItemName = new TableCell();
                        tcellStockItemName.Controls.Add(RenderTextBox("StockItemName" + i.ToString(), dtRow["StockItemName"].ToString()));
                        tcellSupplierName = new TableCell();
                        tcellSupplierName.Controls.Add(RenderTextBox("SupplierName" + i.ToString(), dtRow["SupplierName"].ToString()));
                        tcellPackageType = new TableCell();
                        tcellPackageType.Controls.Add(RenderTextBoxSmall("PackageTypeName" + i.ToString(), dtRow["PackageTypeName"].ToString()));
                        tcellUnitPrice = new TableCell();
                        tcellUnitPrice.Controls.Add(RenderTextBoxSmall("UnitPrice" + i.ToString(), dtRow["UnitPrice"].ToString()));
                        tcellStockItemCheck = new TableCell();
                        tcellStockItemCheck.Controls.Add(RenderCheckBox("StockItemCheck" + i.ToString(), ""));
                        trow.Cells.Add(tcellStockItemName);
                        trow.Cells.Add(tcellSupplierName);
                        trow.Cells.Add(tcellPackageType);
                        trow.Cells.Add(tcellUnitPrice);
                        trow.Cells.Add(tcellStockItemCheck);
                        tblStoskItem.Rows.Add(trow);
                        i++;
                    }
                }
                trow = new TableRow();
                bcellUpdate = new TableCell();
                bcellUpdate.Controls.Add(RenderButton("UpdateStockItems", "Update"));
                bcellDelete = new TableCell();
                bcellDelete.Controls.Add(RenderButton("DeleteStockItems", "Delete"));
                trow.Cells.Add(bcellUpdate);
                trow.Cells.Add(bcellDelete);
                tblStoskItem.Rows.Add(trow);

                ds.Tables.Add(dtStockItems.Copy());
                ds.Tables[0].TableName = "StockItems";
            }

        }

        private TextBox RenderTextBox(string suffix, string text)
        {
            TextBox tb = new TextBox();
            tb.ID = "txt" + suffix;
            tb.Text = text;
            tb.Width = 350;
            tb.TextChanged += new EventHandler(textBox_TextChanged);
            return tb;
        }

        private TextBox RenderTextBoxSmall(string suffix, string text)
        {
            TextBox tb = new TextBox();
            tb.ID = "txt" + suffix;
            tb.Text = text;
            tb.Width = 50;
            //tb.TextChanged += new EventHandler(textBox_TextChanged);
            return tb;
        }

        private CheckBox RenderCheckBox(string suffix, string text)
        {
            CheckBox cb = new CheckBox();
            cb.ID = "chk" + suffix;
            cb.Text = text;
            cb.Width = 50;
            return cb;
        }

        private Button RenderButton(string suffix, string text)
        {
            Button bt = new Button();
            bt.ID = "btn" + suffix;
            bt.Height = 20;
            bt.Width = 70;
            bt.Text = text;

            if (text.Equals("Delete"))
                bt.Click += new EventHandler(btnDeleteParent_Click);
            else if (text.Equals("Update"))
                bt.Click += new EventHandler(btnUpdateParent_Click);

            return bt;
        }

        protected void textBox_TextChanged(object sender, EventArgs e)
        {
            int i = 0;

            string tbIndex = ((TextBox)sender).ID;
            string tbText = ((TextBox)sender).Text;
            string StockItemName,
                   SupplierName,
                   PackageTypeName,
                   UnitPrice;

            foreach (StockItem si in sis)
            {
                StockItemName = "txtStockItemName" + i.ToString();
                SupplierName = "txtSupplierName" + i.ToString();
                PackageTypeName = "txtPackageTypeName" + i.ToString();
                UnitPrice = "txtUnitPrice" + i.ToString();

                if (tbIndex.Equals(StockItemName)) si.StockItemName = tbText;
                else if (tbIndex.Equals(SupplierName)) si.SupplierName = tbText;
                else if (tbIndex.Equals(PackageTypeName)) si.UnitPackage = tbText;
                else if (tbIndex.Equals(UnitPrice)) si.UnitPrice = tbText;

                i++;
            }

            RedrawTable();

        }

        private void RedrawTable()
        {

            int countControls = tblStoskItem.Controls.Count;
            for (int i = countControls - 1; i >= 0; i--)
                tblStoskItem.Controls.RemoveAt(i);

            WriteRows();
        }

        protected void btnSelectChildrenByParent_Click(object sender, EventArgs e)
        {

        }


        protected void btnSelectParentsByChild_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeleteParent_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddParent_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateParent_Click(object sender, EventArgs e)
        {


        }

        protected void btnEditChild_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddChild_Click(object sender, EventArgs e)
        {

        }
    }
}