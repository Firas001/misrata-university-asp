<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="WebApplication1.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
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
                           <img width="100px" src="imgs/generaluser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>الملف الشخصي الخاص بك</h4>
                           <span>حالة الحساب - </span>
                           <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="الحالة"></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>الاسم الكامل</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="الاسم الكامل"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>تاريخ الميلاد</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="تاريخ الميلاد" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>رقم الهاتف</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="رقم الهاتف" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>البريد الإلكتروني</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="البريد الإلكتروني" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>القسم</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="القسم" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>

                     <div class="col-md-6">
                        <label>المعدل التراكمي</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="المعدل التراكمي" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>معلومات عن الطالب</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="معلومات عامة" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <span class="badge badge-pill badge-info">بيانات الدخول</span>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>رقم القيد</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="رقم القيد" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>كلمة المرور القديمة</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="كلمة المرور القديمة" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>كلمة المرور الجديدة</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="كلمة المرور الجديدة" TextMode="Password" pattern="(?=.*[a-z])(?=.*[A-Z]).{4,}" title="يجب أن تكون كلمة المرور أربع حروف على الأقل وتحتوي على حرف كبير وحرف صغير"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="تعديل" OnClick="Button1_Click" />
                           </div>
                        </center>
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< الرجوع إلى الرئيسية</a><br><br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/books1.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>المقررات الدراسية الخاصة بك</h4>
                           <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="معلومات المادة"></asp:Label>
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
								<asp:GridView ID="GridView1" class="table table-striped table-bordered table-responsive-sm" 
                                    runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="رقم القيد">
                                            <ItemTemplate>
                                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("userID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="اسم الطالب">
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("full_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="رمز المادة">
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" Text='<%# Eval("material_id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="اسم المادة">
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("material_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="تاريخ التنزيل">
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Text='<%# Convert.ToDateTime(Eval("book_date")).ToString("d/M/yyyy") %>'></asp:Label>
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