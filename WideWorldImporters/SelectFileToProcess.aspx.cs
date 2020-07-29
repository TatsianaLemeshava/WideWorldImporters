using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using WideWorldImporters.BusinessLogic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using WideWorldImporters.ErrorHandling;

namespace WideWorldImporters
{
    public partial class SelectFileToProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            if (fileread.HasFile)
            {
                try
                {
                    if (fileread.PostedFile.ContentType == "text/plain")
                    {
                        if (fileread.PostedFile.ContentLength < 512000)
                        {
                            string filename = Path.GetFileName(fileread.FileName);
                        }
                    }


                    //process file
                    Stream fileStream = fileread.PostedFile.InputStream;
                    using (StreamReader fsr = new StreamReader(fileStream))
                    {
                        ArrayList stockItems = new ArrayList();
                        string line;
                        while ((line = fsr.ReadLine()) != null)
                        {
                            string[] tmpArray = line.Split(Convert.ToChar(","));
                            StockItem stockItem = new StockItem(tmpArray[0], tmpArray[1], tmpArray[2], tmpArray[3]);
                            stockItems.Add(stockItem);
                        }
                        lblStockItemsCount.Text = stockItems.Count.ToString();
                        IFormatter formatterSerialize = new BinaryFormatter();
                        Stream streamSerialize = new FileStream(Server.MapPath("stockItems.xml"), FileMode.Create, FileAccess.Write, FileShare.None);
                        formatterSerialize.Serialize(streamSerialize, stockItems);
                        streamSerialize.Close();

                        TableRow trow;
                        TableCell tcellStockItemName,
                                  tcellSupplierName,
                                  tcellPackageType,
                                  tcellUnitPrice;

                        foreach (StockItem item in stockItems)
                        {
                            trow = new TableRow();
                            tcellStockItemName = new TableCell();
                            tcellStockItemName.Controls.Add(RenderTextBox("StockItemName" + item.StockItemName.ToString(), item.StockItemName));
                            tcellSupplierName = new TableCell();
                            tcellSupplierName.Controls.Add(RenderTextBox("SupplierName" + item.SupplierName.ToString(), item.SupplierName));
                            tcellPackageType = new TableCell();
                            tcellPackageType.Controls.Add(RenderTextBoxSmall("PackageTypeName" + item.UnitPackage.ToString(), item.UnitPackage));
                            tcellUnitPrice = new TableCell();
                            tcellUnitPrice.Controls.Add(RenderTextBoxSmall("UnitPrice" + item.UnitPrice.ToString(), item.UnitPrice));
                            trow.Cells.Add(tcellStockItemName);
                            trow.Cells.Add(tcellSupplierName);
                            trow.Cells.Add(tcellPackageType);
                            trow.Cells.Add(tcellUnitPrice);
                            tblStoskItem.Rows.Add(trow);

                        }
                        //Session.Clear();
                        //Response.Redirect("EditDataBeforSave.aspx");

                    }
                }
                catch (FileNotFoundException ex)
                {
                    Label1.Text = ExceptionHelper.GetFileNotFoundExplanation(ex);
                }
                catch (SerializationException ex)
                {
                    Label1.Text = ExceptionHelper.GetSerializationExplanation(ex);
                }
                catch (IOException ex)
                {
                    Label1.Text = ExceptionHelper.GetFileReadExplanation(ex);
                }
                catch (Exception ex)
                {
                    // something else went wrong
                }
            }
        }

        private TextBox RenderTextBox(string suffix, string text)
        {
            TextBox tb = new TextBox();
            tb.ID = "txt" + suffix;
            tb.Text = text;
            tb.Width = 350;
            //tb.TextChanged += new EventHandler(textBox_TextChanged);
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


    }//
}