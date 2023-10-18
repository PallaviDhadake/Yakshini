<%@ Page Language="C#" MasterPageFile="~/evenuadmin/evenuadmin.master" AutoEventWireup="true" CodeFile="brand-master.aspx.cs" Inherits="evenuadmin_brand_master" Title="Brand Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHParent" Runat="Server">

<h1>Brand Names</h1>

<div id="editBrand" runat="server">
    <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">Brand Name:*</label>
        </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:TextBox ID="txtBrand"  CssClass="txtBox txt-color round3 p100 contBorder" runat="server" MaxLength="20" placeholder="Brand Name"></asp:TextBox>
        </div>
    </div>
    
    
    <div class="clrFlt"></div>
    <div class="spacer"></div>
    <%=errMsg %>

    <div class="pad_10">
        <asp:Button ID="cmdCancel" runat="server" Text="Cancel" 
             CssClass="achor-gray round3 right themeGray mar-R-12" 
            onclick="cmdCancel_Click"/>
        <asp:Button ID="cmdDelete" runat="server" Text="Delete" 
             CssClass="achor-gray round3 right themeGray mar-R-12" 
            onclick="cmdDelete_Click"/>
        <asp:Button ID="cmdReset" runat="server" Text="Reset" 
             CssClass="achor-gray round3 right themeGray mar-R-12" 
            onclick="cmdReset_Click"/>
        <asp:Button ID="cmdSave" runat="server" Text="Save" 
             CssClass="achor round3 right themeBlue mar-R-12" onclick="cmdSave_Click"/>
        <div class="clrFlt"></div>
    </div>
</div>


<div id="showBrand" runat="server">

<div class="pad_10">
    <a href="brand-master.aspx?action=new" class="anchor">Add Brand</a>
</div>
<div class="spacer"></div>
    <div class="pad_10">
    <asp:GridView  CssClass="gvApp" ID="gvBrands" runat="server" 
        AutoGenerateColumns="False" onrowdatabound="gvBrands_RowDataBound">
        <RowStyle CssClass ="row" />
        <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:BoundField  HeaderText="Id"  DataField="brandId" >
                    <ItemStyle CssClass="HideCol" />
                    <HeaderStyle CssClass="HideCol" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Brand Name" DataField = "brandName">
                    <HeaderStyle Width="20%" />
                    <ItemStyle CssClass="myColumn" />
                </asp:BoundField>
               <%-- <asp:BoundField ControlStyle-CssClass="nonImp" HeaderText="Description" DataField="newsInfo" SortExpression="newsInfo">
                    <ItemStyle CssClass="nonImp" />
                    <HeaderStyle CssClass="nonImp" />
                </asp:BoundField>--%>
                <asp:TemplateField>
                    <HeaderStyle Width="10%" />
                    <ItemTemplate>
                        <asp:Literal ID="litAnch" runat="server"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <span class="warning">No Brands to display :(</span>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>


</div>

</asp:Content>

