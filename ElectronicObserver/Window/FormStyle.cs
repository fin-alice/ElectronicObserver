using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ElectronicObserver.Window {
	static class FormStyle {
		static readonly Type[] CONTROL_TYPES = {
			typeof( Button ),
			typeof( CheckBox ),
			typeof( RadioButton ),
			typeof( Label ),
			typeof( ComboBox ),
			typeof( GroupBox ),
			typeof( TabPage ),
			typeof( DataGridView )
		};
		static readonly Type[] COLUMN_TYPES = {
			typeof( DataGridViewCheckBoxColumn ),
			typeof( DataGridViewComboBoxColumn ),
			typeof( DataGridViewButtonColumn )
		};

		public static void DoChangeStyles( this Form _form ) {
			var _type = _form.GetType();
			var _fields = _type.GetFields( BindingFlags.NonPublic | BindingFlags.Instance );
			var FilteredFields = _fields.Where( _f => CONTROL_TYPES.Contains( _f.FieldType ) );
			foreach( var _f in FilteredFields ) {
				object _c = _f.GetValue( _form );
				if( _c is ButtonBase ) {
					( _c as ButtonBase ).FlatStyle = FlatStyle.System;
				}
				else if( _c is Label ) {
					( _c as Label ).FlatStyle = FlatStyle.System;
				}
				else if( _c is ComboBox ) {
					( _c as ComboBox ).FlatStyle = FlatStyle.System;
				}
				else if( _c is GroupBox ) {
					( _c as GroupBox ).FlatStyle = FlatStyle.System;
				}
				else if( _c is TabPage ) {
					( _c as TabPage ).UseVisualStyleBackColor = false;
					( _c as TabPage ).BackColor = SystemColors.Control;
				}
				else if ( _c is DataGridView ) {
					var _cols = ( _c as DataGridView ).Columns.OfType< DataGridViewColumn >();
					var FilteredColumns = _cols.Where( _col => COLUMN_TYPES.Contains( _col.GetType() ) );
					foreach( var _col in FilteredColumns ) {
						if( _col is DataGridViewCheckBoxColumn ) {
							( _col as DataGridViewCheckBoxColumn ).FlatStyle = FlatStyle.System;
						}
						else if( _col is DataGridViewComboBoxColumn ) {
							( _col as DataGridViewComboBoxColumn ).FlatStyle = FlatStyle.System;
						}
						else if( _col is DataGridViewButtonColumn ) {
							( _col as DataGridViewButtonColumn ).FlatStyle = FlatStyle.System;
						}
					}
				}
			}
		}
	}

	public class FormBase : Form {
		protected override void OnCreateControl() {
			base.OnCreateControl();
			this.DoChangeStyles();
		}
	}

	public class DockContentBase : WeifenLuo.WinFormsUI.Docking.DockContent {
		protected override void OnCreateControl() {
			base.OnCreateControl();
			this.DoChangeStyles();
		}
	}
}
