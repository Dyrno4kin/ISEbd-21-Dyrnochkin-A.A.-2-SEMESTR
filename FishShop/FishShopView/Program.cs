﻿using FishShopServiceDAL.Interfaces;
using FishShopServiceImplement.Implementations;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

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
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICustomerService, CustomerServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientService, IngredientServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICanFoodService, CanFoodServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
