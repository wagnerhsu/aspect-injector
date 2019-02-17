#region

using System;
using System.Windows.Forms;
using AspectInjector.Broker;
using NLog;
using TestCommonLib01;

#endregion

namespace TestWinForm01
{
    [Aspect(typeof(TraceAspect))]
    public partial class FormMain : Form
    {
        private static ILogger Logger = LogManager.GetCurrentClassLogger();
        public FormMain()
        {
            InitializeComponent();
        }


        private void buttonTest_Click(object sender, EventArgs e)
        {
            new TestService().Display();
            new TestService().Display("Hi");
            TestHelper.Foo();
            //MessageBox.Show("Hi");
            Logger.Info(Utilities.Hello("Wagner"));
        }
    }
}