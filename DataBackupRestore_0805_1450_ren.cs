// 代码生成时间: 2025-08-05 14:50:57
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp
{
    public class DataBackupRestore
    {
        private readonly string backupFolder;
        private readonly string dataFolder;

        // 构造函数，设置备份和数据文件夹路径
        public DataBackupRestore(string backupFolderPath, string dataFolderPath)
        {
            backupFolder = backupFolderPath;
            dataFolder = dataFolderPath;
        }

        // 备份数据
        public async Task<bool> BackupDataAsync(string fileName)
        {
            try
            {
                // 确保备份文件夹存在
                Directory.CreateDirectory(backupFolder);

                // 读取要备份的数据文件
                string sourcePath = Path.Combine(dataFolder, fileName);
                if (!File.Exists(sourcePath))
                {
                    Console.WriteLine($"数据文件: {fileName} 不存在。");
                    return false;
                }

                // 复制文件到备份文件夹
                string backupPath = Path.Combine(backupFolder, fileName);
                await File.CopyAsync(sourcePath, backupPath);
                Console.WriteLine($"备份文件: {fileName} 到 {backupPath} 成功。");
                return true;
            }
            catch (Exception ex)
            {
                // 异常处理
                Console.WriteLine($"备份数据时发生错误: {ex.Message}");
                return false;
            }
        }

        // 恢复数据
        public async Task<bool> RestoreDataAsync(string fileName)
        {
            try
            {
                // 确保备份文件夹存在
                Directory.CreateDirectory(backupFolder);

                // 读取要恢复的备份文件
                string backupPath = Path.Combine(backupFolder, fileName);
                if (!File.Exists(backupPath))
                {
                    Console.WriteLine($"备份文件: {fileName} 不存在。");
                    return false;
                }

                // 复制文件到数据文件夹
                string targetPath = Path.Combine(dataFolder, fileName);
                await File.CopyAsync(backupPath, targetPath);
                Console.WriteLine($"从 {backupPath} 恢复文件: {fileName} 到 {targetPath} 成功。");
                return true;
            }
            catch (Exception ex)
            {
                // 异常处理
                Console.WriteLine($"恢复数据时发生错误: {ex.Message}");
                return false;
            }
        }
    }
}
