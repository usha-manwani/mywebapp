<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="trythis.Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterBody" runat="server">
    <div>
        <div class="row">
            <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row" style="width:100%">
                <div class="thead-dark"><h3>Schedule</h3>
                    <table>
                        <tr>

                       <td class="col-md-4">
                    <div class="col-md-4" >
                        <asp:DropDownList Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
                            CssClass="btn btn-default dropdown "  ID="ddlInstitute" data-toggle="dropdown"  runat="server" >
                            <asp:ListItem Text="select" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                           </td><td><span><i class="fa fa-angle-double-right"></i></span></td> <td class="col-md-4">
                    <div >
                        <asp:DropDownList Width="150px" ID="ddlGrade" AutoPostBack="true"
                            CssClass="btn btn-default dropdown" data-toggle="dropdown" 
                            OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" runat="server" >
                            <asp:ListItem Text="select" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                         </td> <td><span><i class="fa fa-angle-double-right"></i></span></td>  <td class="col-md-4">
                    <div >
                        <asp:DropDownList  ID="ddlClass" Width="150px" 
                            AppendDataBoundItems="true" runat="server" CssClass="btn btn-default  dropdown" 
                            data-toggle="dropdown" 
                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" >
                            <asp:ListItem Text="select" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                         </td>   </tr>
                    </table>
                </div>
                    </div>
                <div class="row" style="width:100%">
                    <div class="col-md-12">
                    <asp:GridView ID="excelgrd" runat="server" AutoGenerateColumns="false" ShowFooter="true">
            <Columns>
                <asp:BoundField DataField="Slno" HeaderText="SL No" />
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:TextBox ID="txnm" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:TextBox ID="txdesc" runat="server"></asp:TextBox>
                    </ItemTemplate>
                      <FooterStyle HorizontalAlign="Right" />
                      <FooterTemplate>
                       <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />
                      </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="svbtn" runat="server" Text="Save" OnClick="svbtn_Click" />
                        </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
            
        </div>
        
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="masterSideBody" runat="server">
</asp:Content>
