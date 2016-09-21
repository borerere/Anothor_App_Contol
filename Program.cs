/*
 * 下記HPのコードを参考にしています。
 * http://dobon.net/vb/dotnet/process/getprocessesbywindowtitle.html
 * 
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int LpdwProcessId);

        static void Main(string[] args)
        {
            // タイトルが"無題 - メモ帳"のウィンドウを探す
            IntPtr hWnd = FindWindow(null, "無題 - メモ帳");
            if (hWnd != IntPtr.Zero)
            {
                // ウィンドウを作成したプロセスのIDを取得する
                int processId;
                GetWindowThreadProcessId(hWnd, out processId);
                // Processオブジェクトを作成する
                Process p = Process.GetProcessById(processId);

                Console.WriteLine("プロセス名：" + p.ProcessName);
                Console.WriteLine("プロセスID：" + processId);

            }
            else
            {
                Console.WriteLine("見つかりませんでした。");
            }
            Console.ReadLine();

        }
    }
}
