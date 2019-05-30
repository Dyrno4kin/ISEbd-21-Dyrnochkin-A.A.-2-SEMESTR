using FishShopServiceDAL.Interfaces;
using FishShopServiceImplement.Implementations;
using System;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace FishShopWPFView
{
    // <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            App app = new App();
            var container = BuildUnityContainer();
            app.Run(container.Resolve<MainWindow>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ICustomerService, CustomerServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICanFoodService, CanFoodServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientService, IngredientServiceList>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceList>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
