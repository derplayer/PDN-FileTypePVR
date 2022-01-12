﻿using PuyoTools.Core;
using PuyoTools.Core.Archives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuyoTools.App.Formats.Archives
{
    /// <inheritdoc/>
    internal partial class PvmFormat : IArchiveFormat
    {
        private PvmFormat() { }

        /// <summary>
        /// Gets the current instance.
        /// </summary>
        internal static PvmFormat Instance { get; } = new PvmFormat();

        public string Name => "PVM";

        public string FileExtension => ".pvm";

        public ArchiveBase GetCodec() => new PvmArchive();

        public bool Identify(Stream source, string filename) => PvmArchive.Identify(source);
    }
}
