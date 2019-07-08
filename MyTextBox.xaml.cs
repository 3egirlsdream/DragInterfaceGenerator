﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DragInterfaceGenerator
{
    /// <summary>
    /// MyTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class MyTextBox : UserControl
    {
        public MyTextBox()
        {
            InitializeComponent();
            btn.MouseLeftButtonDown += Btn_MouseLeftButtonDown;
            btn.MouseMove += Btn_MouseMove;
            btn.MouseLeftButtonUp += Btn_MouseLeftButtonUp;
        }
        Point pos = new Point();
        private void Btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid tmp = (Grid)sender;
            pos = e.GetPosition(null);
            tmp.CaptureMouse();
            tmp.Cursor = Cursors.Hand;
        }
        //字段英文名
        public string NAME_ENG { get; set; }
        //弹出框类型
        public string BOX_TYPE { get; set; }
        private void Btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Grid tmp = (Grid)sender;
                double dx = e.GetPosition(null).X - pos.X + tmp.Margin.Left;
                double dy = e.GetPosition(null).Y - pos.Y + tmp.Margin.Top;
                tmp.Margin = new Thickness(dx, dy, 0, 0);
                pos = e.GetPosition(null);
            }
        }

        private void Btn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid tmp = (Grid)sender;
            int xx = (int)(btn.Margin.Left / 20);
            int yy = (int)(btn.Margin.Top / 20);
            //MessageBox.Show(xx + " " + yy);
            tmp.Margin = new Thickness(xx * 20, yy * 20, 0, 0);
            tmp.ReleaseMouseCapture();
        }
    }
}
