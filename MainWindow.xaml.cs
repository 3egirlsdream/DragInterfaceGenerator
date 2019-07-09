using System;
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
using Xu.Common;

namespace DragInterfaceGenerator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    
    public partial class MainWindow : Window
    {
        Point pos;
        public MainWindow()
        {
            InitializeComponent();
            //btn.MouseLeftButtonDown += Btn_MouseLeftButtonDown;
            //btn.MouseMove += Btn_MouseMove;
            //btn.MouseLeftButtonUp += Btn_MouseLeftButtonUp;
            pos = new Point();
            
        }


        #region
        //private void Btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    Border tmp = (Border)sender;
        //    pos = e.GetPosition(null);
        //    tmp.CaptureMouse();
        //    tmp.Cursor = Cursors.Hand;
        //}

        //private void Btn_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if(e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        Border tmp = (Border)sender;
        //        double dx = e.GetPosition(null).X - pos.X + tmp.Margin.Left;
        //        double dy = e.GetPosition(null).Y - pos.Y + tmp.Margin.Top;
        //        tmp.Margin = new Thickness(dx, dy, 0, 0);
        //        pos = e.GetPosition(null);
        //    }
        //}

        //private void Btn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    Border tmp = (Border)sender;
        //    tmp.ReleaseMouseCapture();
        //}

        //private void Btn_Drop(object sender, DragEventArgs e)
        //{

        //}

        //private void Btn_MouseDown(object sender, MouseButtonEventArgs e)
        //{

        //}
        #endregion


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyBorder myBorder = new MyBorder();
            myBorder.Name = GetControlsName("BTN");
            myBorder.MouseDoubleClick += Button_MouseDown;
            grid.Children.Add(myBorder);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyTextBox textBox = new MyTextBox();
            textBox.Name = GetControlsName("TB");
            textBox.MouseDoubleClick += TextBox_MouseDown;
            grid.Children.Add(textBox);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MyDataGrid datagrid = new MyDataGrid();
            datagrid.Name = GetControlsName("GRID");
            datagrid.MouseDoubleClick += DataGrid_MouseDown;
            grid.Children.Add(datagrid);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Canvas canvas = new Canvas();
            //canvas.Width = 1150;
            //canvas.Height = 750;
            //canvas.Name = "canvas1";
            //father.Children.Add(canvas);

            MySidebar mySidebar = new MySidebar();
            mySidebar.Name = GetControlsName("BAR");
            grid.Children.Add(mySidebar);
        }

        //生成控件名称
        private string GetControlsName(string prex)
        {
            return prex + DateTime.Now.ToString("MMddHHmmss");
        }

        #region 打开控件配置界面
        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var obj = sender as FrameworkElement;
            ButtonSetting buttonSetting = new ButtonSetting(obj);
            buttonSetting.ParentWindow = this;
            cc.Content = new Frame { Content = buttonSetting };
            ccp.Visibility = Visibility;
            cc.Visibility = Visibility.Visible;
            //MessageBox.Show(obj.Name);
        }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var obj = sender as FrameworkElement;
            TextBoxSetting textBoxSetting = new TextBoxSetting(obj);
            textBoxSetting.ParentWindow = this;
            cc.Content = new Frame { Content = textBoxSetting };
            ccp.Visibility = Visibility;
            cc.Visibility = Visibility.Visible;
            //MessageBox.Show(obj.Name);
        }

        private void DataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var obj = sender as FrameworkElement;
            DataGridSetting dataGridSetting = new DataGridSetting(obj);
            dataGridSetting.ParentWindow = this;
            cc.Content = new Frame { Content = dataGridSetting };
            ccp.Visibility = Visibility;
            cc.Visibility = Visibility.Visible;
            //MessageBox.Show(obj.Name);
        }
        #endregion

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create(object sender, RoutedEventArgs e)
        {
            List<MySidebar> sider = new List<MySidebar>();
            foreach(dynamic ds in grid.Children)
            {
                string name = ds.Name as string;
                if (name.Contains("BAR"))
                {
                    sider.Add(ds);
                }
            }
        }
    }
}
