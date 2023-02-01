<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="materials-management.aspx.cs" Inherits="WebApplication1.materials_management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
         $(document).ready(function () {
             $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
         });

         function readURL(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();

                 reader.onload = function (e) {
                     $('#imgview').attr('src', e.target.result);
                 };

                 reader.readAsDataURL(input.files[0]);
             }
         }

     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


      <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>معلومات المادة</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img id="imgview" Height="150px" Width="100px" src="imgs/books1.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>رمز المادة</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="رمز المادة"></asp:TextBox>
                              <asp:Button class="form-control btn btn-primary" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-8">
                        <label>اسم المادة</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="اسم المادة"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>مدرس المادة</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                              <asp:ListItem Text="Publisher 2" Value="Publisher 2" />
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>القسم</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                              <asp:ListItem Text="A1" Value="a1" />
                              <asp:ListItem Text="a2" Value="a2" />
                           </asp:DropDownList>
                        </div>
                     </div>
                  </div>


                  <div class="row">
                     <div class="col-md-4">
                        <label>عدد المقاعد</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="عدد المقاعد" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>المقاعد المحجوزة</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="المقاعد المحجوزة" TextMode="Number" ReadOnly="True" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>المقاعد المتوفرة</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="المقاعد المتوفرة" TextMode="Number" ReadOnly="True" OnTextChanged="TextBox7_TextChanged"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-12">
                        <label>معلومات إضافية</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="إضافة" OnClick="Button1_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="تعديل" OnClick="Button3_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="حذف" OnClick="Button2_Click" />
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< الرجوع للرئيسية</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>المقررات الدراسية التي تم نشرها</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
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
   </div>


</asp:Content>
