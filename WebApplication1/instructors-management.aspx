<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="instructors-management.aspx.cs" Inherits="WebApplication1.instructors_management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <script type="text/javascript">
       $(document).ready(function () {

           //$(document).ready(function () {
           //$('.table').DataTable();
           // });

           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
           //$('.table1').DataTable();
       });
       </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>معلومات الأستاذ</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/publisher.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>معرف الأستاذ</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="المعرف"></asp:TextBox>
                              <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>اسم الأستاذ</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="اسم الأستاذ"></asp:TextBox>
                        </div>
                     </div>
                      <div class="col-md-4">
                        <label>القسم</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                              <asp:ListItem Text="Publisher 2" Value="Publisher 2" />
                           </asp:DropDownList>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="إضافة" OnClick="Button2_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="تعديل" OnClick="Button3_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="حذف" OnClick="Button4_Click" />
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>قائمة الأساتذة</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM instructors, departments where instructors.department_id = departments.department_id"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="instructor_id" DataSourceID="SqlDataSource1">
                           <Columns>
                              <asp:BoundField DataField="instructor_id" HeaderText="معرف الأستاذ" ReadOnly="True" SortExpression="instructor_id" />
                              <asp:BoundField DataField="instructor_name" HeaderText="اسم الأستاذ" SortExpression="instructor_name" />
                              <asp:BoundField DataField="department_name" HeaderText="القسم" SortExpression="department_name" />
                           </Columns>
                        </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>

</asp:Content>
