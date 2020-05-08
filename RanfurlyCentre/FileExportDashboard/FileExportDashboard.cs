
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public partial class FileExportDashBoard : Form
    {
        //protected Jarvis _jarvis;
        protected FileExportBase _fileExportBase;
        protected List<FieldNameMapper> _fieldListMapper;
        public FileExportDashBoard(FileExportBase fileExportBase)
            //public FileExportDashBoard(Jarvis jarvis)
        {
            InitializeComponent();
            _fileExportBase = fileExportBase;
            txtOutputFileName.Text = _fileExportBase.Jarvis.OutputFileName;
            txtFileLocation.Text = _fileExportBase.Jarvis.OutputFileLocation;
            PopulateFieldList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                progressBar1.Value = 0;
                lblProgress.Visible = true;
                progressBar1.Visible = true;

                if (txtFileLocation.Text == string.Empty)
                {
                    ep.SetError(txtFileLocation, "Type File Location");
                    return;
                }

                if (txtOutputFileName.Text == string.Empty)
                {
                    ep.SetError(txtOutputFileName, "Type File Name");
                    return;
                }

                string fileFullPath = txtFileLocation.Text + txtOutputFileName.Text + "_"+ _fileExportBase.Jarvis.FileIncrement;
                DMFileManager.DataFile df;
                if (rbCSV.Checked)
                {
                    fileFullPath = fileFullPath + ".CSV";
                   df = new DMFileManager.SaveCSVFile(fileFullPath);
                }
                else if (rbTextFile.Checked)
                {
                    fileFullPath = fileFullPath + ".TXT";
                    df = new DMFileManager.SaveTXTFile(fileFullPath);
                }
                else
                {
                    fileFullPath = fileFullPath + ".XLSX";
                    df = new DMFileManager.SaveXLSXFile(fileFullPath);
                    if(df.FileNameWithoutExtension.Length>30)
                    {
                        fileFullPath = df.FolderName +"\\"+  df.FileNameWithoutExtension.Substring(0, 30)+df.FileExtension;
                        df = new DMFileManager.SaveXLSXFile(fileFullPath);
                    }

                }

                df.ExportDataList = _fileExportBase.Jarvis.ExportFileData;//_fileExportBase.Jarvis.ExportFileData;               
                df.ReportProgress += Df_ReportProgress;
                //progressBar1.Value = 0;
                //lblProgress.Visible = true;
                //progressBar1.Visible = true;

                df.SaveData(_fieldListMapper, _fileExportBase.Jarvis.ExportOjectType);
                _fileExportBase.Jarvis.IncreaseFielIncrement();
                MessageBox.Show("'"+ fileFullPath + "' file created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblProgress.Visible = false;
            progressBar1.Visible = false;
        }

        private void PopulateFieldList()
        {
            DMFileManager.DataFile df = new DMFileManager.DataFile(_fileExportBase.Jarvis.ExportFielFieldList);
            df.ImportData();
            //List<string> fieldList = CommonFunctions.PropertiesFromType(Jarvis.ExportOjectType);
            _fieldListMapper = CommonFunctions.TableToFieldMapping(df.DataSource, _fileExportBase.Jarvis.ExportOjectType);
            BindingSource bs = new BindingSource();
            dgFieldList.AutoGenerateColumns = false;
            bs.DataSource = _fieldListMapper;
            dgFieldList.DataSource = bs;
           
            dgFieldList.Refresh();
        }

        private void chkExportFields_CheckedChanged(object sender, EventArgs e)
        {
            foreach (FieldNameMapper fm in _fieldListMapper)
            {
                fm.Selected = chkExportFields.Checked;
            }
            dgFieldList.Refresh();
            RenumberColumns();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCell cell = dgFieldList.CurrentCell;
                if (cell.RowIndex != 0)
                {
                    FieldNameMapper cold = _fieldListMapper[cell.RowIndex];
                    _fieldListMapper.Remove(cold);
                    _fieldListMapper.Insert(cell.RowIndex - 1, cold);
                    dgFieldList.CurrentCell = dgFieldList[1, cell.RowIndex - 1];
                }
                RenumberColumns();
            }
            catch { }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCell cell = dgFieldList.CurrentCell;
                if (cell.RowIndex != _fieldListMapper.Count - 1)
                {
                    FieldNameMapper cold = _fieldListMapper[cell.RowIndex];
                    _fieldListMapper.Remove(cold);
                    _fieldListMapper.Insert(cell.RowIndex + 1, cold);
                    dgFieldList.CurrentCell = dgFieldList[1, cell.RowIndex + 1];
                }

                RenumberColumns();
            }
            catch { }
        }

        private void RenumberColumns()
            {
            int i = 1;
            foreach (FieldNameMapper col in _fieldListMapper)
            {
                if (col.Selected)
                {
                    col.ColumnPosition = i;
                    i += 1;
                }
                else
                {
                    col.ColumnPosition = null;
                }
            }
            dgFieldList.Refresh();
        }

        private void Df_ReportProgress(object sender, DMFileManager.DMEventMessenger e)
        {
            progressBar1.Value = (int)(e.ProgressPercent * 100);
            lblProgress.Text = ((int)(e.ProgressPercent * 100)).ToString() + "%";
            progressBar1.Refresh();
            lblProgress.Refresh();
            //lblFileName.Text = e.FileName;
            // lblFileName.Refresh();
            //throw new NotImplementedException();
        }

        //private void dgFieldList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    //RenumberColumns();
        //}

        private void FileExportDashBoard_Shown(object sender, EventArgs e)
        {
           // dgFieldList.CellValueChanged += dgFieldList_CellValueChanged;
        }

        //private void dgFieldList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    //RenumberColumns();
        //}

        private void dgFieldList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if(e.ColumnIndex==0)
            //    RenumberColumns();
        }

        private void dgFieldList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                FieldNameMapper mapper = _fieldListMapper[e.RowIndex];
                mapper.Selected = !mapper.Selected;
                RenumberColumns();
            }
                
        }
    }
}
