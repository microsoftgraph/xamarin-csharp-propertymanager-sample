/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace XamarinNativePropertyManager.Models
{
    public class TableModel<T> where T : TableRowModel, new()
    {
        private TableColumnModel[] _columns;

        public TableColumnModel[] Columns
        {
            get { return _columns; }
            set
            {
                _columns = value; 
                UpdateRows();
            }
        }

        public T[] Rows { get; private set; }

        private void UpdateRows()
        {
            var rows = new List<T>();
            for (var i = 1; i < Columns[0].Values.Count; i++)
            {
                var row = new T();

                // Set data.
                var cells = Columns.Select(column => column.Values[i][0]).ToArray();
                for (var j = 0; j < cells.Length; j++)
                {
                    row[j] = cells[j];
                }
                rows.Add(row);
            }
            Rows = rows.ToArray();
        }

        public TableColumnModel this[string name]
        {
            get { return Columns.First(c => c.Name.Equals(name)); }
        }

        public void AddRow(TableRowModel row)
        {
            for (var i = 0; i < row.Count; i++)
            {
                Columns[i].Values.Add(new List<JToken> { row[i] });
            }
            UpdateRows();
        }
    }
}
