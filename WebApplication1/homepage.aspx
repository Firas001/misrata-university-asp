<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="WebApplication1.homepage"  EnableEventValidation="false" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

   <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-indicators">
          <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
          <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
          <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner">
          <div class="carousel-item active">
            <img src="img/umit_3.JPG" class="d-block w-100" alt="...">
            <div class="carousel-caption">
              <h5>جامعة مصراتة</h5>
                              <p>نص رئيسي يتكلم عن أحد قيم الجامعة في في سلايد خاص، يمكن عرض خبر أو جدث خاص هنا</p>
                              <p><a href="#" class="btn btn-warning mt-3">للمزيد</a></p>
            </div>
          </div>
          <div class="carousel-item">
            <img src="img/umit_2.JPG" class="d-block w-100" alt="...">
            <div class="carousel-caption">
              <h5>جامعة مصراتة</h5>
                              <p>نص رئيسي يتكلم عن أحد قيم الجامعة في في سلايد خاص، يمكن عرض خبر أو جدث خاص هنا</p>
                              <p><a href="#" class="btn btn-warning mt-3">للمزيد</a></p>
            </div>
          </div>
          <div class="carousel-item">
            <img src="img/umit_1.JPG" class="d-block w-100" alt="...">
            <div class="carousel-caption">
              <h5>جامعة مصراتة</h5>
                              <p>نص رئيسي يتكلم عن أحد قيم الجامعة في في سلايد خاص، يمكن عرض خبر أو جدث خاص هنا</p>
                              <p><a href="#" class="btn btn-warning mt-3">للمزيد</a></p>
            </div>
          </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
          <span class="carousel-control-next-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Next</span>
        </button>
      </div>

      <!-- about section starts -->
      <section id="about" class="about section-padding">
          <div class="container">
              <div class="row">
                  <div class="col-lg-4 col-md-12 col-12" data-aos="fade-up">
                      <div class="about-img">
                          <img src="img/about.jpg" alt="" class="img-fluid">
                      </div>
                  </div>
                  <div class="col-lg-8 col-md-12 col-12 ps-lg-5 mt-md-5" data-aos="fade-down">
                      <div class="about-text">
                            <h2>حول الجامعة</h2>
                            <p>هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة يتكلم عن تفاصيل متعلقة بالجامعةالنصوص المؤقتة عيجب ان تظهر بالشكل كاملاً، هذا النص يمكن أن يتم تركيبه على أي تصميم دون مشكلة فلن يبدو وكأنه نص منسوخ، غير منظم، غير منسق، أو حتى غير مفهوم. لأنه مازال نصاً بديلاً ومؤقتاً.</p>
                            <a href="#" class="btn btn-warning">معرفة المزيد</a>
                      </div>
                  </div>
              </div>
          </div>
      </section>
      <!-- about section Ends -->
      <!-- services section Starts -->
      <section class="services section-padding" id="services">
          <div class="container">
              <div class="row">
                  <div class="col-md-12">
                      <div class="section-header text-center pb-5">
                          <h2>رسالة الجامعة</h2>
                          <p>نص فرعي خاص بجزء رسالة الجامعة</p>
                      </div>
                  </div>
              </div>
              <div class="row">
                <div class="col-12 col-md-12 col-lg-4" data-aos="zoom-in">
                    <div class="card text-white text-center bg-dark pb-2 bk-card">
                        <div class="card-body">
                            <i class="bi bi-laptop"></i>
                            <h3 class="bi bi-laptop">الرسالة الأولى</h3>
                            <p class="lead">النصوص المؤقتة يجب ان تظهر بالشكل كاملاً، هذا النص يمكن أن يتم تركيبه على أي تصميم دون مشكلة فلن يبدو وكأنه نص منسوخ، نص الرسالة</p>
                            <button class="btn bg-warning text-dark">للمزيد</button>
                        </div>
                    </div>
                </div>
                  <div class="col-12 col-md-12 col-lg-4" data-aos="zoom-in">
                      <div class="card text-white text-center bg-dark pb-2 bk-card">
                          <div class="card-body">
                            <i class="bi bi-journal"></i>
                              <h3 class="bi bi-laptop">الرسالة الثانية</h3>
                            <p class="lead">النصوص المؤقتة يجب ان تظهر بالشكل كاملاً، هذا النص يمكن أن يتم تركيبه على أي تصميم دون مشكلة فلن يبدو وكأنه نص منسوخ، نص الرسالة</p>
                              <button class="btn bg-warning text-dark">للمزيد</button>
                          </div>
                      </div>
                  </div>
                  <div class="col-12 col-md-12 col-lg-4" data-aos="zoom-in">
                      <div class="card text-white text-center bg-dark pb-2 bk-card">
                          <div class="card-body">
                            <i class="bi bi-intersect"></i>
                              <h3 class="bi bi-laptop">الرسالة الثالثة</h3>
                            <p class="lead">النصوص المؤقتة يجب ان تظهر بالشكل كاملاً، هذا النص يمكن أن يتم تركيبه على أي تصميم دون مشكلة فلن يبدو وكأنه نص منسوخ، نص الرسالة</p>
                              <button class="btn bg-warning text-dark">للمزيد</button>
                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </section>
      <!-- services section Ends -->

      <!-- portfolio strats -->
      <section id="portfolio" class="portfolio section-padding">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="section-header text-center pb-5">
                        <h2>أهم مشاريعنا</h2>
                        <p>نص فرعي خاص بجزء مشاريع الجامعة</p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-md-12 col-lg-4" data-aos="zoom-in-up">
                    <div class="card text-light text-center bg-white pb-2 wh-card">
                        <div class="card-body text-dark">
                          <div class="img-area mb-4">
                              <img src="img/project-1.jpg" class="img-fluid" alt="">
                          </div>
                            <h3 class="card-title">المشروع الأول</h3>
                            <p class="lead">هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة يتكلم عن مشاريع متعلقة بالجامعة النصوص المؤقتة يجب ان تظهر بالشكل كاملاً، هذا النص يمكن أن يتم تركيبه على أي تصميم </p>
                            <button class="btn bg-warning text-dark">للمزيد</button>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-12 col-lg-4" data-aos="zoom-in-up">
                    <div class="card text-light text-center bg-white pb-2 wh-card">
                        <div class="card-body text-dark">
                          <div class="img-area mb-4">
                              <img src="img/project-2.jpg" class="img-fluid" alt="">
                          </div>
                            <h3 class="card-title">المشروع الثاني</h3>
                            <p class="lead">هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة يتكلم عن مشاريع متعلقة بالجامعة النصوص المؤقتة يجب ان تظهر بالشكل كاملاً، هذا النص يمكن أن يتم تركيبه على أي تصميم </p>
                            <button class="btn bg-warning text-dark">للمزيد</button>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-12 col-lg-4" data-aos="zoom-in-up">
                    <div class="card text-light text-center bg-white pb-2 wh-card">
                        <div class="card-body text-dark">
                          <div class="img-area mb-4">
                              <img src="img/project-3.jpg" class="img-fluid" alt="">
                          </div>
                            <h3 class="card-title">المشروع الثالث</h3>
                            <p class="lead">هذا النص هو مثال لنص يمكن أن يستبدل في نفس المساحة يتكلم عن مشاريع متعلقة بالجامعة النصوص المؤقتة يجب ان تظهر بالشكل كاملاً، هذا النص يمكن أن يتم تركيبه على أي تصميم </p>
                            <button class="btn bg-warning text-dark">للمزيد</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
      </section>
      <!-- portfolio ends -->

      <!-- events starts -->
      <section class="team section-padding" id="team">
          <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="section-header text-center pb-5">
                        <h2>الأحداث</h2>
                        <p>الأحداث التي تم انعقادها في الجامعة أو خارجها <br>تعرف على أحدث الأخبار لدى جامعة مصراتة.</p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-md-6 col-lg-3" data-aos="fade-up">
                    <div class="card text-center bg-white wh-card">
                        <div class="card-body">
                            <img src="img/team-1.jpg" alt="" class="img-fluid rounded">
                        <h3 class="card-title py-2">حدث افتراضي</h3>
                        <p class="card-text">نص افتراضي يعرض بعض المعلومات عن حدث أقامته الجامعة يفيد الزائر أو يلهم البعض.</p>
                
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-3" data-aos="fade-up">
                    <div class="card text-center bg-white wh-card">
                        <div class="card-body">
                            <img src="img/team-2.jpg" alt="" class="img-fluid rounded">
                        <h3 class="card-title py-2">حدث افتراضي</h3>
                        <p class="card-text">نص افتراضي يعرض بعض المعلومات عن حدث أقامته الجامعة يفيد الزائر أو يلهم البعض.</p>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-3" data-aos="fade-up">
                    <div class="card text-center bg-white wh-card">
                        <div class="card-body">
                            <img src="img/team-3.jpg" alt="" class="img-fluid rounded">
                        <h3 class="card-title py-2">حدث افتراضي</h3>
                        <p class="card-text">نص افتراضي يعرض بعض المعلومات عن حدث أقامته الجامعة يفيد الزائر أو يلهم البعض.</p>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-3" data-aos="fade-up">
                    <div class="card text-center bg-white wh-card">
                        <div class="card-body">
                            <img src="img/team-4.jpg" alt="" class="img-fluid rounded">
                        <h3 class="card-title py-2">حدث افتراضي</h3>
                        <p class="card-text">نص افتراضي يعرض بعض المعلومات عن حدث أقامته الجامعة يفيد الزائر أو يلهم البعض.</p>
                        </div>
                    </div>
                </div>
            </div>
          </div>
      </section>
      <!-- events ends -->

      <!-- Contact starts -->
      <section id="contact" class="contact section-padding">
        <div class="container mt-5 mb-5">
            <div class="row">
                <div class="col-md-12">
                    <div class="section-header text-center pb-5">
                        <h2>تواصل معنا</h2>
                        <p>لا تتردد في كتابة أي استفسار أو ملاحظة إلينا <br>سنكون سعداء بتواصلك معنا.</p>
                    </div>
                </div>
            </div>
			<div class="row m-0">
				<div class="col-md-12 p-0 pt-4 pb-4"  data-aos="flip-up">
					<form action="#" class="bg-light p-4 m-auto">
						<div class="row">
							<div class="col-md-12">
								<div class="mb-3">
									<input class="form-control bg-light form-color" placeholder="الاسم الكامل" type="text">
								</div>
							</div>
							<div class="col-md-12">
								<div class="mb-3">
									<input class="form-control bg-light form-color" placeholder="البريد الإلكتروني" type="email">
								</div>
							</div>
							<div class="col-md-12">
								<div class="mb-3">
									<textarea class="form-control bg-light form-color" placeholder="الرسالة" rows="3"></textarea>
								</div>
							</div><button class="btn btn-warning btn-lg btn-block mt-3" type="button">إرسال</button>
						</div>
					</form>
				</div>
			</div>
		</div>

      </section>
      <!-- contact ends -->

      
</asp:Content>