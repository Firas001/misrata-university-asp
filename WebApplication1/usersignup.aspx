<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="WebApplication1.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   
        <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
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
                           <h4>تسجيل كطالب جديد</h4>
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
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="التاريخ" TextMode="Date"></asp:TextBox>
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
                        <label>المعدل التراكمي</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Average" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>

                      <div class="col-md-6">
                        <label>القسم</label>
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="D1" Value="d1" />
                              <asp:ListItem Text="D2" Value="d2" />
                           </asp:DropDownList>

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
                           <span class="badge badge-pill badge-info">بيانات اعتماد التسجيل</span>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>رقم القيد</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="رقم القيد" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>كلمة المرور</label>
                        <div class="form-group">
                            <asp:TextBox type="password" ID="TextBox9" runat="server" CssClass="form-control"  placeholder="كلمة المرور" TextMode="Password" pattern="(?=.*[a-z])(?=.*[A-Z]).{4,}" title="يجب أن تكون كلمة المرور أربع حروف على الأقل وتحتوي على حرف كبير وحرف صغير"></asp:TextBox>
                            <asp:RequiredFieldValidator id="RequiredFieldPassword" runat="server"
                              ControlToValidate="TextBox9"
                              ErrorMessage="لا يمكن ترك كلمة المرور فارغة."
                              ForeColor="Red">
                            </asp:RequiredFieldValidator>

                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="تسجيل" OnClick="Button1_Click" />
                        </div>
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"> << الرجوع إلى الرئيسية</a><br><br>
         </div>
      </div>
   </div>

</asp:Content>