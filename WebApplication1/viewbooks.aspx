<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="WebApplication1.viewbooks" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <script type="text/javascript">
            $(document).ready(function () {
                $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });
        </script>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
            <div class="row">

                <div class="col-sm-12">
                    <center>
                        <h3>المقررات الدراسية التي تم نشرها من إدارة الكلية</h3>
                    </center>
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="card">
                            <div class="card-body">

                                <div class="row">
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionStringg %>" SelectCommand="select * from materials, instructors, departments where materials.department_id = departments.department_id and materials.instructor_id = instructors.instructor_id"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="material_id" DataSourceID="SqlDataSource1">
                           <Columns>
                              <asp:BoundField DataField="material_id" HeaderText="ID" ReadOnly="True" SortExpression="material_id" >
                                 <ControlStyle Font-Bold="True" />
                                 <ItemStyle Font-Bold="True" />
                              </asp:BoundField>
                              <asp:TemplateField>
                                 <ItemTemplate>
                                    <div class="container-fluid">
                                       <div class="row">
                                          <div class="col-lg-10">
                                             <div class="row">
                                                <div class="col-12">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("material_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   <span>مدرس المادة - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("instructor_name") %>'></asp:Label>
                                                   &nbsp;
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                    <span>القسم - </span>
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("department_name") %>'></asp:Label>
                                                   &nbsp;
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                    <span>إجمالي المقاعد: </span>
                                                   <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("seats_no") %>'></asp:Label>
                                                   &nbsp;| المقاعد المحجوزة:
                                                   <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("reserved_seats") %>'></asp:Label>
                                                   &nbsp;| المقاعد المتاحة:
                                                   <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("available_seats") %>'></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   معلومات إضافية:
                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("material_info") %>'></asp:Label>
                                                </div>
                                             </div>
                                          </div>
                                          <div class="col-lg-2">
                                             <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("material_link") %>' />
                                          </div>
                                       </div>
                                    </div>
                                 </ItemTemplate>
                              </asp:TemplateField>
                           </Columns>
                        </asp:GridView>
                     </div>
                  </div>

                            </div>
                        </div>
                    </div>
                </div>
                <center>
                    <a href="homepage.aspx">
                        << الرجوع للرئيسية</a><span class="clearfix"></span>
                            <br />
                            <center>
            </div>
        </div>

        
    </asp:Content>