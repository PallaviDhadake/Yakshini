<%@ Page Language="C#" MasterPageFile="~/evenuadmin/evenuadmin.master" AutoEventWireup="true" CodeFile="specifications.aspx.cs" Inherits="evenuadmin_ProductSpecs" Title="Product Details | Evenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHParent" Runat="Server">
<h1>Product Specifications</h1>



<div id="editProducts" runat ="server">
    <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">Device Type:*</label>
        </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:DropDownList ID="ddrDevice" runat="server" 
                 CssClass="txtBox txt-color round3 ddr100 contBorder" AutoPostBack="True" 
                 onselectedindexchanged="ddrDevice_SelectedIndexChanged">
                <asp:ListItem Value="0"><-Select-></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    
    <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">Device Category:*</label>
        </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:DropDownList ID="ddrCategory" runat="server" 
                 CssClass="txtBox txt-color round3 ddr100 contBorder">
                <asp:ListItem Value="0"><-Select-></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    
    <div class="col30p">
    <div class="pad_10">
             <label class="label-span label-color">Brand Name:*</label>
    </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:DropDownList ID="ddrBrand" runat="server" CssClass="txtBox txt-color round3 ddr100 contBorder">
                <asp:ListItem Value="0">-Select-</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    
    
    
    <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">Product Name:*</label>
        </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:TextBox ID="txtName"  CssClass="txtBox txt-color round3 p100 contBorder" 
                 runat="server" MaxLength="30" placeholder="Name of Product"></asp:TextBox>
            </div>
    </div>
    
    <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">Specifications:*</label>
        </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:TextBox ID="txtSpecs"  CssClass="txtBox txt-color round3 p100 contBorder nonResize" 
                 runat="server" TextMode="MultiLine" Height="100" placeholder="Detail product Specification" MaxLength="500"></asp:TextBox>
            </div>
    </div>
     <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">Warranty:*</label>
        </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:TextBox ID="txtWarranty"  CssClass="txtBox txt-color round3 p100 contBorder" placeholder="e.g: 3 Years"
                 runat="server" MaxLength="30"></asp:TextBox>
            </div>
    </div>
    
    <div class="clrFlt"></div>
<div class="col30p">
    <div class="pad_10">
          <label class="label-span label-color">MRP:*</label>
    </div>
</div>
<div class="col233">
    <div class="pad_10">
         <asp:TextBox ID="txtMrp"  CssClass="txtBox txt-color round3 p50 contBorder" MaxLength="6" placeholder="e.g: 23000" runat="server"></asp:TextBox>
    </div>
</div>
<div class="col100">
    <div class="pad_10">
         <label class="label-span label-color">Offer:</label>
    </div>
</div>
<div class="col233">
    <div class="pad_10">
        <asp:TextBox ID="txtOffer"  CssClass="txtBox txt-color round3 p50 contBorder" MaxLength="6" runat="server" placeholder="e.g: 20000"></asp:TextBox>
    </div>
</div>
    <div class="clrFlt"></div>

     <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">Image:*</label>
        </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:FileUpload ID="flpPhoto" runat="server"  CssClass="txtBox txt-color round3 p100 contBorder"/>
            </div>
    </div>


<div class="clrFlt"></div>
<div class="spacer"></div>
<%=errMsg %>
 <div class="pad_10">
    <asp:Button ID="cmdCancel" runat="server" Text="Cancel" 
         CssClass="achor-gray round3 right themeGray mar-R-12" onclick="cmdCancel_Click"/>
    <asp:Button ID="cmdDelete" runat="server" Text="Delete" 
         CssClass="achor-gray round3 right themeGray mar-R-12" onclick="cmdDelete_Click" />
    <asp:Button ID="cmdReset" runat="server" Text="Reset" 
         CssClass="achor-gray round3 right themeGray mar-R-12" 
         onclick="cmdReset_Click" />
    <asp:Button ID="cmdSave" runat="server" Text="Save" 
         CssClass="achor round3 right themeBlue mar-R-12" onclick="cmdSave_Click"/>
    <div class="clrFlt"></div>
    
</div>

</div>
<div id="viewProducts" runat="server">

<div class="pad_10">
    <a href="specifications.aspx?action=new" class="anchor">Add Product</a>
</div>
<div class="spacer"></div>
    <div class="pad_10">
    <asp:GridView  CssClass="gvApp" ID="gvProducts" runat="server" 
        AutoGenerateColumns="False" onrowdatabound="gvProducts_RowDataBound" >
        <RowStyle CssClass ="row" />
        <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:BoundField  HeaderText="Id"  DataField="prodId">
                    <ItemStyle CssClass="HideCol" />
                    <HeaderStyle CssClass="HideCol" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Brand" DataField = "brandName">
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Product Name" DataField = "prodName" SortExpression= "newsTitle">
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
                <span class="warning">No Products to display :(</span>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>

</div>
    
    
    
    
    
    
    
</asp:Content>

