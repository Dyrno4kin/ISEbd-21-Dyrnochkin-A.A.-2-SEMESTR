using FishShopServiceDAL.Interfaces;
using FishShopServiceImplementDataBase;
using FishShopServiceImplementDataBase.Implementations;
using System;
using System.Windows.Forms;

namespace FishShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            APIClient.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

        }
    }
}
