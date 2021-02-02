using System;

// ReSharper disable once CheckNamespace
namespace OpenJijDotNet.Graphs
{

    public sealed partial class Dense<TItem> : Graph
    {

        public abstract class Indexer<TItem>
        {

            #region Fields

            protected readonly Dense<TItem> _Parent;

            #endregion

            #region Constructors 

            internal Indexer(Dense<TItem> parent)
            {
                this._Parent = parent ?? throw new ArgumentNullException(nameof(parent));
            }

            #endregion

            #region Properties

            public abstract TItem this[uint i, uint j]
            {
                get;
                set;
            }

            #endregion

        }

        internal sealed class IndexerDouble : Indexer<double>
        {

            #region Constructors

            public IndexerDouble(Dense<double> parent)
                : base(parent)
            {
            }

            #endregion

            #region Properties

            public override double this[uint i, uint j]
            {
                get
                {
                    // var r = this._Parent.Rows;
                    // var c = this._Parent.Columns;
                    // var tr = this._Parent.TemplateRows;
                    // var tc = this._Parent.TemplateColumns;
                    // if (!(r == 1 || c == 1))
                    //     throw new NotSupportedException();

                    // if (!((r == 1 && 0 <= index && index < c) || (c == 1 && 0 <= index && index < r)))
                    //     throw new IndexOutOfRangeException();

                    // unsafe
                    // {
                    //     byte value;
                    //     var p = (IntPtr)(&value);
                    //     var ret = NativeMethods.matrix_operator_get_one_row_column(this._Type, this._Parent.NativePtr, index, tr, tc, p);
                    //     this.ThrowIfHasError(ret);

                    //     return value;
                    // }
                    return 0;
                }
                set
                {
                    // var r = this._Parent.Rows;
                    // var c = this._Parent.Columns;
                    // var tr = this._Parent.TemplateRows;
                    // var tc = this._Parent.TemplateColumns;
                    // if (!(r == 1 || c == 1))
                    //     throw new NotSupportedException();

                    // if (!((r == 1 && 0 <= index && index < c) || (c == 1 && 0 <= index && index < r)))
                    //     throw new IndexOutOfRangeException();

                    // unsafe
                    // {
                    //     var p = (IntPtr)(&value);
                    //     var ret = NativeMethods.matrix_operator_set_one_row_column(this._Type, this._Parent.NativePtr, index, tr, tc, p);
                    //     this.ThrowIfHasError(ret);
                    // }
                }
            }

            #endregion

        }

    }

}
