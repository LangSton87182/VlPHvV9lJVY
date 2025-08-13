// 代码生成时间: 2025-08-14 04:35:38
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// 进程管理器应用程序
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ProcessManagerApp : ContentPage
{
    private List<Process> _processList;
    private ListView _processListView;
    private Label _statusLabel;
    private Button _refreshButton;

    // 构造函数
    public ProcessManagerApp()
    {
        InitializeComponent();
        InitializeControls();
    }

    // 初始化控件
    private void InitializeControls()
    {
        // 初始化进程列表
        _processList = new List<Process>();

        // 设置ListView控件
        _processListView = new ListView()
        {
            ItemsSource = _processList,
            ItemTemplate = new DataTemplate(typeof(ProcessItemCell))
        };

        // 设置状态标签
        _statusLabel = new Label
        {
            Text = "Ready"
        };

        // 设置刷新按钮
        _refreshButton = new Button
        {
            Text = "Refresh Processes"
        };
        _refreshButton.Clicked += RefreshProcessList;

        // 将控件添加到页面布局
        Content = new StackLayout
        {
            Children =
            {
                _refreshButton,
                _statusLabel,
                _processListView
            }
        };
    }

    // 刷新进程列表
    private void RefreshProcessList(object sender, EventArgs e)
    {
        try
        {
            _statusLabel.Text = "Refreshing...";
            _processList.Clear();

            // 获取系统中所有进程
            foreach (Process process in Process.GetProcesses())
            {
                _processList.Add(process);
            }

            _statusLabel.Text = "Refreshed";
        }
        catch (Exception ex)
        {
            _statusLabel.Text = $"Error: {ex.Message}";
        }
    }
}

// 进程项单元格
[XamlCompilation(XamlCompilationOptions.Compile)]
public class ProcessItemCell : ViewCell
{
    // 进程名称Label
    private Label _processNameLabel;

    // 构造函数
    public ProcessItemCell()
    {
        // 设置进程名称Label
        _processNameLabel = new Label
        {
            TextColor = Color.Black,
            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
        };

        // 设置单元格内容
        View = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Children =
            {
                _processNameLabel
            }
        };
    }

    // 设置进程名称
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        Process process = BindingContext as Process;
        if (process != null)
        {
            _processNameLabel.Text = process.ProcessName;
        }
    }
}
