<%@ Page Language="C#" MasterPageFile="~/evenuadmin/evenuadmin.master" AutoEventWireup="true" CodeFile="media.aspx.cs" Inherits="shahadmin_news" Title="News Updates | Evenu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    function delConfirm()
    {
        if(confirm("Are you sure to delete?") == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHParent" Runat="Server">
<h1>News Updates</h1>
<div id="editNews" runat="server">
    <div class="col30p">
        <div class="pad_10">
        <label class="label-span label-color">Date:</label>
        </div>
    </div>
    <div class="col70p">
        <div class="pad_10">
                <asp:TextBox ID="txtDate"  CssClass="txtBox txt-color round3 contBorder mar-R-12" Width="170" runat="server" ></asp:TextBox>
                
                <%--<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </cc1:ToolkitScriptManager>--%>
                <%--<asp:ImageButton ID="imgPopup" ImageUrl="images/datePic.png" ImageAlign="Bottom" runat="server" />--%>
                <cc1:calendarextender ID="Calendar1" PopupButtonID="txtDate" runat="server" TargetControlID="txtDate"
                    Format="dd/MM/yyyy">
                </cc1:calendarextender>
             <div class="clrFlt"></div>
        </div>
    </div>
    <div class="clrFlt"></div>

    <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">Title:*</label>
        </div>
     </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:TextBox ID="txtTitle"  CssClass="txtBox txt-color round3 p100 contBorder" 
                 runat="server" MaxLength="100"></asp:TextBox>
            </div>
    </div>
    <div class="clrFlt"></div>
    <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">News Details:*</label>
        </div>
    </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:TextBox ID="txtNDetails"  CssClass="txtBox txt-color round3 p100 contBorder nonResize" runat="server"  Height="150px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="clrFlt"></div>
    <div class="col30p">
        <div class="pad_10">
             <label class="label-span label-color">Photo upload:</label>
        </div>
    </div>
    <div class="col70p">
        <div class="pad_10">
             <asp:FileUpload ID="flpPhoto" runat="server"  CssClass="txtBox txt-color round3 p100 contBorder"/>
        </div>
    </div>
    <div class="col30p">
    </div>
    <div class="col70p">
        <div class="pad_10">
        <%=errMsg %>
        </div>
    </div>
    <div class="clrFlt"></div>
    <div class="spacer"></div>
    <div class="pad_10">

    <asp:Button ID="cmdCancel" runat="server" Text="Cancel" 
        CssClass="achor-gray round3 right themeGray " onclick="cmdCancel_Click" />
    <asp:Button ID="cmdDelete" runat="server" Text="Delete" CssClass="achor-gray round3 right themeGray mar-R-12" OnClientClick="return delConfirm();" OnClick="cmdDelete_Click" />
    <asp:Button ID="cmdReset" runat="server" Text="Reset" 
        CssClass="achor-gray round3 right themeGray mar-R-12" 
        onclick="cmdReset_Click" />
    <asp:Button ID="cmdSave" runat="server" Text="Save" 
        CssClass="achor round3 right themeBlue mar-R-12" onclick="cmdSave_Click" />
        <div class="clrFlt"></div>
    </div>
    
</div>
<div id="showNews" runat="server">
<div class="pad_10">
    <a href="media.aspx?action=new" class="anchor">Add News</a>
</div>
<div class="spacer"></div>
    <div class="pad_10">
    <asp:GridView  CssClass="gvApp" ID="gvNews" runat="server" 
        AutoGenerateColumns="False" onrowdatabound="gvNews_RowDataBound">
        <RowStyle CssClass ="row" />
        <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:BoundField  HeaderText="Id"  DataField="newsId" SortExpression="newsId">
                    <ItemStyle CssClass="HideCol" />
                    <HeaderStyle CssClass="HideCol" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Date" DataField = "newsDateChr" 
                    SortExpression= "newsDateChr" >
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Title" DataField = "newsTitle" SortExpression= "newsTitle">
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
                <span class="warning">No News to display :(</span>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</div>
</asp:Content>

