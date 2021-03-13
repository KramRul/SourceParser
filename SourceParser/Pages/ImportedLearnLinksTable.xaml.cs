using SourceParser.BusinessLogicLevel.Services;
using SourceParser.BusinessLogicLevel.Services.Interfaces;
using SourceParser.DataAccessLevel.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SourceParser.Pages
{
    public sealed partial class ImportedLearnLinksTable : Page
    {
        private readonly IImportLinkDataService _importLinkDataService = new ImportLinkDataService(new UnitOfWork());
        public ImportedLearnLinksTable()
        {
            this.InitializeComponent();
        }
    }
}
