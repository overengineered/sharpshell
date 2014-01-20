using System;
using SharpShell.Interop;

namespace SharpShell.SharpNamespaceExtension
{
    internal class ShellFolderProxy : IShellFolder2
    {
        public ShellFolderProxy(IShellNamespaceFolder folder)
        {
            this.folder = folder;
        }

        private readonly IShellNamespaceFolder folder;
        #region Implmentation of IShellFolder

        /// <summary>
        /// Translates the display name of a file object or a folder into an item identifier list.
        /// </summary>
        /// <param name="hwnd">A window handle. The client should provide a window handle if it displays a dialog or message box. Otherwise set hwnd to NULL.</param>
        /// <param name="pbc">Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing function.</param>
        /// <param name="pszDisplayName">A null-terminated Unicode string with the display name.</param>
        /// <param name="pchEaten">A pointer to a ULONG value that receives the number of characters of the display name that was parsed. If your application does not need this information, set pchEaten to NULL, and no value will be returned.</param>
        /// <param name="ppidl">When this method returns, contains a pointer to the PIDL for the object.</param>
        /// <param name="pdwAttributes">The value used to query for file attributes. If not used, it should be set to NULL.</param>
        /// <returns>
        /// If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        int IShellFolder.ParseDisplayName(IntPtr hwnd, IntPtr pbc, string pszDisplayName, ref uint pchEaten, out IntPtr ppidl, ref SFGAO pdwAttributes)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.ParseDisplayName(folder, hwnd, pbc, pszDisplayName, ref pchEaten, out ppidl,
                ref pdwAttributes);
        }

        /// <summary>
        /// Allows a client to determine the contents of a folder by creating an item identifier enumeration object and returning its IEnumIDList interface.
        /// Return value: error code, if any
        /// </summary>
        /// <param name="hwnd">If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the parent window to take user input.</param>
        /// <param name="grfFlags">Flags indicating which items to include in the  enumeration. For a list of possible values, see the SHCONTF enum.</param>
        /// <param name="ppenumIDList">Address that receives a pointer to the IEnumIDList interface of the enumeration object created by this method.</param>
        /// <returns>
        /// If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        int IShellFolder.EnumObjects(IntPtr hwnd, SHCONTF grfFlags, out IEnumIDList ppenumIDList)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.EnumObjects(folder, hwnd, grfFlags, out ppenumIDList);
        }

        /// <summary>
        /// Retrieves an IShellFolder object for a subfolder.
        //  Return value: error code, if any
        /// </summary>
        /// <param name="pidl">Address of an ITEMIDLIST structure (PIDL) that identifies the subfolder.</param>
        /// <param name="pbc">Optional address of an IBindCtx interface on a bind context object to be used during this operation.</param>
        /// <param name="riid">Identifier of the interface to return. </param>
        /// <param name="ppv">Address that receives the interface pointer.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        int IShellFolder.BindToObject(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.BindToObject(folder, pidl, pbc, ref riid, out ppv);
        }

        /// <summary>
        /// Requests a pointer to an object's storage interface.
        /// Return value: error code, if any
        /// </summary>
        /// <param name="pidl">Address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder.</param>
        /// <param name="pbc">Optional address of an IBindCtx interface on a bind context object to be  used during this operation.</param>
        /// <param name="riid">Interface identifier (IID) of the requested storage interface.</param>
        /// <param name="ppv">Address that receives the interface pointer specified by riid.</param>
        /// <returns>
        /// If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
        /// </returns>
        int IShellFolder.BindToStorage(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.BindToStorage(folder, pidl, pbc, ref riid, out ppv);
        }

        /// <summary>
        /// Determines the relative order of two file objects or folders, given
        /// their item identifier lists. Return value: If this method is
        /// successful, the CODE field of the HRESULT contains one of the
        /// following values (the code can be retrived using the helper function
        /// GetHResultCode): Negative A negative return value indicates that the first item should precede the second (pidl1 &lt; pidl2).
        /// Positive A positive return value indicates that the first item should
        /// follow the second (pidl1 &gt; pidl2).  Zero A return value of zero
        /// indicates that the two items are the same (pidl1 = pidl2).
        /// </summary>
        /// <param name="lParam">Value that specifies how the comparison  should be performed. The lower Sixteen bits of lParam define the sorting  rule.
        /// The upper sixteen bits of lParam are used for flags that modify the sorting rule. values can be from  the SHCIDS enum</param>
        /// <param name="pidl1">Pointer to the first item's ITEMIDLIST structure.</param>
        /// <param name="pidl2">Pointer to the second item's ITEMIDLIST structure.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        int IShellFolder.CompareIDs(IntPtr lParam, IntPtr pidl1, IntPtr pidl2)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.CompareIDs(folder, lParam, pidl1, pidl2);
        }

        /// <summary>
        /// Requests an object that can be used to obtain information from or interact
        /// with a folder object.
        /// Return value: error code, if any
        /// </summary>
        /// <param name="hwndOwner">Handle to the owner window.</param>
        /// <param name="riid">Identifier of the requested interface.</param>
        /// <param name="ppv">Address of a pointer to the requested interface.</param>
        /// <returns>
        /// If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        int IShellFolder.CreateViewObject(IntPtr hwndOwner, ref Guid riid, out IntPtr ppv)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.CreateViewObject(folder, this, hwndOwner, ref riid, out ppv);
        }

        /// <summary>
        /// Retrieves the attributes of one or more file objects or subfolders.
        /// Return value: error code, if any
        /// </summary>
        /// <param name="cidl">Number of file objects from which to retrieve attributes.</param>
        /// <param name="apidl">Address of an array of pointers to ITEMIDLIST structures, each of which  uniquely identifies a file object relative to the parent folder.</param>
        /// <param name="rgfInOut">Address of a single ULONG value that, on entry contains the attributes that the caller is
        /// requesting. On exit, this value contains the requested attributes that are common to all of the specified objects. this value can be from the SFGAO enum</param>
        /// <returns>
        /// If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        int IShellFolder.GetAttributesOf(uint cidl, IntPtr[] apidl, ref SFGAO rgfInOut)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.GetAttributesOf(folder, cidl, apidl, ref rgfInOut);
        }

        /// <summary>
        /// Retrieves an OLE interface that can be used to carry out actions on the
        /// specified file objects or folders. Return value: error code, if any
        /// </summary>
        /// <param name="hwndOwner">Handle to the owner window that the client should specify if it displays a dialog box or message box.</param>
        /// <param name="cidl">Number of file objects or subfolders specified in the apidl parameter.</param>
        /// <param name="apidl">Address of an array of pointers to ITEMIDLIST  structures, each of which  uniquely identifies a file object or subfolder relative to the parent folder.</param>
        /// <param name="riid">Identifier of the COM interface object to return.</param>
        /// <param name="rgfReserved">Reserved.</param>
        /// <param name="ppv">Pointer to the requested interface.</param>
        /// <returns>
        /// If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
        /// </returns>
        int IShellFolder.GetUIObjectOf(IntPtr hwndOwner, uint cidl, IntPtr[] apidl, ref Guid riid, uint rgfReserved, out IntPtr ppv)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.GetUIObjectOf(folder, hwndOwner, cidl, apidl, ref riid, rgfReserved, out ppv);
        }

        /// <summary>
        /// Retrieves the display name for the specified file object or subfolder.
        /// Return value: error code, if any
        /// </summary>
        /// <param name="pidl">Address of an ITEMIDLIST structure (PIDL)  that uniquely identifies the file  object or subfolder relative to the parent  folder.</param>
        /// <param name="uFlags">Flags used to request the type of display name to return. For a list of possible values.</param>
        /// <param name="pName">Address of a STRRET structure in which to return the display name.</param>
        /// <returns>
        /// If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
        /// </returns>
        int IShellFolder.GetDisplayNameOf(IntPtr pidl, SHGDNF uFlags, out STRRET pName)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.GetDisplayNameOf(folder, pidl, uFlags, out pName);
        }

        /// <summary>
        /// Sets the display name of a file object or subfolder, changing the item
        /// identifier in the process.
        /// Return value: error code, if any
        /// </summary>
        /// <param name="hwnd">Handle to the owner window of any dialog or message boxes that the client displays.</param>
        /// <param name="pidl">Pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder.</param>
        /// <param name="pszName">Pointer to a null-terminated string that specifies the new display name.</param>
        /// <param name="uFlags">Flags indicating the type of name specified by  the lpszName parameter. For a list of possible values, see the description of the SHGNO enum.</param>
        /// <param name="ppidlOut"></param>
        /// <returns>
        /// If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        int IShellFolder.SetNameOf(IntPtr hwnd, IntPtr pidl, string pszName, SHGDNF uFlags, out IntPtr ppidlOut)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.SetNameOf(folder, hwnd, pidl, pszName, uFlags, out ppidlOut);
        }

        #endregion

        #region IShellFolder2 Implementation

        int IShellFolder2.ParseDisplayName(IntPtr hwnd, IntPtr pbc, string pszDisplayName, ref uint pchEaten,
            out IntPtr ppidl, ref SFGAO pdwAttributes)
        {
            return ((IShellFolder)this).ParseDisplayName(hwnd, pbc, pszDisplayName, pchEaten, out ppidl,
                ref pdwAttributes);
        }

        int IShellFolder2.EnumObjects(IntPtr hwnd, SHCONTF grfFlags, out IEnumIDList ppenumIDList)
        {
            return ((IShellFolder)this).EnumObjects(hwnd, grfFlags, out ppenumIDList);

        }

        int IShellFolder2.BindToObject(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv)
        {
            return ((IShellFolder)this).BindToObject(pidl, pbc, ref riid, out ppv);
        }

        int IShellFolder2.BindToStorage(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv)
        {
            return ((IShellFolder)this).BindToStorage(pidl, pbc, ref riid, out ppv);
        }

        int IShellFolder2.CompareIDs(IntPtr lParam, IntPtr pidl1, IntPtr pidl2)
        {
            return ((IShellFolder)this).CompareIDs(lParam, pidl1, pidl2);
        }

        int IShellFolder2.CreateViewObject(IntPtr hwndOwner, ref Guid riid, out IntPtr ppv)
        {
            return ((IShellFolder)this).CreateViewObject(hwndOwner, ref riid, out ppv);
        }

        int IShellFolder2.GetAttributesOf(uint cidl, IntPtr[] apidl, ref SFGAO rgfInOut)
        {
            return ((IShellFolder)this).GetAttributesOf(cidl, apidl, ref rgfInOut);
        }

        int IShellFolder2.GetUIObjectOf(IntPtr hwndOwner, uint cidl, IntPtr[] apidl, ref Guid riid, uint rgfReserved,
            out IntPtr ppv)
        {
            return ((IShellFolder)this).GetUIObjectOf(hwndOwner, cidl, apidl, ref riid, rgfReserved, out ppv);
        }

        int IShellFolder2.GetDisplayNameOf(IntPtr pidl, SHGDNF uFlags, out STRRET pName)
        {
            return ((IShellFolder)this).GetDisplayNameOf(pidl, uFlags, out pName);
        }

        int IShellFolder2.SetNameOf(IntPtr hwnd, IntPtr pidl, string pszName, SHGDNF uFlags, out IntPtr ppidlOut)
        {
            return ((IShellFolder)this).SetNameOf(hwnd, pidl, pszName, uFlags, out ppidlOut);
        }

        int IShellFolder2.GetDefaultSearchGUID(out Guid pguid)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.GetDefaultSearchGUID(folder, out pguid);
        }

        int IShellFolder2.EnumSearches(out IEnumExtraSearch ppenum)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.EnumSearches(folder, out ppenum);
        }

        int IShellFolder2.GetDefaultColumn(uint dwRes, out uint pSort, out uint pDisplay)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.GetDefaultColumn(folder, dwRes, out pSort, out pDisplay);
        }

        int IShellFolder2.GetDefaultColumnState(uint iColumn, out SHCOLSTATEF pcsFlags)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.GetDefaultColumnState(folder, iColumn, out pcsFlags);
        }

        int IShellFolder2.GetDetailsEx(IntPtr pidl, SHCOLUMNID pscid, out object pv)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.GetDetailsEx(folder, pidl, pscid, out pv);
        }

        int IShellFolder2.GetDetailsOf(IntPtr pidl, uint iColumn, out IntPtr psd)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.GetDetailsOf(folder, pidl, iColumn, out psd);
        }

        int IShellFolder2.MapColumnToSCID(uint iColumn, out SHCOLUMNID pscid)
        {
            //  Use the ShellFolderImpl to handle the details.
            return ShellFolderImpl.MapColumnToSCID(folder, iColumn, out pscid);
        }

        #endregion
    }
}