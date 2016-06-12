﻿//
// Copyright (c) Antmicro
//
// Full license details are defined in the 'LICENSE' file.
//
using System;
using System.Collections.Generic;
using System.Linq;

namespace Terminal
{
    internal sealed class RowCollection : IRowCollection
    {
        public RowCollection()
        {
            rows = new List<IRow>();
        }

        public void AppendRow(IRow row)
        {
            rows.Add(row);
            InvokeContentChanged();
        }

        public IEnumerable<IRow> GetAllRows()
        {
            for(var i = rows.Count - 1; i >= 0; i--)
            {
                yield return rows[i];
            }
        }

        public event Action ContentChanged;

        private void InvokeContentChanged()
        {
            var contentChanged = ContentChanged;
            if(contentChanged != null)
            {
                contentChanged();
            }
        }

        private readonly List<IRow> rows;
    }
}

