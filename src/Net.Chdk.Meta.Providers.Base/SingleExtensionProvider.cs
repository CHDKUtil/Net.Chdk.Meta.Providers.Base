using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Net.Chdk.Meta.Providers
{
    public abstract class SingleExtensionProvider<TInnerProvider>
        where TInnerProvider : IExtensionProvider
    {
        private IEnumerable<TInnerProvider> InnerProviders { get; }

        protected SingleExtensionProvider(IEnumerable<TInnerProvider> innerProviders)
        {
            InnerProviders = innerProviders;
        }

        protected TInnerProvider GetInnerProvider(string path, out string ext)
        {
            var x = ext = Path.GetExtension(path);
            return InnerProviders.SingleOrDefault(p => x.Equals(p.Extension, StringComparison.OrdinalIgnoreCase));
        }
    }
}
