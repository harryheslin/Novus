using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Novus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpenFile : ContentPage
    {

        /* PDF File has been hardcorded as an embedded resource for demonstration purposes. In a further release of 
           this application the file name currently displayed in the view above the pdf, would be used to retrieve 
           the appropriate files from a server */
        public OpenFile()
        {
            InitializeComponent();

            Func<CancellationToken, Task<Stream>> streamFunc = ct => Task.Run(() =>
            {
                Assembly assembly = typeof(Novus.App).Assembly;
                string fileName = assembly.GetManifestResourceNames().FirstOrDefault(n => n.Contains("pdf_mock.pdf"));
                Stream stream = assembly.GetManifestResourceStream(fileName);
                return stream;
            });
            this.pdfViewer.Source = streamFunc;

        }
    }
}