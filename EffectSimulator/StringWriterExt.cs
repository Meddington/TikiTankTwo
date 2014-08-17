﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectSimulator
{
	public class StringWriterExt : StringWriter
	{
		public delegate void FlushedEventHandler(object sender, EventArgs args);
		public event FlushedEventHandler Flushed;
		public virtual bool AutoFlush { get; set; }

		public StringWriterExt()
			: base() { }

		public StringWriterExt(bool autoFlush)
			: base() { this.AutoFlush = autoFlush; }

		protected void OnFlush()
		{
			var eh = Flushed;
			if (eh != null)
				eh(this, EventArgs.Empty);
		}

		public override void Flush()
		{
			base.Flush();
			OnFlush();
		}

		public override void Write(char value)
		{
			base.Write(value);
			if (AutoFlush) Flush();
		}

		public override void Write(string value)
		{
			base.Write(value);
			if (AutoFlush) Flush();
		}

		public override void Write(char[] buffer, int index, int count)
		{
			base.Write(buffer, index, count);
			if (AutoFlush) Flush();
		}

		public override void WriteLine()
		{
			base.WriteLine();
			if (AutoFlush) Flush();
		}

		public override void WriteLine(string str)
		{
			base.WriteLine(str);
			if (AutoFlush) Flush();
		}
	}
}
