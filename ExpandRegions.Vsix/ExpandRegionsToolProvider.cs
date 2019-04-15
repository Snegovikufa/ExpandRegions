using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Outlining;
using Microsoft.VisualStudio.Utilities;

namespace ExpandRegionsNext.Vsix
{
    /// <summary>
    /// Region expand provider.
    /// </summary>
    [Export(typeof(IWpfTextViewCreationListener))]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    [ContentType("CSharp")]
    [ContentType("Basic")]
    [UserVisible(true)]
    internal class ExpandRegionsToolProvider : IWpfTextViewCreationListener
    {
        [Import(typeof(IOutliningManagerService))]
        public IOutliningManagerService OutliningManagerService
        {
            get;
            set;
        }

        #region IWpfTextViewCreationListener

        public void TextViewCreated(IWpfTextView host)
        {
            if (host == null || OutliningManagerService == null)
            {
                return;
            }

            RegionTextViewHandler.CreateHandler(host, OutliningManagerService);
        }

        #endregion
    }
}
