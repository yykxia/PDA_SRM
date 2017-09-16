using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PDA_SRM
{
    public partial class SerialsPrint : Form
    {
        public SerialsPrint()
        {
            InitializeComponent();
        }
        //窗体内按键事件
        private void SerialsPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Return") 
            {
                
            }
        }
        //下载合同信息
        private void menuItem2_Click(object sender, EventArgs e)
        {
            try 
            {
                string opt = "getRemainSendList";//调用方法
                //获取最新合同信息
                string dataStr = Program.HttpPost(Program.srmAPIUrl, opt, Program.supplierNo);
                if (dataStr != null) 
                {
                    JObject remainSend = new JObject(dataStr);
                    JArray items = new JArray(remainSend);
                    string[] details = new string[items.Count];
                    for (int i = 0; i < items.Count; i++) 
                    {

                    }
                }
            }
            catch 
            {
            }
        }
    }
}