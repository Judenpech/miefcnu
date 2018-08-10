using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace CatchnUpload
{
    public partial class frm_main : Form
    {
        private string savePathDir;

        public frm_main()
        {
            InitializeComponent();
        }

        private void btn_catch_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            string[] files = ConfigurationManager.AppSettings["files"].Split(';');
            foreach (string f in files)
            {
                bool flag = CopyFiles(f, ConfigurationManager.AppSettings["sourcePath"], savePathDir);
                if (flag)
                {
                    cnt++;
                }
            }
            MessageBox.Show("文件抓取成功 " + cnt + " 个！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool CopyFiles(string fileName, string sourcePath, string savePath)
        {
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
                foreach (FileInfo f in directoryInfo.GetFiles())
                {
                    string ff = f.ToString().ToLower();
                    if (ff == fileName)
                    {
                        File.Copy(sourcePath + "\\" + f.ToString(),
                    savePath + "\\" + ConfigurationManager.AppSettings["userID"] + "_"
                    + DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + fileName, true);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["flag"] == "0")
            {
                //连接共享文件夹
                string hostPath = ConfigurationManager.AppSettings["host"] + "\\" + ConfigurationManager.AppSettings["userID"] + "\\";

                bool status = connectState(ConfigurationManager.AppSettings["host"],
                    ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
                if (status)
                {
                    //MessageBox.Show("服务器连接成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bool hasUploded = uploadFiles(hostPath);
                    if (hasUploded)
                    {
                        MessageBox.Show("文件上传成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("文件上传失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("服务器连接失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                //连接FTP服务器
                string hostPath = ConfigurationManager.AppSettings["ftpHost"] + @"/";
                bool hasUploded = uploadFiles2ftp(hostPath);
                if (hasUploded)
                {
                    MessageBox.Show("文件上传成功！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("文件上传失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool connectState(string path, string userName, string passWord)
        {
            bool Flag = false;
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                string dosLine = "net use " + path + " " + passWord + " /user:" + userName;
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return Flag;
        }

        private bool uploadFiles(string hostPath)
        {
            if (!Directory.Exists(hostPath))
            {
                Directory.CreateDirectory(hostPath);
            }
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(savePathDir);
                foreach (FileInfo f in directoryInfo.GetFiles())
                {
                    string filePath = savePathDir + "\\" + f.ToString();
                    FileStream inFileStream = new FileStream(filePath, FileMode.Open);
                    FileStream outFileStream = new FileStream(hostPath + f.ToString(), FileMode.OpenOrCreate);

                    byte[] buf = new byte[inFileStream.Length];
                    int byteCount;
                    while ((byteCount = inFileStream.Read(buf, 0, buf.Length)) > 0)
                    {
                        outFileStream.Write(buf, 0, byteCount);
                    }
                    inFileStream.Flush();
                    inFileStream.Close();
                    outFileStream.Flush();
                    outFileStream.Close();

                    //上传成功则删除文件
                    File.Delete(filePath);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private bool uploadFiles2ftp(string hostPath)//，string filename)
        {
            FtpWebRequest reqFTP;
            DirectoryInfo directoryInfo = new DirectoryInfo(savePathDir);
            foreach (FileInfo f in directoryInfo.GetFiles())
            {
                string filePath = savePathDir + @"/" + f.ToString();
                FileInfo ff = new FileInfo(filePath);
                try
                {
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(hostPath + f.Name));
                    reqFTP.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["ftpUsername"],
                        ConfigurationManager.AppSettings["ftpPassword"]);
                    reqFTP.KeepAlive = false;
                    reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.UsePassive = false;
                    reqFTP.ContentLength = ff.Length;
                    int buffLength = 2048;
                    byte[] buff = new byte[buffLength];
                    int contentLen;

                    FileStream fs = ff.OpenRead();
                    Stream strm = reqFTP.GetRequestStream();
                    contentLen = fs.Read(buff, 0, buffLength);
                    while (contentLen != 0)
                    {
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                    }
                    strm.Close();
                    fs.Close();
                    reqFTP = null;

                    //上传成功则删除文件
                    File.Delete(filePath);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            savePathDir = System.IO.Directory.GetCurrentDirectory() + "\\save\\" + DateTime.Now.ToString("yyyyMMdd");

            txb_id.Text = ConfigurationManager.AppSettings["userID"];
            txb_path.Text = ConfigurationManager.AppSettings["sourcePath"];
            rtxb_files.Text = ConfigurationManager.AppSettings["files"];
        }
    }
}
