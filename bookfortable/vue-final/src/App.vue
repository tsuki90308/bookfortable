<script setup>
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.min.js";

import "./js/jquery-3.3.1.min.js";
import "./js/bootstrap.min.js";
import "./js/jquery.nice-select.min.js";
import "./js/jquery.nicescroll.min.js";
import "./js/jquery.magnific-popup.min.js";
import "./js/jquery.countdown.min.js";
import "./js/jquery.slicknav.js";
import "./js/mixitup.min.js";
import "./js/owl.carousel.min.js";
import "./js/main.js";

const currentYear = new Date().getFullYear();
</script>

<template>
  <!-- <RouterLink to="/">首頁</RouterLink>
    <RouterLink to="/about">關於我們</RouterLink>
    <RouterLink to="/contact">聯絡我們</RouterLink>
    <RouterLink to="/wishlist">願望清單</RouterLink>  -->
  <head>
    <meta charset="UTF-8" />
    <meta name="description" content="Male_Fashion Template" />
    <meta name="keywords" content="Male_Fashion, unica, creative, html" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>Male-Fashion | Template</title>

    <!-- Google Font -->
    <link
      href="https://fonts.googleapis.com/css2?family=Nunito+Sans:wght@300;400;600;700;800;900&display=swap"
      rel="stylesheet"
    />
    <!-- Css Styles -->
    <link rel="stylesheet" href="./css/bootstrap.min.css" type="text/css" />
    <link rel="stylesheet" href="./css/font-awesome.min.css" type="text/css" />
    <link rel="stylesheet" href="./css/elegant-icons.css" type="text/css" />
    <link rel="stylesheet" href="./css/magnific-popup.css" type="text/css" />
    <link rel="stylesheet" href="./css/nice-select.css" type="text/css" />
    <link rel="stylesheet" href="./css/owl.carousel.min.css" type="text/css" />
    <link rel="stylesheet" href="./css/slicknav.min.css" type="text/css" />
    <link rel="stylesheet" href="./css/style.css" type="text/css" />
  </head>

  <body>
    <!-- Page Preloder -->
    <div id="preloder">
      <div class="loader"></div>
    </div>

    <!-- Offcanvas Menu Begin -->
    <div class="offcanvas-menu-overlay"></div>
    <div class="offcanvas-menu-wrapper">
      <div class="offcanvas__option">
        <div class="offcanvas__links">
          <a href="#">Sign in</a>
          <a href="#">FAQs</a>
        </div>
        <div class="offcanvas__top__hover">
          <span>Usd <i class="arrow_carrot-down"></i></span>
          <ul>
            <li>USD</li>
            <li>EUR</li>
            <li>USD</li>
          </ul>
        </div>
      </div>
      <div class="offcanvas__nav__option">
        <a href="#" class="search-switch"
          ><img src="./img/icon/search.png" alt=""
        /></a>
        <a href="#"><img src="./img/icon/heart.png" alt="" /></a>
        <a href="#"><img src="./img/icon/cart.png" alt="" /> <span>0</span></a>
        <div class="price">$0.00</div>
      </div>
      <div id="mobile-menu-wrap"></div>
      <div class="offcanvas__text">
        <p>Free shipping, 30-day return or refund guarantee.</p>
      </div>
    </div>
    <!-- Offcanvas Menu End -->
    <!-- Header Section Begin -->
    <header class="header">
      <div class="header__top">
        <div class="container">
          <div class="row">
            <div class="col-lg-6 col-md-7">
              <div class="header__top__left">
                <p>Free shipping, 30-day return or refund guarantee.</p>
              </div>
            </div>
            <div class="col-lg-6 col-md-5">
              <div class="header__top__right">
                <div class="header__top__links">
                  <a href="#">登出</a>
                  <a href="#">提問</a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="container">
        <div class="row">
          <div class="col-lg-3 col-md-3">
            <div class="header__logo">
              <a href="https://localhost:7174/" asp-action="Test"
                ><img src="./img/logo.png" alt=""
              /></a>
            </div>
          </div>
          <div class="col-lg-6 col-md-6">
            <nav class="header__menu mobile-menu">
              <ul>
                <li>
                  <a href="https://localhost:7174/Shopping/GenerateBox"
                    >選購盲盒</a>
                </li>
                <li><a href="https://localhost:7174/Quiz/index">測驗</a></li>
                <li>
                  <a href="https://localhost:7174/Eventfront/List">活動</a>
                </li>
                <li><a href="/wishlist">願望清單</a></li>
                <li><a href="/allwishlist">會員列</a></li>
              </ul>
            </nav>
          </div>
        </div>
      </div>

      <div class="canvas__open"><i class="fa fa-bars"></i></div>
    </header>
    <!-- Header Section End -->

    <!-- Latest Blog Section Begin -->
    <RouterView></RouterView>
    <!-- Latest Blog Section End -->

    <!-- Footer Section Begin -->

    <footer class="footer">
      <div class="container">
        <div class="row">
          <div class="col-lg-3 col-md-6 col-sm-6">
            <div class="footer__about">
              <div class="footer__logo">
                <a href="#"><img src="./img/footer-logo.png" alt="" /></a>
              </div>
              <p>
                The customer is at the heart of our unique business model, which
                includes design.
              </p>
              <a href="#"><img src="./img/payment.png" alt="" /></a>
            </div>
          </div>
          <div class="col-lg-2 offset-lg-1 col-md-3 col-sm-6">
            <div class="footer__widget">
              <h6>Shopping</h6>
              <ul>
                <li><a href="#">Clothing Store</a></li>
                <li><a href="#">Trending Shoes</a></li>
                <li><a href="#">Accessories</a></li>
                <li><a href="#">Sale</a></li>
              </ul>
            </div>
          </div>
          <div class="col-lg-2 col-md-3 col-sm-6">
            <div class="footer__widget">
              <h6>Shopping</h6>
              <ul>
                <li><a href="#">Contact Us</a></li>
                <li><a href="#">Payment Methods</a></li>
                <li><a href="#">Delivary</a></li>
                <li><a href="#">Return & Exchanges</a></li>
              </ul>
            </div>
          </div>
          <div class="col-lg-3 offset-lg-1 col-md-6 col-sm-6">
            <div class="footer__widget">
              <h6>NewLetter</h6>
              <div class="footer__newslatter">
                <p>
                  Be the first to know about new arrivals, look books, sales &
                  promos!
                </p>
                <form action="#">
                  <input type="text" placeholder="Your email" />
                  <button type="submit">
                    <span class="icon_mail_alt"></span>
                  </button>
                </form>
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-lg-12 text-center">
            <div class="footer__copyright__text">
              <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
              <p>
                Copyright © {{ currentYear }} All rights reserved | This
                template is made with
                <i class="fa fa-heart-o" aria-hidden="true"></i> by
                <a href="https://colorlib.com" target="_blank">Colorlib</a>
              </p>
              <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
            </div>
          </div>
        </div>
      </div>
    </footer>
    <!-- Footer Section End -->
    <!-- Search Begin -->
    <div class="search-model">
      <div class="h-100 d-flex align-items-center justify-content-center">
        <div class="search-close-switch">+</div>
        <form class="search-model-form">
          <input type="text" id="search-input" placeholder="Search here....." />
        </form>
      </div>
    </div>
    <!-- Search End -->
  </body>
</template>

<style scoped>
@import "./css/bootstrap.min.css";
@import "./css/font-awesome.min.css";
@import "./css/elegant-icons.css";
@import "./css/magnific-popup.css";
@import "./css/nice-select.css";
@import "./css/owl.carousel.min.css";
@import "./css/slicknav.min.css";
@import "./css/style.css";
</style>
