<%@ Page Language="C#" MasterPageFile="~/evenuadmin/evenuadmin.master" AutoEventWireup="true" CodeFile="change-password.aspx.cs" Inherits="evenuadmin_change_password" Title="Change Password | Evenu Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHParent" Runat="Server">
<h1>Change Password</h1>

    <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">Old Password:*</label>
        </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:TextBox ID="txtOldPwd"  CssClass="txtBox txt-color round3 p100 contBorder" 
                 runat="server" MaxLength="15" TextMode="Password" ></asp:TextBox>
            </div>
    </div>
    
    
    <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">New Password:*</label>
        </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:TextBox ID="txtNewPwd"  CssClass="txtBox txt-color round3 p100 contBorder" 
                 runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
            </div>
    </div>
    
    <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">Re-Enter New Password:*</label>
        </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:TextBox ID="txtConfirmPwd"  CssClass="txtBox txt-color round3 p100 contBorder" 
                 runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
            </div>
    </div>
    
    
    
    <div class="clrFlt"></div>
    <div class="spacer"></div>
    <%=errMsg %>
     <div class="pad_10">
        <asp:Button ID="cmdCancel" runat="server" Text="Cancel" 
             CssClass="achor-gray round3 right themeGray mar-R-12" onclick="cmdCancel_Click"/>
        <asp:Button ID="cmdSave" runat="server" Text="Save" 
             CssClass="achor round3 right themeBlue mar-R-12" onclick="cmdSave_Click"/>
        <div class="clrFlt"></div>
        
    </div>
</asp:Content>

