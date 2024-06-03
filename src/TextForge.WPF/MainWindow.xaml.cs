using System.IO;
using System.Windows;

using Microsoft.Win32;

using TextForge.Core;

namespace TextForge.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    /// <summary>
    /// Initializes a new instance of the class <see cref="MainWindow"/>.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        MessageBox.Show($"{Properties.Settings.Default.SourceFilePath}; {Properties.Settings.Default.FinalFilePath}");
    }

    /// <summary>
    /// Saved final file path.
    /// </summary>
    /// <param name="sender">Object, trigger event.</param>
    /// <param name="e">Event arguments.</param>
    private void ChooseFinalFile_OnClick(object sender, RoutedEventArgs e)
    {
        var folderDialog = new OpenFolderDialog();

        if (folderDialog.ShowDialog() != true)
        {
            var logs = new Logs(nameof(Errors.TF0305), Errors.TF0305);
            logs.WriteErrorInLogs();
        }

        var selectedFilePath = folderDialog.FolderName;

        Properties.Settings.Default.FinalFilePath = selectedFilePath;
        Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Selected file(folder), where finds txt files.
    /// </summary>
    /// <param name="sender">Object, trigger event.</param>
    /// <param name="e">Event arguments.</param>
    private void ChooseSourceFile_OnClick(object sender, RoutedEventArgs e)
    {
        var folderDialog = new OpenFolderDialog();

        if (folderDialog.ShowDialog() != true)
        {
            var logs = new Logs(nameof(Errors.TF0305), Errors.TF0305);
            logs.WriteErrorInLogs();
        }

        var selectedFilePath = folderDialog.FolderName;

        Properties.Settings.Default.SourceFilePath = selectedFilePath;
        Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Selected file(folder), where finds txt files.
    /// </summary>
    /// <param name="sender">Object, trigger event.</param>
    /// <param name="e">Event arguments.</param>
    private void ChooseSourceFile_OnDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetData(DataFormats.FileDrop) is string[] { Length: 1 } folders && Directory.Exists(folders[0]))
        {
            Properties.Settings.Default.SourceFilePath = folders[0];
            Properties.Settings.Default.Save();
        }

        MessageBox.Show(Properties.Settings.Default.SourceFilePath);
    }
}