using System;
using System.Runtime.InteropServices;

namespace ElectronicObserver.Utility
{
	using System.Runtime.CompilerServices;

	public enum TBPFLAG
	{
		TBPF_NOPROGRESS = 0x00000000,
		TBPF_INDETERMINATE = 0x00000001,
		TBPF_NORMAL = 0x00000002,
		TBPF_ERROR = 0x00000004,
		TBPF_PAUSED = 0x00000008,
	}

	public enum TBATFLAG
	{
		TBATF_USEMDITHUMBNAIL = 0x00000001,
		TBATF_USEMDILIVEPREVIEW = 0x00000002,
	}

	[ComImport, InterfaceType((short)1), Guid("EA1AFB91-9E28-4B86-90E9-9E9F8A5EEFAF")]
	public interface ITaskbarList3
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void HrInit();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void AddTab([In] IntPtr hwnd);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void DeleteTab([In] IntPtr hwnd);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void ActivateTab([In] IntPtr hwnd);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetActivateAlt([In] IntPtr hwnd);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void MarkFullscreenWindow([In] IntPtr hwnd, [In] int fFullscreen);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetProgressValue([In] IntPtr hwnd, [In] ulong ullCompleted, [In] ulong ullTotal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetProgressState([In] IntPtr hwnd, [In] TBPFLAG tbpFlags);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void RegisterTab([In] IntPtr hwndTab, [In, ComAliasName("TaskbarLib.wireHWND")]IntPtr hwndMDI);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void UnregisterTab([In] IntPtr hwndTab);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetTabOrder([In] IntPtr hwndTab, [In] IntPtr hwndInsertBefore);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetTabActive([In] IntPtr hwndTab, [In] IntPtr hwndMDI, [In] TBATFLAG tbatFlags);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void ThumbBarAddButtons([In] IntPtr hwnd, [In] uint cButtons, [In] /*ref tagTHUMBBUTTON*/IntPtr pButton);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void ThumbBarUpdateButtons([In] IntPtr hwnd, [In] uint cButtons, [In] /*ref tagTHUMBBUTTON*/IntPtr pButton);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void ThumbBarSetImageList([In] IntPtr hwnd, [In]IntPtr himl);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetOverlayIcon([In] IntPtr hwnd, [In] IntPtr hIcon, [In, MarshalAs(UnmanagedType.LPWStr)] string pszDescription);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetThumbnailTooltip([In] IntPtr hwnd, [In, MarshalAs(UnmanagedType.LPWStr)] string pszTip);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void SetThumbnailClip([In] IntPtr hwnd, [In] IntPtr/*ref tagRECT*/ prcClip);
	}

	[ComImport, CoClass(typeof(TaskbarListClass)), Guid("EA1AFB91-9E28-4B86-90E9-9E9F8A5EEFAF")]
	public interface TaskbarList : ITaskbarList3
	{
	}

	[ComImport, Guid("56FDF344-FD6D-11D0-958A-006097C9A090"), ClassInterface((short)0), TypeLibType((short)2)]
	public class TaskbarListClass : ITaskbarList3, TaskbarList
	{
		// Methods
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void ActivateTab([In] IntPtr hwnd);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void AddTab([In] IntPtr hwnd);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void DeleteTab([In] IntPtr hwnd);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void HrInit();
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void MarkFullscreenWindow([In] IntPtr hwnd, [In] int fFullscreen);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void RegisterTab([In] IntPtr hwndTab, [In]IntPtr hwndMDI);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void SetActivateAlt([In] IntPtr hwnd);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void SetOverlayIcon([In] IntPtr hwnd, [In] IntPtr hIcon, [In, MarshalAs(UnmanagedType.LPWStr)] string pszDescription);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void SetProgressState([In] IntPtr hwnd, [In] TBPFLAG tbpFlags);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void SetProgressValue([In] IntPtr hwnd, [In] ulong ullCompleted, [In] ulong ullTotal);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void SetTabActive([In] IntPtr hwndTab, [In] IntPtr hwndMDI, [In] TBATFLAG tbatFlags);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void SetTabOrder([In] IntPtr hwndTab, [In] IntPtr hwndInsertBefore);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void SetThumbnailClip([In] IntPtr hwnd, [In] /*ref tagRECT*/IntPtr prcClip);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void SetThumbnailTooltip([In] IntPtr hwnd, [In, MarshalAs(UnmanagedType.LPWStr)] string pszTip);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void ThumbBarAddButtons([In] IntPtr hwnd, [In] uint cButtons, [In] IntPtr/*ref tagTHUMBBUTTON*/ pButton);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void ThumbBarSetImageList([In] IntPtr hwnd, [In] IntPtr himl);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void ThumbBarUpdateButtons([In] IntPtr hwnd, [In] uint cButtons, [In] IntPtr/*ref tagTHUMBBUTTON*/ pButton);
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public virtual extern void UnregisterTab([In] IntPtr hwndTab);
	}
}
