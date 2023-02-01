<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="book-material.aspx.cs" Inherits="WebApplication1.book_material" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

		<script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("< thead ></thead >").append($(this).find("tr: first"))).dataTable();
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
									<h4>حذف وإضافة المواد</h4>
								</center>
							</div>
						</div>
						<div class="row">
							<div class="col">
								<center>
									<img width="100px" src="imgs/books.png" />
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
									<label>رقم قيد الطالب</label>
									<div class="form-group">
										<asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="رقم قيد الطالب"></asp:TextBox>
									</div>
								</div>
								<div class="col-md-6">
									<label>رمز المادة</label>
									<div class="input-group">
										<asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="رمز المادة"></asp:TextBox>
										<asp:Button for="TextBox1" class="btn btn-dark" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-md-6">
									<label>اسم الطالب</label>
									<div class="form-group">
										<asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="اسم الطالب" ReadOnly="True"></asp:TextBox>
									</div>
								</div>
								<div class="col-md-6">
									<label>اسم المادة</label>
									<div class="form-group">
										<asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="اسم المادة" ReadOnly="True"></asp:TextBox>
									</div>
								</div>
							</div>
							<div class="row">
								<div class="col-6">
									<asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="إضافة" OnClick="Button2_Click" />
								</div>
								<div class="col-6">
									<asp:Button ID="Button4" class="btn btn-lg btn-block btn-success" runat="server" Text="حذف" OnClick="Button4_Click" />
								</div>
							</div>
						</div>
					</div>
					<a href="homepage.aspx"><< الرجوع إلى الرئيسية
					</a>
					<br>
						<br>
						</div>
						<div class="col-md-7">
							<div class="card">
								<div class="card-body">
									<div class="row">
										<div class="col">
											<center>
												<h4>المواد التي تم تنزيلها</h4>
											</center>
										</div>
									</div>
									<div class="row">
										<div class="col">
											<hr>
											</div>
										</div>
										<div class="row">
											<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:elibraryDBConnectionString %>' SelectCommand="select * from book_material, users, materials WHERE users.userID = book_material.userID and materials.material_id = book_material.material_id">
											</asp:SqlDataSource>
											<div class="col">
												<asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
													<Columns>
														<asp:BoundField DataField="userID" HeaderText="رقم القيد" SortExpression="userID"></asp:BoundField>
														<asp:BoundField DataField="full_name" HeaderText="اسم الطالب" SortExpression="full_name"></asp:BoundField>
														<asp:BoundField DataField="material_id" HeaderText="رمز المادة" SortExpression="material_id"></asp:BoundField>
														<asp:BoundField DataField="material_name" HeaderText="اسم المادة" SortExpression="material_name"></asp:BoundField>
														<asp:BoundField DataField="book_date" HeaderText="تاريخ التنزيل" SortExpression="book_date" DataFormatString="{0:d}"></asp:BoundField>
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
